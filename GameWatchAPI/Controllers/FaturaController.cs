using GameWatchAPI.Data;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;
using GameWatchAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaController : ControllerBase
    {
        private readonly GameWatchDBContext _context;
        private readonly FaturaService _faturaService;

        public FaturaController(GameWatchDBContext context, FaturaService faturaService)
        {
            _context = context;
            _faturaService = faturaService;
        }

        [HttpGet("get-faturat")]
        public async Task<ActionResult<List<Fatura>>> GetFatura()
        {
            return Ok(await _context.Fatura.ToListAsync());
        }

        [HttpGet("get-fatura-by-id")]
        public async Task<ActionResult<Fatura>> GetFaturaByID(int id)
        {
            var dbFatura = await _context.Fatura.FindAsync(id);
            if (dbFatura == null)
                return NotFound("Kjo fature nuk ekziston!");

            return Ok(dbFatura);
        }

        [HttpGet("get-faturat-by-lokali/{id}")]
        public async Task<ActionResult<List<Fatura>>> GetFaturatByLokali(int id)
        {
            List<Fatura> dbFatura = await _context.Fatura
                                            .Where(f => f.LokaliId == id)
                                            .ToListAsync();
            if (dbFatura == null)
                return NotFound("Nuk ka asnje fature nga ky lokal!");

            return Ok(dbFatura);
        }

        [HttpGet("get-non-closed-faturat-e-lokalit/{id}")]
        public async Task<ActionResult<List<GetFaturaDTO>>> GetNonClosedFaturatELokalitById(int id)
        {
            var dbFaturat = await _context.Fatura.Where(f => f.LokaliId == id && f.Closed == false)
                .Select(f => new GetFaturaDTO()
                {
                    Id = f.Id,
                    FillimiLojes = f.FillimiLojes,
                    MbarimiLojes = f.MbarimiLojes,
                    NrLojtareve = f.NrLojtareve,
                    Oret = f.Oret,
                    BiznesiKonzola = f.BiznesiKonzola,
                    VideoLojaId = f.VideoLojaId,
                    LokaliId = f.LokaliId,
                    CmimiTotal = f.CmimiTotal,
                    Closed = f.Closed,
                    VideoLoja = f.VideoLoja,
                })
                .ToListAsync();
            if (dbFaturat == null)
                return NotFound("Nuk ka asnje fature te hapur!");

            return Ok(dbFaturat);
        }

        [HttpPost("shto-fatura")]
        public async Task<ActionResult<String>> ShtoFature(FaturaDTO faturaDTO)
        {
            if (faturaDTO == null)
                return BadRequest("Fatura nuk mund te jete e zbrazet!");

            await _faturaService.AddFaturaAsync(faturaDTO);

            return Ok(faturaDTO);
        }

        [HttpPut("update-fatura/{id}")]
        public async Task<ActionResult<FaturaDTO>> UpdateFaturen(int id, FaturaDTO faturaDTO)
        {
            var dbFatura = await _context.Fatura.FindAsync(id);
            if (dbFatura == null)
                return NotFound("Kjo fature nuk ekziston!");

            if (faturaDTO == null)
                return BadRequest("Fatura nuk mund te jete e zbrazet!");

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
