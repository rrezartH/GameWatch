﻿using GameWatchAPI.Data;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameWatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LokaliController : ControllerBase
    {
        private readonly GameWatchDBContext _context;

        public LokaliController(GameWatchDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetLokalet")]
        public async Task<ActionResult<List<Lokali>>> GetLokalet()
        {
            return Ok(await _context.Lokali.ToListAsync());
        }

        [HttpGet("GetLokalin")]
        public async Task<ActionResult<Lokali>> GetLokali(int id)
        {
            var dbLokali = await _context.Lokali.FindAsync(id);
            if (dbLokali == null)
                return NotFound("Ky lokal nuk ekziston!");

            return Ok(dbLokali);
        }

        [HttpGet("GetLokalinByBiznesId")]
        public async Task<ActionResult<List<Lokali>>> GetLokalinByBiznesId(int biznesID)
        {
            List<Lokali> Lokalet = await _context.Lokali.Where(l => l.BiznesiId == biznesID).ToListAsync();

            if (!Lokalet.Any())
                return NotFound("Nuk u gjet asnje lokal me kete biznes ID!");

            return Ok(Lokalet);
        }

        [HttpPost("ShtoLokalin")]
        public async Task<ActionResult<Lokali>> ShtoLokali(LokaliDTO lokaliDTO)
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
        }

        [HttpPut("UpdateLokalin")]
        public async Task<ActionResult> UpdateLokalin(int id, LokaliDTO lokaliDTO)
        {
            var dbLokali = await _context.Lokali.FindAsync(id);
            if (dbLokali == null)
                return NotFound("Lokali me kete ID nuk ekziston!");

            if (!lokaliDTO.Emri.Trim().Equals(""))
                dbLokali.Emri = lokaliDTO.Emri;
            if (!lokaliDTO.NrTel.Trim().Equals(""))
                dbLokali.NrTel = lokaliDTO.NrTel;
            if (!lokaliDTO.Qyteti.Trim().Equals(""))
                dbLokali.Qyteti = lokaliDTO.Qyteti;
            if (!lokaliDTO.Adresa.Trim().Equals(""))
                dbLokali.Adresa = lokaliDTO.Adresa;
            if(lokaliDTO.BiznesiId != 0)
                dbLokali.BiznesiId = lokaliDTO.BiznesiId;

            await _context.SaveChangesAsync();

            return Ok("Lokali u perditesua me sukses!");
        }

        [HttpDelete("FshijLokalin")]
        public async Task<ActionResult> FshijLokalin(int id)
        {
            var dbLokali = await _context.Lokali.FindAsync(id);
            if (dbLokali == null)
                return NotFound("Ky lokal nuk ekziston!");

            _context.Lokali.Remove(dbLokali);
            await _context.SaveChangesAsync();

            return Ok("Lokali u fshi me sukses!");
        }
    }
}