using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldForging.ViewModels;
using Newtonsoft.Json;
using WorldForging.Models;
using WorldForgingApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using WorldForging.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace WorldForging.Controllers
{
    public class RelationshipsController : BaseController
    {
        #region Constructor
        public RelationshipsController(
            WorldForgingDBContext context,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager) : base(
            context,
            signInManager,
            userManager)
        { }
        #endregion Constructor

        #region RESTful Conventions
        /// <summary>
        /// GET: api/relationships
        /// </summary>
        /// <returns>Nothing: this method will raise a NotFound HTTP exception, since we're not supporting this API call.</returns>
        [HttpGet()]
        public IActionResult Get()
        {
            return new JsonResult(Mapper.Map<RelationshipDTO[]>(DbContext.Relationships.ToArray()), DefaultJsonSettings);
        }

        /// <summary>
        /// GET: api/relationships/{id}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>A Json-serialized object representing a single article.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //ArticleViewModel avm = Mapper.Map<ArticleViewModel>(Article);
            var article = DbContext.Relationships.Where(i => i.Id == id).FirstOrDefault();
            if (article != null) return new JsonResult(Mapper.Map<ArticleViewModel>(article), DefaultJsonSettings);
            else return NotFound(new { Error = String.Format("Article ID {0} has not been found", id) });
        }

        /// <summary>
        /// POST: api/relationships
        /// </summary>
        /// <returns>Creates a new article and return it accordingly.</returns>
        [HttpPost()]
        [Authorize]
        public async Task<IActionResult> Add([FromBody]RelationshipViewModel rvm)
        {
            if (rvm != null)
            {
                // create a new article with the client-sent json data
                var relationship = Mapper.Map<Relationship>(rvm);

                // override any property that could be wise to set from server-side only
                relationship.CreatedDate =
                relationship.LastModifiedDate = DateTime.Now;

                relationship.UserId = await GetCurrentUserId();

                // add the new article
                DbContext.Relationships.Add(relationship);

                // persist the changes into the Database.
                DbContext.SaveChanges();

                // return the newly-created article to the client.
                return new JsonResult(Mapper.Map<RelationshipViewModel>(relationship), DefaultJsonSettings);
            }

            // return a generic HTTP Status 500 (Not Found) if the client payload is invalid.
            return new StatusCodeResult(500);
        }

        /// <summary>
        /// PUT: api/relationships/{id}
        /// </summary>
        /// <returns>Updates an existing article and return it accordingly.</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody]RelationshipViewModel rvm)
        {
            if (rvm != null)
            {
                var relationship = DbContext.Relationships.Where(i => i.Id == id).FirstOrDefault();
                if (relationship != null)
                {
                    // handle the update (on per-property basis)
                    relationship.UserId = await GetCurrentUserId();
                    relationship.Description = rvm.Description;
                    //article.Flags = ivm.Flags;
                    //article.Notes = ivm.Notes;
                    //relationship.Text = rvm.Text;
                    relationship.Title = rvm.Title;
                    //article.Type = ivm.Type;

                    // override any property that could be wise to set from server-side only
                    relationship.LastModifiedDate = DateTime.Now;

                    // persist the changes into the Database.
                    DbContext.SaveChanges();

                    // return the updated article to the client.
                    return new JsonResult(Mapper.Map<RelationshipViewModel>(relationship), DefaultJsonSettings);
                }
            }

            // return a HTTP Status 404 (Not Found) if we couldn't find a suitable article.
            return NotFound(new { Error = String.Format("article ID {0} has not been found", id) });
        }


        /// <summary>
        /// DELETE: api/relationships/{id}
        /// </summary>
        /// <returns>Deletes an article, returning a HTTP status 200 (ok) when done.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var article = DbContext.Relationships.Where(i => i.Id == id).FirstOrDefault();
            if (article != null)
            {
                // remove the item to delete from the DbContext.
                DbContext.Relationships.Remove(article);

                // persist the changes into the Database.
                DbContext.SaveChanges();

                // return an HTTP Status 200 (OK).
                return new OkResult();
            }

            // return a HTTP Status 404 (Not Found) if we couldn't find a suitable article.
            return NotFound(new { Error = String.Format("Relationship ID {0} has not been found", id) });
        }
        #endregion

        #region Attribute-based Routing
        

        /// <summary>
        /// GET: api/relationships/Search
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of a default number of Json-serialized objects matching the provided search terms.</returns>
        [HttpGet("Search/{term}")]
        public IActionResult Search(string term)
        {
            var relationships = DbContext.Relationships.Where(i => i.Title.Contains(term)).Take(DefaultNumberOfRelationships).ToArray();
            return new JsonResult(ToRelationshipViewModelList(relationships), DefaultJsonSettings);
        }

        #endregion

        #region Private Members
        /// <summary>
        /// Maps a collection of Article entities into a list of ArticleViewModel objects.
        /// </summary>
        /// <param name="relationships">An IEnumerable collection of article entities</param>
        /// <returns>a mapped list of ArticleViewModel objects</returns>
        private List<RelationshipViewModel> ToRelationshipViewModelList(IEnumerable<Relationship> relationships)
        {
            var lst = new List<RelationshipViewModel>();
            foreach (var i in relationships) lst.Add(Mapper.Map<RelationshipViewModel>(i));
            return lst;
        }

        /// <summary>
        /// Returns the default number of relationships to retrieve when using the parameterless overloads of the API methods retrieving article lists.
        /// </summary>
        private int DefaultNumberOfRelationships
        {
            get
            {
                return 5;
            }
        }

        /// <summary>
        /// Returns the maximum number of relationships to retrieve when using the API methods retrieving article lists.
        /// </summary>
        private int MaxNumberOfRelationships
        {
            get
            {
                return 100;
            }
        }
        #endregion
    }
}
