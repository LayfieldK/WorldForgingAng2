using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldForging.Models;
using Microsoft.AspNetCore.Cors;
using WorldForgingApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldForging.Controllers
{
    [Route("api/[controller]")]
    public class ArticleAPIController : Controller
    {

        private WorldForgingDBContext db;

        public ArticleAPIController(WorldForgingDBContext context)
        {
            db = context;
        }

        // GET: api/WorldsAPI
        [EnableCors("MyPolicy")]
        public IQueryable<Article> GetArticles()
        {
            try
            {
                return db.Articles;
            }
            catch (Exception ex)
            {
                string problem = ex.Message;
                return null;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
