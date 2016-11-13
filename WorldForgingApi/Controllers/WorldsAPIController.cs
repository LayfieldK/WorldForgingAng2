using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WorldForging.Models;
using WorldForgingApi.Models;

namespace WorldForging.Controllers
{
    [Route("api/[controller]")]
    public class WorldsAPIController : Controller
    {
        private WorldForgingDBContext db;

        public WorldsAPIController(WorldForgingDBContext context)
        {
            db = context;
        }

        // GET: api/WorldsAPI
        [EnableCors("MyPolicy")]
        public IQueryable<World> GetWorlds()
        {
            try
            {
                return db.Worlds.Include(p => p.Entities).AsQueryable<World>();
            }catch(Exception ex)
            {
                string problem = ex.Message;
                return null;
            }
        }

        // GET: api/WorldsAPI/5
        ////[ResponseType(typeof(World))]
        [HttpGet("{worldId}")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> GetWorld(int? worldId)
        {
            if (worldId == null)
            {
                return NotFound();
            }
            World world = await db.Worlds.Where(c => c.WorldId == worldId).FirstAsync();
            if (world == null)
            {
                return NotFound();
            }

            var worldDetailsVM = new WorldsDetailsViewModel();
            worldDetailsVM.World = world;
            worldDetailsVM.Entities = db.Entities.Where(c => c.WorldId == worldId).ToList();
            worldDetailsVM.Characters = db.Characters.Where(c => c.Entity.WorldId == worldId).ToList();
            worldDetailsVM.Races = db.Races.Where(c => c.Group.Entity.WorldId == worldId).ToList();
            worldDetailsVM.Locations = db.Locations.Where(c => c.Entity.WorldId == worldId).ToList();
            worldDetailsVM.Items = db.Items.Where(c => c.Entity.WorldId == worldId).ToList();
            worldDetailsVM.Groups = db.Groups.Where(c => c.Entity.WorldId == worldId).ToList();
            worldDetailsVM.Events = db.Events.Where(c => c.Entity.WorldId == worldId).ToList();
            worldDetailsVM.Subjects = db.Subjects.Where(c => c.WorldId == worldId).ToList();

            return Ok(worldDetailsVM);
        }

        // PUT: api/WorldsAPI/5
        ////[ResponseType(typeof(void))]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorld(int id, [FromBody]World world)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != world.WorldId)
            {
                return BadRequest();
            }

            db.Entry(world).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorldExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WorldsAPI
        ////[ResponseType(typeof(World))]
        [HttpPost]
        public async Task<IActionResult> PostWorld([FromBody]World world)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Worlds.Add(world);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = world.WorldId }, world);
        }

        // DELETE: api/WorldsAPI/5
        ////[ResponseType(typeof(World))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorld(int id)
        {
            World world = await db.Worlds.Where(c => c.WorldId == id).FirstAsync();
            if (world == null)
            {
                return NotFound();
            }

            db.Worlds.Remove(world);
            await db.SaveChangesAsync();

            return Ok(world);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorldExists(int id)
        {
            return db.Worlds.Count(e => e.WorldId == id) > 0;
        }
    }
}