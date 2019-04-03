
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using Zadatak_Baza.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zadatak_Baza.Controllers
{
    [Route("api/Osoba")]
    [ApiController]
    public class OsobaController : ControllerBase
    {
        private readonly BazaContext _context;

        public OsobaController(BazaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Daje sve osobe
        /// </summary>
        /// <returns></returns>
        // GET: api/Osoba
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Osoba>>> GetOsobe()
        {
            return await _context.Osobe.ToListAsync();
        }

        /// <summary>
        ///  Daje osobu sa datim identifikacionim brojem - id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/Osoba/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Osoba>> GetOsoba(long id)
        {
            var osobaItem = await _context.Osobe.FindAsync(id);

            if (osobaItem == null)
            {
                return NotFound();

            }

            return osobaItem;
        }
        /// <summary>
        /// Vraća puno ime svih osoba sa datim imenom, kao i kancelariju u kojoj se nalaze
        /// </summary>
        /// <param name="ime"></param>
        /// <returns></returns>
      
       [HttpGet("GetOsobaNazivKancelarije/{ime}")]
        public ActionResult<IEnumerable<Osoba>> GetOsobaNazivKancelarije(string ime)
       {
           var kancelarijaNaziv = _context.Osobe
               .Where(a => a.ImeOsoba == ime)
               .Select(b => new
               {
                   ime= b.ImeOsoba,
                   prezime = b.PrezimeOsoba,

                   kancelarija = b.Kancelarija.NazivKancelarije
               });

            return Ok(kancelarijaNaziv);

       }
       

        /// <summary>
        /// Kreira osobu
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        // POST api/Osoba
  
        [HttpPost]
        public async Task<ActionResult<Osoba>>  PostOsoba(Osoba item)
        {
            _context.Osobe.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOsoba), new {id = item.OsobaId}, item);
        }

        /// <summary>
        /// Ažurira informaciju o osobi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        // PUT api/Osoba/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOsoba (long id, Osoba item)
        {
            if (id != item.OsobaId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Briše zapis o osobi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/Osoba/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOsoba (long id)
        {
            var osobaItem = await _context.Osobe.FindAsync(id);

            if (osobaItem == null)
            {
                return NotFound();
            }

            _context.Osobe.Remove(osobaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
