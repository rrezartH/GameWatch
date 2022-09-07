using AutoMapper;
using GameWatchAPI.Data;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameWatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiznesiController : ControllerBase
    {
        private readonly GameWatchDBContext _context;
        private readonly IMapper _mapper;
        public BiznesiController(GameWatchDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("get-bizneset")]
        public async Task<ActionResult<List<Biznesi>>> GetBiznesin()
        {
            return Ok(_mapper.Map<List<GetBiznesiDTO>>(await _context.Biznesi.ToListAsync()));
        }

        [HttpGet("get-biznesin-by-id")]
        public async Task<ActionResult<Biznesi>> GetBiznesiById(int id)
        {
            var dbBiznesi = await _context.Biznesi.FindAsync(id);
            if (dbBiznesi == null)
                return NotFound("Ky biznes nuk ekziston.");

            return Ok(dbBiznesi);
        }

        [HttpPost("shto-biznes")]
        public async Task<ActionResult<BiznesiDTO>> ShtoBiznes(BiznesiDTO biznesiDTO)
        {
            if (biznesiDTO == null)
                return BadRequest("Nuk mund te shtoni biznes te zbrazet!");

            var biznesi = _mapper.Map<Biznesi>(biznesiDTO);
            _context.Biznesi.Add(biznesi);
            await _context.SaveChangesAsync();

            return Ok(biznesiDTO);
        }

        [HttpPut("update-biznesin/{id}")]
        public async Task<ActionResult> UpdateBiznesin(int id, BiznesiDTO biznesiDTO)
        {
            var dbBiznesi = await _context.Biznesi.FindAsync(id);
            if (dbBiznesi == null)
                return NotFound("Biznesi me kete ID nuk ekziston!");

            if (!biznesiDTO.Emri.Trim().Equals(""))
                dbBiznesi.Emri = biznesiDTO.Emri;
            if (!biznesiDTO.Email.Trim().Equals(""))
                dbBiznesi.Email = biznesiDTO.Email;
            if (!biznesiDTO.NrTel.Trim().Equals(""))
                dbBiznesi.NrTel = biznesiDTO.NrTel;
            if (!biznesiDTO.Qyteti.Trim().Equals(""))
                dbBiznesi.Qyteti = biznesiDTO.Qyteti;
            if (!biznesiDTO.Adresa.Trim().Equals(""))
                dbBiznesi.Adresa = biznesiDTO.Adresa;
            if (biznesiDTO.ProfilePicture == null)
                dbBiznesi.ProfilePicture = biznesiDTO.ProfilePicture;

            await _context.SaveChangesAsync();

            return Ok("Biznesi u perditesua me sukses!");
        }

        [HttpDelete("fshij-biznesin/{id}")]
        public async Task<ActionResult> FshijBiznesin(int id)
        {
            var dbBiznesi = await _context.Biznesi.FindAsync(id);
            if (dbBiznesi == null)
                return NotFound("Biznesi me kete ID nuk ekziston!");

            _context.Biznesi.Remove(dbBiznesi);
            await _context.SaveChangesAsync();

            return Ok("Biznesi u fshi me sukses!");
        }

    }
}
