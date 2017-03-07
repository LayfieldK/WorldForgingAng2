using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WorldForging.Models;
using WorldForging.Models.Locations;
using WorldForgingApi.Models;

namespace WorldForging.Controllers
{
    public class LocationsAPIController : Controller
    {
        private WorldForgingDBContext db;

        public LocationsAPIController(WorldForgingDBContext context)
        {
            db = context;
        }

        // GET: api/LocationsAPI
        public IQueryable<Location> GetLocations()
        {
            return db.Locations;
        }

        // GET: api/LocationsAPI/5
        //[ResponseType(typeof(Location))]
        public async Task<IActionResult> GetLocation(int id)
        {
            Location location = await db.Locations.Where(c => c.LocationId == id).FirstAsync();
            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // PUT: api/LocationsAPI/5
        //[ResponseType(typeof(void))]
        public async Task<IActionResult> PutLocation(int id, Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != location.LocationId)
            {
                return BadRequest();
            }

            db.Entry(location).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/LocationsAPI
        //[ResponseType(typeof(CreateLocationModel))]
        public async Task<IActionResult> PostLocation(CreateLocationModel createLocationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //createLocationModel.VMEntity.WorldId = createLocationModel.WorldId;
            db.Entities.Add(createLocationModel.VMEntity);
            createLocationModel.VMLocation.Entity = createLocationModel.VMEntity;
            db.Locations.Add(createLocationModel.VMLocation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = createLocationModel.VMLocation.LocationId }, createLocationModel.VMLocation);

        }

        // DELETE: api/LocationsAPI/5
        //[ResponseType(typeof(Location))]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            Location location = await db.Locations.Where(c => c.LocationId == id).FirstAsync();
            if (location == null)
            {
                return NotFound();
            }

            db.Locations.Remove(location);
            await db.SaveChangesAsync();

            return Ok(location);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationExists(int id)
        {
            return db.Locations.Count(e => e.LocationId == id) > 0;
        }
    }
}