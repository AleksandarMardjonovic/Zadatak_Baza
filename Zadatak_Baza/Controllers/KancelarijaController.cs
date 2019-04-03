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
[Route("api/Kancelarija")]
[ApiController]
public class KancelarijaController : ControllerBase
{
    private readonly BazaContext _context;

    public KancelarijaController(BazaContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Daje sve kancelarije
    /// </summary>
    /// <returns></returns>
    // GET: api/Kancelarija
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Kancelarija>>> GetKancelarije()
    {
        return await _context.Kancelarije.ToListAsync();
    }

        /// <summary>
        ///  Daje kancelariju sa datim identifikacionim brojem - id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/Kancelarija/5
        [HttpGet("{id}")]
    public async Task<ActionResult<Kancelarija>> GetKancelarija(long id)
    {
        var kancelarijaItem = await _context.Kancelarije.FindAsync(id);

        if (kancelarijaItem == null)
        {
            return NotFound();

        }

        return kancelarijaItem;
    }
        /// <summary>
        /// Vraća ko se nalazi u datoj kancelariji
        /// </summary>
        /// <param name="naziv"></param>
        /// <returns></returns>
    [HttpGet("listaosoba/{naziv}")]
    public ActionResult<Kancelarija> GetOsobeUKancelariji(string naziv)
    {
        var uredjajiItem = _context.Kancelarije
            .Where(a => a.NazivKancelarije == naziv)
            .Select(b => new
            {
               osobe = b.Osobe
             
            });
        return Ok(uredjajiItem);
    }
        /// <summary>
        /// Kreira kancelariju
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
    // POST api/Kancelarija
    [HttpPost]
    public async Task<ActionResult<Kancelarija>> PostKancelarija(Kancelarija item)
    {
        _context.Kancelarije.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetKancelarija), new {id = item.KancelarijaId}, item);

    }
        /// <summary>
        /// Izmjene naziva kancelarije
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
    // PUT api/Kancelarija/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutKancelarija(long id, Kancelarija item)
    {
        if (id != item.KancelarijaId)
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
    // DELETE api/Kancelarija/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteKancelarija(long id)
    {
        var kancelarijaItem = await _context.Kancelarije.FindAsync(id);

        if (kancelarijaItem == null)
        {
            return NotFound();
        }

        _context.Kancelarije.Remove(kancelarijaItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
}
