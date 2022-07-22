using GameWatchAPI.Data;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaController : ControllerBase
    {
        private readonly GameWatchDBContext _context;

        public FaturaController(GameWatchDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetFatura")]
        public async Task<ActionResult<List<Fatura>>> GetFatura()
        {
            return Ok(await _context.Fatura.ToListAsync());
        }

        [HttpGet("GetFaturaById")]
        public async Task<ActionResult<Fatura>> GetFaturaByID(int id)
        {
            var dbFatura = await _context.Fatura.FindAsync(id);
            if (dbFatura == null)
                return NotFound("Kjo fature nuk ekziston!");

            return Ok(dbFatura);
        }

        [HttpGet("GetFaturatByLokali")]
        public async Task<ActionResult<List<Fatura>>> GetFaturatByLokali(int lokaliId)
        {
            List<Fatura> dbFatura = await _context.Fatura
                                            .Where(f => f.LokaliId == lokaliId)
                                            .ToListAsync();
            if (dbFatura == null)
                return NotFound("Nuk ka asnje fature nga ky lokal!");

            return Ok(dbFatura);
        }

        [HttpPost("ShtoFature")]
        public async Task<ActionResult<FaturaDTO>> ShtoFature(FaturaDTO faturaDTO)
        {
            if (faturaDTO == null)
                return BadRequest("Fatura nuk mund te jete e zbrazet!");

            Fatura fatura = new Fatura
            {
                FillimiLojes = faturaDTO.FillimiLojes,
                MbarimiLojes = faturaDTO.MbarimiLojes,
                NrLojtareve = faturaDTO.NrLojtareve,
                BiznesiKonzola = faturaDTO.BiznesiKonzola,
                VideoLojaId = faturaDTO.VideoLojaId,
                LokaliId = faturaDTO.LokaliId,
                CmimiTotal = faturaDTO.CmimiTotal
            };

            _context.Fatura.Add(fatura);

            await _context.SaveChangesAsync();

            return Ok(faturaDTO);
        }

        [HttpPut("UpdateFaturen")]
        public async Task<ActionResult<FaturaDTO>> UpdateFaturen(int id, FaturaDTO faturaDTO)
        {
            var dbFatura = await _context.Fatura.FindAsync(id);
            if (dbFatura == null)
                return NotFound("Kjo fature nuk ekziston!");

            if (faturaDTO == null)
                return BadRequest("Fatura nuk mund te jete e zbrazet!");

            if (!faturaDTO.FillimiLojes.Trim().Equals(""))
                dbFatura.FillimiLojes = faturaDTO.FillimiLojes;
            if (!faturaDTO.MbarimiLojes.Trim().Equals(""))
                dbFatura.MbarimiLojes = faturaDTO.MbarimiLojes;
            if (faturaDTO.NrLojtareve != 0)
                dbFatura.NrLojtareve = faturaDTO.NrLojtareve;
            if (faturaDTO.BiznesiKonzola != 0)
                dbFatura.BiznesiKonzola = faturaDTO.BiznesiKonzola;
            if (faturaDTO.VideoLojaId != 0)
                dbFatura.VideoLojaId = faturaDTO.VideoLojaId;
            if (faturaDTO.LokaliId != 0)
                dbFatura.LokaliId = faturaDTO.LokaliId;
            if (faturaDTO.CmimiTotal != 0)
                dbFatura.CmimiTotal = faturaDTO.CmimiTotal;

            await _context.SaveChangesAsync();

            return Ok("Fatura u perditesua me sukses!");
        }
    }
}
