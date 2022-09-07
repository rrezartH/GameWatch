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
    public class CmimorjaController : ControllerBase
    {
        private readonly GameWatchDBContext _context;
        private readonly IMapper _mapper;
        public CmimorjaController(GameWatchDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("get-cmimoret")]
        public async Task<ActionResult<List<GetCmimiDTO>>> GetCmimorja()
        {
            return Ok(_mapper.Map<List<GetCmimiDTO>>(await _context.Cmimorja.ToListAsync()));
        }

        [HttpGet("get-cmimorja-by-id")]
        public async Task<ActionResult<Cmimorja>> GetCmimorjaById(int id)
        {
            var dbCmimorja = await _context.Cmimorja.FindAsync(id);
            if (dbCmimorja == null)
                return NotFound("Kjo cmimore nuk ekziston.");

            return Ok(dbCmimorja);
        }

        [HttpPost("shto-cmimorja")]
        public async Task<ActionResult<CmimorjaDTO>> ShtoBiznes(CmimorjaDTO cmimorjaDTO)
        {
            if (cmimorjaDTO == null)
                return BadRequest("Nuk mund te shtoni cmimore te zbrazet!");

            var cmimorja = _mapper.Map<Cmimorja>(cmimorjaDTO);

            _context.Cmimorja.Add(cmimorja);
            await _context.SaveChangesAsync();

            return Ok(cmimorjaDTO);
        }

        [HttpPut("update-cmimore/{id}")]
        public async Task<ActionResult> UpdateCmimoren(int id, CmimorjaDTO cmimorjaDTO)
        {
            var dbCmimorja = await _context.Cmimorja.FindAsync(id);
            if (dbCmimorja == null)
                return NotFound("BiznesKonzola me kete ID nuk ekziston!");

            if (cmimorjaDTO.NrLojtareve != 0)
                dbCmimorja.NrLojtareve = cmimorjaDTO.NrLojtareve;
            if (cmimorjaDTO.Cmimi != 0)
                dbCmimorja.Cmimi = cmimorjaDTO.Cmimi;
            if (cmimorjaDTO.BiznesiId != 0)
                dbCmimorja.BiznesiId = cmimorjaDTO.BiznesiId;


            await _context.SaveChangesAsync();

            return Ok("Cmimorja u perditesua me sukses!");
        }

        [HttpDelete("fshij-cmimore/{id}")]
        public async Task<ActionResult> FshijCmimoren(int id)
        {
            var dbCmimorja = await _context.Cmimorja.FindAsync(id);
            if (dbCmimorja == null)
                return NotFound("Cmimorja me kete ID nuk ekziston!");

            _context.Cmimorja.Remove(dbCmimorja);
            await _context.SaveChangesAsync();

            return Ok("Cmimorja u fshi me sukses!");
        }
    }
}
