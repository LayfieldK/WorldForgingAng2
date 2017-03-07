using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WorldForging.Models;
using WorldForging.Models.Groups;
using WorldForgingApi.Models;

namespace WorldForging.Controllers
{
    public class GroupsAPIController : Controller
    {
        private WorldForgingDBContext db;

        public GroupsAPIController(WorldForgingDBContext context)
        {
            db = context;
        }

        // GET: api/GroupsAPI
        public IQueryable<Group> GetGroups()
        {
            return db.Groups;
        }

        // GET: api/GroupsAPI/5
        //[ResponseType(typeof(Group))]
        public async Task<IActionResult> GetGroup(int id)
        {
            Group group = await db.Groups.Where(c => c.GroupId == id).FirstAsync();
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // PUT: api/GroupsAPI/5
        //[ResponseType(typeof(void))]
        public async Task<IActionResult> PutGroup(int id, Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != group.GroupId)
            {
                return BadRequest();
            }

            db.Entry(group).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/GroupsAPI
        //[ResponseType(typeof(CreateGroupModel))]
        public async Task<IActionResult> PostGroup(CreateGroupModel createGroupModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //createGroupModel.VMEntity.WorldId = createGroupModel.WorldId;
            db.Entities.Add(createGroupModel.VMEntity);
            createGroupModel.VMGroup.Entity = createGroupModel.VMEntity;
            db.Groups.Add(createGroupModel.VMGroup);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = createGroupModel.VMGroup.GroupId }, createGroupModel.VMGroup);

        }

        // DELETE: api/GroupsAPI/5
        //[ResponseType(typeof(Group))]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            Group group = await db.Groups.Where(c => c.GroupId == id).FirstAsync();
            if (group == null)
            {
                return NotFound();
            }

            db.Groups.Remove(group);
            await db.SaveChangesAsync();

            return Ok(group);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupExists(int id)
        {
            return db.Groups.Count(e => e.GroupId == id) > 0;
        }
    }
}