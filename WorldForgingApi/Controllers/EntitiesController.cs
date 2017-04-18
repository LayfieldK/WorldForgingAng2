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
    public class EntitiesController : BaseController
    {
        #region Constructor
        public EntitiesController(
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
        /// GET: api/entities
        /// </summary>
        /// <returns>Nothing: this method will raise a NotFound HTTP exception, since we're not supporting this API call.</returns>
        [HttpGet()]
        public IActionResult Get()
        {
            return new JsonResult(Mapper.Map<EntityDTO[]>(DbContext.Entities.ToArray()), DefaultJsonSettings);
        }

        /// <summary>
        /// GET: api/entities/{id}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>A Json-serialized object representing a single article.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //ArticleViewModel avm = Mapper.Map<ArticleViewModel>(Article);
            var article = DbContext.Entities.Where(i => i.Id == id).FirstOrDefault();
            if (article != null) return new JsonResult(Mapper.Map<ArticleViewModel>(article), DefaultJsonSettings);
            else return NotFound(new { Error = String.Format("Article ID {0} has not been found", id) });
        }

        ///// <summary>
        ///// POST: api/entities
        ///// </summary>
        ///// <returns>Creates a new article and return it accordingly.</returns>
        //[HttpPost()]
        //[Authorize]
        //public async Task<IActionResult> Add([FromBody]EntityViewModel rvm)
        //{
        //    if (rvm != null)
        //    {
        //        // create a new article with the client-sent json data
        //        var entity = Mapper.Map<Entity>(rvm);

        //        // override any property that could be wise to set from server-side only
        //        entity.CreatedDate =
        //        entity.LastModifiedDate = DateTime.Now;

        //        entity.UserId = await GetCurrentUserId();

        //        // add the new article
        //        DbContext.Entities.Add(entity);

        //        // persist the changes into the Database.
        //        DbContext.SaveChanges();

        //        // return the newly-created article to the client.
        //        return new JsonResult(Mapper.Map<EntityViewModel>(entity), DefaultJsonSettings);
        //    }

        //    // return a generic HTTP Status 500 (Not Found) if the client payload is invalid.
        //    return new StatusCodeResult(500);
        //}

        ///// <summary>
        ///// PUT: api/entities/{id}
        ///// </summary>
        ///// <returns>Updates an existing article and return it accordingly.</returns>
        //[HttpPut("{id}")]
        //[Authorize]
        //public async Task<IActionResult> Update(int id, [FromBody]EntityViewModel rvm)
        //{
        //    if (rvm != null)
        //    {
        //        var entity = DbContext.Entities.Where(i => i.Id == id).FirstOrDefault();
        //        if (entity != null)
        //        {
        //            // handle the update (on per-property basis)
        //            entity.UserId = await GetCurrentUserId();
        //            entity.Name = rvm.Description;
        //            //article.Flags = ivm.Flags;
        //            //article.Notes = ivm.Notes;
        //            //entity.Text = rvm.Text;
        //            //entity.Title = rvm.Title;
        //            //article.Type = ivm.Type;

        //            // override any property that could be wise to set from server-side only
        //            entity.LastModifiedDate = DateTime.Now;

        //            // persist the changes into the Database.
        //            DbContext.SaveChanges();

        //            // return the updated article to the client.
        //            return new JsonResult(Mapper.Map<EntityViewModel>(entity), DefaultJsonSettings);
        //        }
        //    }

        //    // return a HTTP Status 404 (Not Found) if we couldn't find a suitable article.
        //    return NotFound(new { Error = String.Format("article ID {0} has not been found", id) });
        //}


        /// <summary>
        /// DELETE: api/entities/{id}
        /// </summary>
        /// <returns>Deletes an article, returning a HTTP status 200 (ok) when done.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var article = DbContext.Entities.Where(i => i.Id == id).FirstOrDefault();
            if (article != null)
            {
                // remove the item to delete from the DbContext.
                DbContext.Entities.Remove(article);

                // persist the changes into the Database.
                DbContext.SaveChanges();

                // return an HTTP Status 200 (OK).
                return new OkResult();
            }

            // return a HTTP Status 404 (Not Found) if we couldn't find a suitable article.
            return NotFound(new { Error = String.Format("Entity ID {0} has not been found", id) });
        }
        #endregion

        #region Attribute-based Routing
        

        

        #endregion

        #region Private Members
        ///// <summary>
        ///// Maps a collection of Article entities into a list of ArticleViewModel objects.
        ///// </summary>
        ///// <param name="entities">An IEnumerable collection of article entities</param>
        ///// <returns>a mapped list of ArticleViewModel objects</returns>
        //private List<EntityViewModel> ToEntityViewModelList(IEnumerable<Entity> entities)
        //{
        //    var lst = new List<EntityViewModel>();
        //    foreach (var i in entities) lst.Add(Mapper.Map<EntityViewModel>(i));
        //    return lst;
        //}

       
        #endregion
    }
}
