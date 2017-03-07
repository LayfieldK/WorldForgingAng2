using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WorldForging.Models;
using WorldForging.Models.Items;
using WorldForgingApi.Models;

namespace WorldForging.Controllers
{
    public class ItemsAPIController : Controller
    {
        private WorldForgingDBContext db;

        public ItemsAPIController(WorldForgingDBContext context)
        {
            db = context;
        }

        // GET: api/ItemsAPI
        public IQueryable<Item> GetItems()
        {
            return db.Items;
        }

        // GET: api/ItemsAPI/5
        //[ResponseType(typeof(Item))]
        public async Task<IActionResult> GetItem(int id)
        {
            Item item = await db.Items.Where(c => c.ItemId == id).FirstAsync();
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/ItemsAPI/5
        //[ResponseType(typeof(void))]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.ItemId)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/ItemsAPI
        //[ResponseType(typeof(CreateItemModel))]
        public async Task<IActionResult> PostItem(CreateItemModel createItemModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //createItemModel.VMEntity.WorldId = createItemModel.WorldId;
            db.Entities.Add(createItemModel.VMEntity);
            createItemModel.VMItem.Entity = createItemModel.VMEntity;
            db.Items.Add(createItemModel.VMItem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = createItemModel.VMItem.ItemId }, createItemModel.VMItem);

        }

        // DELETE: api/ItemsAPI/5
        //[ResponseType(typeof(Item))]
        public async Task<IActionResult> DeleteItem(int id)
        {
            Item item = await db.Items.Where(c => c.ItemId == id).FirstAsync();
            if (item == null)
            {
                return NotFound();
            }

            db.Items.Remove(item);
            await db.SaveChangesAsync();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Items.Count(e => e.ItemId == id) > 0;
        }
    }
}