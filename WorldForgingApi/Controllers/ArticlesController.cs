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
    public class ArticlesController : BaseController
    {
        #region Constructor
        public ArticlesController(
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
        /// GET: api/articles
        /// </summary>
        /// <returns>Nothing: this method will raise a NotFound HTTP exception, since we're not supporting this API call.</returns>
        [HttpGet()]
        public IActionResult Get()
        {
            return NotFound(new { Error = "not found" });
        }

        /// <summary>
        /// GET: api/articles/{id}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>A Json-serialized object representing a single article.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //ArticleViewModel avm = Mapper.Map<ArticleViewModel>(Article);
            var article = DbContext.Articles.Where(i => i.Id == id).FirstOrDefault();
            if (article != null) return new JsonResult(Mapper.Map<ArticleViewModel>(article), DefaultJsonSettings);
            else return NotFound(new { Error = String.Format("Article ID {0} has not been found", id) });
        }

        /// <summary>
        /// POST: api/articles
        /// </summary>
        /// <returns>Creates a new article and return it accordingly.</returns>
        [HttpPost()]
        [Authorize]
        public async Task<IActionResult> Add([FromBody]ArticleViewModel ivm)
        {
            if (ivm != null)
            {
                // create a new article with the client-sent json data
                var article = Mapper.Map<Article>(ivm);

                // override any property that could be wise to set from server-side only
                article.CreatedDate =
                article.LastModifiedDate = DateTime.Now;

                article.UserId = await GetCurrentUserId();

                // add the new article
                DbContext.Articles.Add(article);

                // persist the changes into the Database.
                DbContext.SaveChanges();

                // return the newly-created article to the client.
                return new JsonResult(Mapper.Map<ArticleViewModel>(article), DefaultJsonSettings);
            }

            // return a generic HTTP Status 500 (Not Found) if the client payload is invalid.
            return new StatusCodeResult(500);
        }

        /// <summary>
        /// PUT: api/articles/{id}
        /// </summary>
        /// <returns>Updates an existing article and return it accordingly.</returns>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, [FromBody]ArticleViewModel ivm)
        {
            if (ivm != null)
            {
                var article = DbContext.Articles.Where(i => i.Id == id).FirstOrDefault();
                if (article != null)
                {
                    // handle the update (on per-property basis)
                    article.UserId = ivm.UserId;
                    article.Description = ivm.Description;
                    article.Flags = ivm.Flags;
                    article.Notes = ivm.Notes;
                    article.Text = ivm.Text;
                    article.Title = ivm.Title;
                    article.Type = ivm.Type;

                    // override any property that could be wise to set from server-side only
                    article.LastModifiedDate = DateTime.Now;

                    // persist the changes into the Database.
                    DbContext.SaveChanges();

                    // return the updated article to the client.
                    return new JsonResult(Mapper.Map<ArticleViewModel>(article), DefaultJsonSettings);
                }
            }

            // return a HTTP Status 404 (Not Found) if we couldn't find a suitable article.
            return NotFound(new { Error = String.Format("article ID {0} has not been found", id) });
        }


        /// <summary>
        /// DELETE: api/articles/{id}
        /// </summary>
        /// <returns>Deletes an article, returning a HTTP status 200 (ok) when done.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var article = DbContext.Articles.Where(i => i.Id == id).FirstOrDefault();
            if (article != null)
            {
                // remove the item to delete from the DbContext.
                DbContext.Articles.Remove(item);

                // persist the changes into the Database.
                DbContext.SaveChanges();

                // return an HTTP Status 200 (OK).
                return new OkResult();
            }

            // return a HTTP Status 404 (Not Found) if we couldn't find a suitable item.
            return NotFound(new { Error = String.Format("Item ID {0} has not been found", id) });
        }
        #endregion

        #region Attribute-based Routing
        /// <summary>
        /// GET: api/items/GetLatest
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of a default number of Json-serialized objects representing the last inserted items.</returns>
        [HttpGet("GetLatest")]
        public IActionResult GetLatest()
        {
            return GetLatest(DefaultNumberOfItems);
        }

        /// <summary>
        /// GET: api/items/GetLatest/{n}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of {n} Json-serialized objects representing the last inserted items.</returns>
        [HttpGet("GetLatest/{n}")]
        public IActionResult GetLatest(int n)
        {
            if (n > MaxNumberOfItems) n = MaxNumberOfItems;
            var items = DbContext.Articles.OrderByDescending(i => i.CreatedDate).Take(n).ToArray();
            return new JsonResult(ToItemViewModelList(items), DefaultJsonSettings);
        }

        /// <summary>
        /// GET: api/items/GetMostViewed
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of a default number of Json-serialized objects representing the items with most user views.</returns>
        [HttpGet("GetMostViewed")]
        public IActionResult GetMostViewed()
        {
            return GetMostViewed(DefaultNumberOfItems);
        }

        /// <summary>
        /// GET: api/items/GetMostViewed/{n}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of {n} Json-serialized objects representing the items with most user views.</returns>
        [HttpGet("GetMostViewed/{n}")]
        public IActionResult GetMostViewed(int n)
        {
            if (n > MaxNumberOfItems) n = MaxNumberOfItems;
            var items = DbContext.Articles.OrderByDescending(i => i.ViewCount).Take(n).ToArray();
            return new JsonResult(ToItemViewModelList(items), DefaultJsonSettings);
        }

        /// <summary>
        /// GET: api/items/GetRandom
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of a default number of Json-serialized objects representing some randomly-picked items.</returns>
        [HttpGet("GetRandom")]
        public IActionResult GetRandom()
        {
            return GetRandom(DefaultNumberOfItems);
        }

        /// <summary>
        /// GET: api/items/GetRandom/{n}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of {n} Json-serialized objects representing some randomly-picked items.</returns>
        [HttpGet("GetRandom/{n}")]
        public IActionResult GetRandom(int n)
        {
            if (n > MaxNumberOfItems) n = MaxNumberOfItems;
            var items = DbContext.Articles.OrderBy(i => Guid.NewGuid()).Take(n).ToArray();
            return new JsonResult(ToItemViewModelList(items), DefaultJsonSettings);
        }
        #endregion

        #region Private Members
        /// <summary>
        /// Maps a collection of Item entities into a list of ItemViewModel objects.
        /// </summary>
        /// <param name="items">An IEnumerable collection of item entities</param>
        /// <returns>a mapped list of ItemViewModel objects</returns>
        private List<ArticleViewModel> ToItemViewModelList(IEnumerable<Article> items)
        {
            var lst = new List<ArticleViewModel>();
            foreach (var i in items) lst.Add(Mapper.Map<ArticleViewModel>(i));
            return lst;
        }

        /// <summary>
        /// Returns the default number of items to retrieve when using the parameterless overloads of the API methods retrieving item lists.
        /// </summary>
        private int DefaultNumberOfItems
        {
            get
            {
                return 5;
            }
        }

        /// <summary>
        /// Returns the maximum number of items to retrieve when using the API methods retrieving item lists.
        /// </summary>
        private int MaxNumberOfItems
        {
            get
            {
                return 100;
            }
        }
        #endregion
    }
}
