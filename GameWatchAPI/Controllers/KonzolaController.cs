using AutoMapper;
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
        private readonly IMapper _mapper;

        public KonzolaController(GameWatchDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("get-konzolat")]
        public async Task<ActionResult<List<GetKonzolaDTO>>> GetKonzola()
        {
            return Ok(_mapper.Map<List<GetKonzolaDTO>>(await _context.Konzola.ToListAsync()));
        }

        [HttpGet("get-konzola-by-id")]
        public async Task<ActionResult<GetKonzolaDTO>> GetKonzolaById(int id)
        {
            var dbKonzola = await _context.Konzola.FindAsync(id);
            if (dbKonzola == null)
                return NotFound("Kjo Konzole nuk ekziston.");

            return Ok(_mapper.Map<GetKonzolaDTO>(dbKonzola));
        }

        [HttpGet("get-konzola-by-emri")]
        public async Task<ActionResult<Konzola>> GetKonzolaByEmri(string modeli)
        {
            var dbKonzola = await _context.Konzola.Where(k => k.Modeli.Equals(modeli)).FirstOrDefaultAsync();
            if (dbKonzola == null)
                return NotFound("Kjo Konzole nuk ekziston!");

            return Ok(dbKonzola);
        }

        [HttpPost("shto-konzola")]
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

        [HttpPut("update-konzola/{id}")]
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

        [HttpDelete("fshij-konzola/{id}")]
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
