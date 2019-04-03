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
    [Route("api/EvidencijaUpotrebeUredjaja")]
    public class EvidencijaUpotrebeUredjajaController : Controller
    {
        private readonly BazaContext _context;

        public EvidencijaUpotrebeUredjajaController(BazaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Evidencija o upotrebi uređaja
        /// </summary>
        /// <returns></returns>
        // GET: api/Evidencija upotrebe uređaja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvidencjijaUpotrebeUredjaja>>> GetEvidencijaSvihUpotreba ()
        {
            return await _context.EvidencijaUpotrebeUredjaja.ToListAsync();
        }

        /// <summary>
        ///  Daje kancelariju sa datim identifikacionim brojem - id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/Evidencija upotrebe za konkretan uređaja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EvidencjijaUpotrebeUredjaja>> GetEvidencijaUpotrebe(long id)
        {
            var upotrebaItem = await _context.EvidencijaUpotrebeUredjaja.FindAsync(id);

            if (upotrebaItem == null)
            {
                return NotFound();

            }

            return upotrebaItem;
        }
        /// <summary>
        /// Kreira evidenciju o korišćenju uređaja
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        // POST api/Evidencija upotrebe uređaja
        [HttpPost]
        public async Task<ActionResult<EvidencjijaUpotrebeUredjaja>> PostEvidencijaUpotrebe(EvidencjijaUpotrebeUredjaja item)
        {
            _context.EvidencijaUpotrebeUredjaja.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvidencijaUpotrebe), new { id = item.EvidencijaId }, item);
        }
        /// <summary>
        /// Ažuriranje evidencije o korišćenju uređaja
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        // PUT api/Evidencija upotrebe uređaja/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvidencijaUpotrebe(long id, EvidencjijaUpotrebeUredjaja item)
        {
            if (id != item.EvidencijaId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Briše kancelariju
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/Evidencija upotrebe uređaja/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvidencijaUpotrebe(long id)
        {
            var upotrebaItem = await _context.EvidencijaUpotrebeUredjaja.FindAsync(id);

            if (upotrebaItem == null)
            {
                return NotFound();
            }

            _context.EvidencijaUpotrebeUredjaja.Remove(upotrebaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
