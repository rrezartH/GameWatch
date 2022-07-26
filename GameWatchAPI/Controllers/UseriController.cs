using GameWatchAPI.Data;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseriController : ControllerBase
    {
        private readonly GameWatchDBContext _context;

        public UseriController(GameWatchDBContext context)
        {
            _context = context;         
        }

        [HttpGet("getUsers")]
        public async Task<ActionResult<List<Useri>>> GetUsers()
        {
            return Ok(await _context.Useri.ToListAsync());
        }
        
        [HttpGet("getUserById")]
        public async Task<ActionResult<Useri>> GetUserById(int id)
        {
            var dbUser = await _context.Useri.FindAsync(id);
            if (dbUser == null) return NotFound("Ky klient nuk u gjet!");

            return Ok(dbUser);
        }

        [HttpGet("getUsersByBusiness")]
        public async Task<ActionResult<List<Useri>>> GetUsersByBusiness(int id)
        {
            var dbUsers = await _context.Useri.Where(u => u.BiznesiId == id).ToListAsync();

            if (dbUsers == null) return NotFound("Ky biznes nuk ka punetore per momentin!");

            return Ok(dbUsers);
        }

        [HttpGet("getUsersByLokali")]
        public async Task<ActionResult<List<Useri>>> GetUsersByLokali(int id)
        {
            var dbUsers = await _context.Useri.Where(u => u.LokaliId == id).ToListAsync();

            if (dbUsers == null) return NotFound("Ky lokal nuk ka asnje punetor!");

            return Ok(dbUsers);
        }

        [HttpPost("shtoUser")]
        /*public async Task<ActionResult<Lokali>> ShtoLokali(LokaliDTO lokaliDTO)
        {
            if (lokaliDTO == null)
                return BadRequest("Nuk mund te shtosh lokal te zbrazet!");

            var Lokali = new Lokali
            {
                Emri = lokaliDTO.Emri,
                NrTel = lokaliDTO.NrTel,
                Qyteti = lokaliDTO.Qyteti,
                Adresa = lokaliDTO.Adresa,
                BiznesiId = lokaliDTO.BiznesiId
            };

            _context.Lokali.Add(Lokali);
            await _context.SaveChangesAsync();

            return Ok(lokaliDTO);
        }*/

        [HttpPut("updateUser")]
        public async Task<ActionResult> UpdateUser(int id, UserControllerDto userDto)
        {
            var dbUseri = await _context.Useri.FindAsync(id);
            if (dbUseri == null)
                return NotFound("Useri me kete ID nuk ekziston!");

            if (!userDto.Emri.Trim().Equals(""))
                dbUseri.Emri = userDto.Emri;
            if (!userDto.Qyteti.Trim().Equals(""))
                dbUseri.Qyteti = userDto.Qyteti;
            if (!userDto.PhoneNumber.Trim().Equals(""))
                dbUseri.PhoneNumber = userDto.PhoneNumber;
            if (!userDto.RoleName.Trim().Equals(""))
                dbUseri.RoleName = userDto.RoleName;
            if (userDto.LokaliId != 0)
                dbUseri.LokaliId = userDto.LokaliId;
            if (userDto.BiznesiId != 0)
                dbUseri.BiznesiId = userDto.BiznesiId;

            await _context.SaveChangesAsync();

            return Ok("Useri u perditesua me sukses!");
        }

        [HttpDelete("fshijUserin")]
        public async Task<ActionResult> FshijUserin(int id)
        {
            var dbUseri = await _context.Useri.FindAsync(id);
            if (dbUseri == null)
                return NotFound("Ky user nuk ekziston!");

            _context.Useri.Remove(dbUseri);
            await _context.SaveChangesAsync();

            return Ok("Useri u fshi me sukses!");
        }
    }
}
