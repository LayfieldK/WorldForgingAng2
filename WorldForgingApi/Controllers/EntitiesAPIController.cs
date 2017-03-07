using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WorldForging.Models;
using WorldForging.Models.Entities;
using WorldForgingApi.Models;

namespace WorldForging.Controllers
{
    public class EntitiesAPIController : Controller
    {
        private WorldForgingDBContext db;

        public EntitiesAPIController(WorldForgingDBContext context)
        {
            db = context;
        }

        // GET: api/EntitiesAPI
        public IQueryable<Entity> GetEntities()
        {
            return db.Entities;
        }

        // GET: api/EntitiesAPI/5
        //[ResponseType(typeof(EntityRelationshipViewModel))]
        public async Task<IActionResult> GetEntity(int? entityId)
        {
            Entity entity = await db.Entities.SingleOrDefaultAsync(e => e.Id == entityId);
            if (entity == null)
            {
                return NotFound();
            }
            EntityRelationshipViewModel erVM = new Models.Entities.EntityRelationshipViewModel();
            erVM.Entity = entity;
            //entity.EntityEntities = 
            //erVM.EntityRelationships = db.EntityEntities.Where(ee => ee.Entity1Id == entity.EntityId || ee.Entity2Id == entity.EntityId).ToList();
            //erVM.Entities = db.Entities.Where(c => c.WorldId == entity.WorldId).ToList();
            //erVM.Relationships = db.EntityRelationships.Where(er => er.WorldId == entity.WorldId).ToList();
            return Ok(erVM);
        }

        // PUT: api/EntitiesAPI/5
        //[ResponseType(typeof(void))]
        public async Task<IActionResult> PutEntity(int id, Entity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entity.Id)
            {
                return BadRequest();
            }

            db.Entry(entity).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
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

        // POST: api/EntitiesAPI
        //[ResponseType(typeof(Entity))]
        public async Task<IActionResult> PostEntity(Entity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entities.Add(entity);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
        }

        // DELETE: api/EntitiesAPI/5
        //[ResponseType(typeof(Entity))]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            Entity entity = await db.Entities.Where(c => c.Id == id).FirstAsync();
            if (entity == null)
            {
                return NotFound();
            }

            db.Entities.Remove(entity);
            await db.SaveChangesAsync();

            return Ok(entity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntityExists(int id)
        {
            return db.Entities.Count(e => e.Id == id) > 0;
        }
    }
}