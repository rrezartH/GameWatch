using AutoMapper;
using GameWatchAPI.Data;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;
using GameWatchAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameWatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaController : ControllerBase
    {
        private readonly GameWatchDBContext _context;
        private readonly FaturaService _faturaService;
        private readonly IMapper _mapper;

        public FaturaController(GameWatchDBContext context, FaturaService faturaService, IMapper mapper)
        {
            _context = context;
            _faturaService = faturaService;
            _mapper = mapper;
        }

        [HttpGet("get-faturat")]
        public async Task<ActionResult<List<GetFaturaDTO>>> GetFatura()
        {
            return Ok(_mapper.Map<List<GetFaturaDTO>>(await _context.Fatura.ToListAsync()));
        }

        [HttpGet("get-fatura-by-id")]
        public async Task<ActionResult<Fatura>> GetFaturaByID(int id)
        {
            var dbFatura = await _context.Fatura.FindAsync(id);
            if (dbFatura == null)
                return NotFound("Kjo fature nuk ekziston!");

            return Ok(dbFatura);
        }

        /*[HttpGet("get-faturat-by-lokali/{id}")]
        public async Task<ActionResult<List<Fatura>>> GetFaturatByLokali(int id)
        {
            List<Fatura> dbFatura = await _context.Fatura
                                            .Where(f => f.LokaliId == id)
                                            .ToListAsync();
            if (dbFatura == null)
                return NotFound("Nuk ka asnje fature nga ky lokal!");

            return Ok(dbFatura);
        }*/

        [HttpGet("get-faturat-by-lokali/{id}")]
        public async Task<ActionResult<List<GetFaturaLokaliDTO>>> GetFaturatByLokali(int id, int pageNumber)
        {
            var dbFaturat = _mapper.Map<List<GetFaturaLokaliDTO>>(await _faturaService.GetFaturatByLokaliIdAsync(id, pageNumber));

            if (dbFaturat == null)
                return NotFound("Ky lokal nuk ka asnje fature!");

            return Ok(dbFaturat);
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

        [HttpGet("get-preview-fatura/{id}")]
        public async Task<ActionResult<PreviewFaturaDTO>> GetPreviewFatura(int id)
        {
            var dbFatura = await _context.Fatura.FindAsync(id);
            if (dbFatura == null)
                return NotFound("Kjo fature nuk u gjet!");
            if(dbFatura.Closed == true)
                return BadRequest("Kjo fature eshte mbyllur!");

            return Ok(await _faturaService.GetPreviewFaturaAsync(dbFatura));
        } 

        [HttpGet("get-earnings-by-period/{period}/{lokaliId}")]
        public async Task<ActionResult> GetEarningsByPeriod(string period, int lokaliId)
        {
            switch (period)
            {
                case "daily":
                    return Ok(await _faturaService.GetEarningsByPeriodAsync(0, lokaliId));
                case "weekly":
                    return Ok(await _faturaService.GetEarningsByPeriodAsync(7, lokaliId));
                case "monthly":
                    return Ok(await _faturaService.GetEarningsByPeriodAsync(30, lokaliId));
                default:
                    break;
            }
            return BadRequest("Ju nuk keni vendosur periode valide.");
        }

        [HttpPost("shto-fatura")]
        public async Task<ActionResult<String>> ShtoFature(FaturaDTO faturaDTO)
        {
            if (faturaDTO == null)
                return BadRequest("Fatura nuk mund te jete e zbrazet!");

            await _faturaService.AddFaturaAsync(faturaDTO);

            return Ok(faturaDTO);
        }

        [HttpPut("finalizo-fatura/{id}")]
        public async Task<ActionResult> FinalizoFature(int id)
        {
            await _faturaService.FinalizoFaturaAsync(id);

            return Ok("Fatura u finalizua!");
        }

        [HttpPut("update-fatura/{id}")]
        public async Task<ActionResult> UpdateFatura(int id, UpdateFaturaDTO faturaDTO)
        {
            if (faturaDTO == null)
                return BadRequest("Nuk mund te beni kerkese te zbrazet!");

            var dbFatura = await _context.Fatura.FindAsync(id);
            if (dbFatura == null)
                return NotFound("Kjo fature nuk u gjet!");

            if (DateTime.Now.AddHours((double)-faturaDTO.Oret!) > dbFatura.FillimiLojes)
                return BadRequest("Kane kaluar me shume ore se sa oret qe keni vendosur.");

            await _faturaService.UpdateFaturaAsync(dbFatura, faturaDTO);
            return Ok("Perditsimi pati sukses!");
        }
    
        [HttpDelete("delete-fatura/{id}")]
        public async Task<ActionResult> DeleteFaturaById(int id)
        {
            var dbFatura = await _context.Fatura.FindAsync(id);
            if (dbFatura == null)
                return NotFound("Kjo fature nuk ekziston!");

            _context.Fatura.Remove(dbFatura);
            await _context.SaveChangesAsync();

            return Ok("Fatura u fshi me sukses!");
        }
    }
}