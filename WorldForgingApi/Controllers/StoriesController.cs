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
    public class StoriesController : BaseController
    {
        #region Constructor
        public StoriesController(
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
        /// GET: api/stories
        /// </summary>
        /// <returns>Nothing: this method will raise a NotFound HTTP exception, since we're not supporting this API call.</returns>
        [HttpGet()]
        public IActionResult Get()
        {
            return NotFound(new { Error = "not found" });
        }

        /// <summary>
        /// GET: api/stories/{id}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>A Json-serialized object representing a single story.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //StoryViewModel avm = Mapper.Map<StoryViewModel>(Story);
            var story = DbContext.Stories.Where(i => i.Id == id).FirstOrDefault();
            if (story != null) return new JsonResult(Mapper.Map<StoryViewModel>(story), DefaultJsonSettings);
            else return NotFound(new { Error = String.Format("Story ID {0} has not been found", id) });
        }

        /// <summary>
        /// POST: api/stories
        /// </summary>
        /// <returns>Creates a new story and return it accordingly.</returns>
        [HttpPost()]
        [Authorize]
        public async Task<IActionResult> Add([FromBody]StoryViewModel ivm)
        {
            if (ivm != null)
            {
                // create a new story with the client-sent json data
                var story = Mapper.Map<Story>(ivm);

                // override any property that could be wise to set from server-side only
                story.CreatedDate =
                story.LastModifiedDate = DateTime.Now;

                story.UserId = await GetCurrentUserId();

                // add the new story
                DbContext.Stories.Add(story);

                // persist the changes into the Database.
                DbContext.SaveChanges();

                // return the newly-created story to the client.
                return new JsonResult(Mapper.Map<StoryViewModel>(story), DefaultJsonSettings);
            }

            // return a generic HTTP Status 500 (Not Found) if the client payload is invalid.
            return new StatusCodeResult(500);
        }

        /// <summary>
        /// PUT: api/stories/{id}
        /// </summary>
        /// <returns>Updates an existing story and return it accordingly.</returns>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, [FromBody]StoryViewModel ivm)
        {
            if (ivm != null)
            {
                var story = DbContext.Stories.Where(i => i.Id == id).FirstOrDefault();
                if (story != null)
                {
                    // handle the update (on per-property basis)
                    story.UserId = ivm.UserId;
                    story.Description = ivm.Description;
                    story.Flags = ivm.Flags;
                    story.Notes = ivm.Notes;
                    story.Text = ivm.Text;
                    story.Title = ivm.Title;
                    story.Type = ivm.Type;

                    // override any property that could be wise to set from server-side only
                    story.LastModifiedDate = DateTime.Now;

                    // persist the changes into the Database.
                    DbContext.SaveChanges();

                    // return the updated story to the client.
                    return new JsonResult(Mapper.Map<StoryViewModel>(story), DefaultJsonSettings);
                }
            }

            // return a HTTP Status 404 (Not Found) if we couldn't find a suitable story.
            return NotFound(new { Error = String.Format("story ID {0} has not been found", id) });
        }


        /// <summary>
        /// DELETE: api/stories/{id}
        /// </summary>
        /// <returns>Deletes an story, returning a HTTP status 200 (ok) when done.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var story = DbContext.Stories.Where(i => i.Id == id).FirstOrDefault();
            if (story != null)
            {
                // remove the item to delete from the DbContext.
                DbContext.Stories.Remove(story);

                // persist the changes into the Database.
                DbContext.SaveChanges();

                // return an HTTP Status 200 (OK).
                return new OkResult();
            }

            // return a HTTP Status 404 (Not Found) if we couldn't find a suitable story.
            return NotFound(new { Error = String.Format("Story ID {0} has not been found", id) });
        }
        #endregion

        #region Attribute-based Routing
        /// <summary>
        /// GET: api/stories/GetLatest
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of a default number of Json-serialized objects representing the last inserted stories.</returns>
        [HttpGet("GetLatest")]
        public IActionResult GetLatest()
        {
            return GetLatest(DefaultNumberOfStories);
        }

        /// <summary>
        /// GET: api/stories/GetLatest/{n}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of {n} Json-serialized objects representing the last inserted stories.</returns>
        [HttpGet("GetLatest/{n}")]
        public IActionResult GetLatest(int n)
        {
            if (n > MaxNumberOfStories) n = MaxNumberOfStories;
            var stories = DbContext.Stories.OrderByDescending(i => i.CreatedDate).Take(n).ToArray();
            return new JsonResult(ToStoryViewModelList(stories), DefaultJsonSettings);
        }

        /// <summary>
        /// GET: api/stories/GetMostViewed
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of a default number of Json-serialized objects representing the stories with most user views.</returns>
        [HttpGet("GetMostViewed")]
        public IActionResult GetMostViewed()
        {
            return GetMostViewed(DefaultNumberOfStories);
        }

        /// <summary>
        /// GET: api/stories/GetMostViewed/{n}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of {n} Json-serialized objects representing the stories with most user views.</returns>
        [HttpGet("GetMostViewed/{n}")]
        public IActionResult GetMostViewed(int n)
        {
            if (n > MaxNumberOfStories) n = MaxNumberOfStories;
            var stories = DbContext.Stories.OrderByDescending(i => i.ViewCount).Take(n).ToArray();
            return new JsonResult(ToStoryViewModelList(stories), DefaultJsonSettings);
        }

        /// <summary>
        /// GET: api/stories/GetRandom
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of a default number of Json-serialized objects representing some randomly-picked stories.</returns>
        [HttpGet("GetRandom")]
        public IActionResult GetRandom()
        {
            return GetRandom(DefaultNumberOfStories);
        }

        /// <summary>
        /// GET: api/stories/GetRandom/{n}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of {n} Json-serialized objects representing some randomly-picked stories.</returns>
        [HttpGet("GetRandom/{n}")]
        public IActionResult GetRandom(int n)
        {
            if (n > MaxNumberOfStories) n = MaxNumberOfStories;
            var stories = DbContext.Stories.OrderBy(i => Guid.NewGuid()).Take(n).ToArray();
            return new JsonResult(ToStoryViewModelList(stories), DefaultJsonSettings);
        }
        #endregion

        #region Private Members
        /// <summary>
        /// Maps a collection of Story entities into a list of StoryViewModel objects.
        /// </summary>
        /// <param name="stories">An IEnumerable collection of story entities</param>
        /// <returns>a mapped list of StoryViewModel objects</returns>
        private List<StoryViewModel> ToStoryViewModelList(IEnumerable<Story> stories)
        {
            var lst = new List<StoryViewModel>();
            foreach (var i in stories) lst.Add(Mapper.Map<StoryViewModel>(i));
            return lst;
        }

        /// <summary>
        /// Returns the default number of stories to retrieve when using the parameterless overloads of the API methods retrieving story lists.
        /// </summary>
        private int DefaultNumberOfStories
        {
            get
            {
                return 5;
            }
        }

        /// <summary>
        /// Returns the maximum number of stories to retrieve when using the API methods retrieving story lists.
        /// </summary>
        private int MaxNumberOfStories
        {
            get
            {
                return 100;
            }
        }
        #endregion
    }
}
