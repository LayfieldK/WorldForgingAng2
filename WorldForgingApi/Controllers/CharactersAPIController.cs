using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WorldForging.Models;
using WorldForging.Models.Characters;
using WorldForgingApi.Models;

namespace WorldForging.Controllers
{
    public class CharactersAPIController : Controller
    {
        private WorldForgingDBContext db;

        public CharactersAPIController(WorldForgingDBContext context)
        {
            db = context;
        }

        // GET: api/CharactersAPI
        public IQueryable<Character> GetCharacters()
        {
            return db.Characters;
        }

        // GET: api/CharactersAPI/5
        //[ResponseType(typeof(Character))]
        public async Task<IActionResult> GetCharacter(int id)
        {
            Character character = await db.Characters.Where(c => c.CharacterId == id).FirstAsync();
            //Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        // PUT: api/CharactersAPI/5
        //[ResponseType(typeof(void))]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != character.CharacterId)
            {
                return BadRequest();
            }

            db.Entry(character).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // POST: api/CharactersAPI
        //[ResponseType(typeof(CreateCharacterModel))]
        public async Task<IActionResult> PostCharacter(CreateCharacterModel createCharacterModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Characters.Add(character);
            //await db.SaveChangesAsync();

            createCharacterModel.VMEntity.WorldId = createCharacterModel.WorldId;
            db.Entities.Add(createCharacterModel.VMEntity);
            createCharacterModel.VMCharacter.Entity = createCharacterModel.VMEntity;
            db.Characters.Add(createCharacterModel.VMCharacter);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = createCharacterModel.VMCharacter.CharacterId }, createCharacterModel.VMCharacter);
        }

        // DELETE: api/CharactersAPI/5
        //[ResponseType(typeof(Character))]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            Character character = await db.Characters.Where(c => c.CharacterId == id).FirstAsync();
            if (character == null)
            {
                return NotFound();
            }

            db.Characters.Remove(character);
            await db.SaveChangesAsync();

            return Ok(character);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharacterExists(int id)
        {
            return db.Characters.Count(e => e.CharacterId == id) > 0;
        }
    }
}