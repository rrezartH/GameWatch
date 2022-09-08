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
    public class VideoLojaController : ControllerBase
    {
        private readonly GameWatchDBContext _context;
        private readonly IMapper _mapper;

        public VideoLojaController(GameWatchDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("get-videlojat")]
        public async Task<ActionResult<List<VideoLoja>>> GetVideoLojrat()
        {
            return Ok(_mapper.Map<List<GetVideoLojaDTO>>(await _context.VideoLoja.ToListAsync()));
        }

        [HttpGet("get-videoloja-by-id")]
        public async Task<ActionResult<VideoLoja>> GetVideoLojaById(string emri)
        {
            var dbVideoLoja = await _context.VideoLoja.FindAsync(emri);
            if (dbVideoLoja == null)
                return NotFound("Kjo Videoloje nuk ekziston!");

            return Ok(_mapper.Map<GetVideoLojaDTO>(dbVideoLoja));
        }

        [HttpGet("get-videolojat-by-emri")]
        public async Task<ActionResult<List<VideoLoja>>> GetVideoLojratByEmri(string emriLojes)
        {
            var dbVideoLoja = await _context.VideoLoja.Where(v => v.Emri.Equals(emriLojes)).FirstOrDefaultAsync();
            if (dbVideoLoja == null)
                return NotFound("Kjo Videoloje nuk ekziston!");

            return Ok(dbVideoLoja);
        }

        [HttpPost("shto-videoloje")]
        public async Task<ActionResult<VideoLojaDTO>> ShtoVideoLojen(VideoLojaDTO videoLojaDTO)
        {
            if (videoLojaDTO == null || videoLojaDTO.Emri.Equals(""))
                return BadRequest("Videoloja nuk mund te jete e zbrazet");

            var videoLoja = new VideoLoja
            {
                Emri = videoLojaDTO.Emri
            };

            _context.VideoLoja.Add(videoLoja);

            await _context.SaveChangesAsync();

            return Ok(videoLojaDTO);
        }

        [HttpPut("update-videoloje/{id}")]
        public async Task<ActionResult> UpdateVideolojen(int id, VideoLojaDTO videoLojaDTO)
        {
            var dbVideoLoja = await _context.VideoLoja.FindAsync(id);
            if (dbVideoLoja == null)
                return NotFound("Videoloja me kete ID nuk ekziston!");

            if (!videoLojaDTO.Emri.Trim().Equals(""))
                dbVideoLoja.Emri = videoLojaDTO.Emri;

            await _context.SaveChangesAsync();

            return Ok("Videoloja u perditesua me sukses!");
        }

        [HttpDelete("fshij-videoloje/{id}")]
        public async Task<ActionResult> FshijVideolojen(int id)
        {
            var dbVideoLoja = await _context.VideoLoja.FindAsync(id);
            if (dbVideoLoja == null)
                return NotFound("Biznesi me kete ID nuk ekziston!");

            _context.VideoLoja.Remove(dbVideoLoja);
            await _context.SaveChangesAsync();

            return Ok("VideoLoja u fshi me sukses!");
        }
    }
}
