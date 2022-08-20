using GameWatchAPI.Data;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BizneziKonzolaVideolojaController : ControllerBase
    {
        private readonly GameWatchDBContext _context;
        public BizneziKonzolaVideolojaController(GameWatchDBContext context)
        {
            _context = context;
        }

        [HttpGet("get-biznesi-konzola-videolojat")]
        public async Task<ActionResult<List<BizneziKonzolaVideoloja>>> GetBizneziKonzolaVideoloja()
        {
            return Ok(await _context.BizneziKonzolaVideoloja.ToListAsync());
        }

        [HttpGet("get-biznesi-konzola-videoloja-by-id")]
        public async Task<ActionResult<BizneziKonzolaVideoloja>> GetBBizneziKonzolaVideolojaById(int id)
        {
            var dbBizneziKonzolaVideoloja = await _context.BizneziKonzolaVideoloja.FindAsync(id);
            if (dbBizneziKonzolaVideoloja == null)
                return NotFound("Kjo loje nuk ekziton ne kete konzole.");

            return Ok(dbBizneziKonzolaVideoloja);
        }

        [HttpPost("shto-biznesi-konzola-videoloja")]
        public async Task<ActionResult<BiznesiKonzolaVideolojaDTO>> ShtoBiznes(BiznesiKonzolaVideolojaDTO biznesiKonzolaVideolojaDTO)
        {
            if (biznesiKonzolaVideolojaDTO == null)
                return BadRequest("Nuk mund te shtoni biznesKonsole te zbrazet!");

            var biznesiKonzolaVideoloja = new BizneziKonzolaVideoloja
            {

                BiznesiKonzola = biznesiKonzolaVideolojaDTO.BiznesiKonzola,
                VideoLojaId = biznesiKonzolaVideolojaDTO.VideoLojaId
            };

            _context.BizneziKonzolaVideoloja.Add(biznesiKonzolaVideoloja);
            await _context.SaveChangesAsync();

            return Ok(biznesiKonzolaVideolojaDTO);
        }

        [HttpPut("update-biznesi-konzola-videoloja")]
        public async Task<ActionResult> UpdateBizneziKonzolaVideoloja(int id, BiznesiKonzolaVideolojaDTO biznesiKonzolaVideolojaDTO)
        {
            var dbBizneziKonzolaVideoloja = await _context.BizneziKonzolaVideoloja.FindAsync(id);
            if (dbBizneziKonzolaVideoloja == null)
                return NotFound("BiznesKonzola me kete ID nuk ekziston!");

            if (biznesiKonzolaVideolojaDTO.BiznesiKonzola != 0)
                dbBizneziKonzolaVideoloja.BiznesiKonzola = biznesiKonzolaVideolojaDTO.BiznesiKonzola;
            if (biznesiKonzolaVideolojaDTO.VideoLojaId != 0)
                dbBizneziKonzolaVideoloja.VideoLojaId = biznesiKonzolaVideolojaDTO.VideoLojaId;

            await _context.SaveChangesAsync();

            return Ok("BiznesiKonzolaVideoloja u perditesua me sukses!");
        }

        [HttpDelete("fshij-biznesi-konzola-videoloja")]
        public async Task<ActionResult> FshijBiznesiKonzolaVideoloja(int id)
        {
            var dbBizneziKonzolaVideoloja = await _context.BizneziKonzolaVideoloja.FindAsync(id);
            if (dbBizneziKonzolaVideoloja == null)
                return NotFound("BiznesiKonzola me kete ID nuk ekziston!");

            _context.BizneziKonzolaVideoloja.Remove(dbBizneziKonzolaVideoloja);
            await _context.SaveChangesAsync();

            return Ok("BizneziKonzolaVideoloja u fshi me sukses!");
        }
    }
}
