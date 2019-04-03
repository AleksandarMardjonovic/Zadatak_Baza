using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadatak_Baza.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zadatak_Baza.Controllers
{
    [Route("api/Uredjaj")]
    public class UredjajController : Controller
    {
        private readonly BazaContext _context;

        public UredjajController(BazaContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Daje sve uređaje
        /// </summary>
        /// <returns></returns>
        // GET: api/Uredjaj
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uredjaj>>> GetUredjaji()
        {
            return await _context.Uredjaji.ToListAsync();
        }

        /// <summary>
        /// Daje uređaj sa datim identifikacionim brojem - id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/Uredjaj/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uredjaj>> GetUredjaj(long id)
        {
            var uredjajItem = await _context.Uredjaji.FindAsync(id);

            if (uredjajItem == null)
            {
                return NotFound();

            }

            return uredjajItem;
        }
        /// <summary>
        /// Kreira uređaj
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Novo kreirani uređaj</returns>
        /// <response code="201">Vraća novokreirani uređaj</response>
        /// <response code="201">Ukoliko ništa nije unijeto - null</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Uredjaj>> PostUredjaj(Uredjaj item)
        {
            _context.Uredjaji.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUredjaj), new {id = item.UredjajId}, item);
        }

        /// <summary>
        /// Mijenjanje naziva uređaja
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        // PUT api/Uredjaj/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUredjaj(long id, Uredjaj item)
        {
            if (id != item.UredjajId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// Briše zapis o uređaju, određen datim identifikacionim brojem -id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/Uredjaj/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUredjaj(long id)
        {
            var uredjajItem = await _context.Uredjaji.FindAsync(id);

            if (uredjajItem == null)
            {
                return NotFound();
            }

            _context.Uredjaji.Remove(uredjajItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
