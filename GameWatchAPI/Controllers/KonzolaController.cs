using GameWatchAPI.Data;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KonzolaController : ControllerBase
    {

        private readonly GameWatchDBContext _context;
        public KonzolaController(GameWatchDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetKonzola")]
        public async Task<ActionResult<List<Konzola>>> GetKonzola()
        {
            return Ok(await _context.Konzola.ToListAsync());
        }

        [HttpGet("GetKonzolaById")]
        public async Task<ActionResult<Konzola>> GetKonzolaById(int id)
        {
            var dbKonzola = await _context.Konzola.FindAsync(id);
            if (dbKonzola == null)
                return NotFound("Kjo Konzole nuk ekziston.");

            return Ok(dbKonzola);
        }

        [HttpGet("GetKonzolaByEmri")]
        public async Task<ActionResult<Konzola>> GetKonzolaByEmri(string modeli)
        {
            var dbKonzola = await _context.Konzola.Where(k => k.Modeli.Equals(modeli)).FirstOrDefaultAsync();
            if (dbKonzola == null)
                return NotFound("Kjo Konzole nuk ekziston!");

            return Ok(dbKonzola);
        }

        [HttpPost("ShtoKonzola")]
        public async Task<ActionResult<Konzola>> ShtoKonzola(KonzolaDTO konzolaDTO)
        {
            if (konzolaDTO == null)
                return BadRequest("Nuk mund te shtoni Konzole te zbrazet!");

            var konzola = new Konzola
            {
                Modeli = konzolaDTO.Modeli,

            };

            _context.Konzola.Add(konzola);
            await _context.SaveChangesAsync();

            return Ok(konzolaDTO);
        }

        [HttpPut("UpdateKonzola")]
        public async Task<ActionResult> UpdateKonzola(int id, KonzolaDTO konzolaDTO)
        {
            var dbKonzola = await _context.Konzola.FindAsync(id);
            if (dbKonzola == null)
                return NotFound("Konzola me kete ID nuk ekziston!");

            if (!konzolaDTO.Modeli.Trim().Equals(""))
                dbKonzola.Modeli = konzolaDTO.Modeli;

            await _context.SaveChangesAsync();

            return Ok("Konzola u perditesua me sukses!");
        }

        [HttpDelete("FshijKonzola")]
        public async Task<ActionResult> FshijKonzola(int id)
        {
            var dbKonzola = await _context.Konzola.FindAsync(id);
            if (dbKonzola == null)
                return NotFound("Konzola me kete ID nuk ekziston!");

            _context.Konzola.Remove(dbKonzola);
            await _context.SaveChangesAsync();

            return Ok("Konzola u fshi me sukses!");
        }
    }
}
