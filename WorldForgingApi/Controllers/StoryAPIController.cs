using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldForgingApi.Models;
using Microsoft.AspNetCore.Cors;
using WorldForging.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldForging.Controllers
{
    [Route("api/[controller]")]
    public class StoryAPIController : Controller
    {
        private WorldForgingDBContext db;

        public StoryAPIController(WorldForgingDBContext context)
        {
            db = context;
        }

        // GET: api/WorldsAPI
        [EnableCors("MyPolicy")]
        public IQueryable<Story> GetStories()
        {
            try
            {
                return db.Stories;
            }
            catch (Exception ex)
            {
                string problem = ex.Message;
                return null;
            }
        }

        // GET api/values/5
        [HttpGet("{storyId}", Name ="GetStory")]
        [EnableCors("MyPolicy")]
        public Story Get(int storyId)
        {
            try
            {
                //return db.Stories.Find(storyId);
                return db.Stories.Where(c => c.StoryId == storyId).First();
            }
            catch (Exception ex)
            {
                string problem = ex.Message;
                return null;
            }
        }

        // POST api/values
        [HttpPost]
        [EnableCors("MyPolicy")]
        public IActionResult Create([FromBody] Story story)
        {
            if (story == null)
            {
                return BadRequest();
            }
            db.Stories.Add(story);
            return CreatedAtRoute("GetStory", new { id = story.StoryId }, story);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
