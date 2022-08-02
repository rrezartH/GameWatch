﻿using GameWatchAPI.Data;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiznesiKonzolaController : ControllerBase
    {
        private readonly GameWatchDBContext _context;
        public BiznesiKonzolaController(GameWatchDBContext context)
        {
            _context = context;
        }

        [HttpGet("getBiznesiKonzola")]
        public async Task<ActionResult<List<BiznesiKonzola>>> GetBiznesiKonzola()
        {
            return Ok(await _context.BiznesiKonzola.ToListAsync());
        }

        [HttpGet("getBiznesiKonzolaById")]
        public async Task<ActionResult<BiznesiKonzola>> GetBiznesiKonzolaById(int id)
        {
            var dbBiznesiKonzola = await _context.BiznesiKonzola.FindAsync(id);
            if (dbBiznesiKonzola == null)
                return NotFound("Kjo konzole nuk ekziton ne kete biznes.");

            return Ok(dbBiznesiKonzola);
        }

        [HttpPost("shtoBiznesiKonzola")]
        public async Task<ActionResult<BiznesiKonzolaDTO>> ShtoBiznes(BiznesiKonzolaDTO biznesiKonzolaDTO)
        {
            if (biznesiKonzolaDTO == null)
                return BadRequest("Nuk mund te shtoni biznesKonsole te zbrazet!");

            var biznesiKonsola = new BiznesiKonzola
            {
                Emri = biznesiKonzolaDTO.Emri,
                KonzolaId = biznesiKonzolaDTO.KonzolaId,
                LokaliId = biznesiKonzolaDTO.LokaliId
            };

            _context.BiznesiKonzola.Add(biznesiKonsola);
            await _context.SaveChangesAsync();

            return Ok(biznesiKonzolaDTO);
        }

        [HttpPut("updateBiznesiKonzola")]
        public async Task<ActionResult> UpdateBiznesiKonzola(int id, BiznesiKonzolaDTO biznesiKonzolaDTO)
        {
            var dbBiznesiKonzola = await _context.BiznesiKonzola.FindAsync(id);
            if (dbBiznesiKonzola == null)
                return NotFound("BiznesKonzola me kete ID nuk ekziston!");

            if (!biznesiKonzolaDTO.Emri.Trim().Equals(""))
                dbBiznesiKonzola.Emri = biznesiKonzolaDTO.Emri;
            if (biznesiKonzolaDTO.KonzolaId != 0)
                dbBiznesiKonzola.KonzolaId = biznesiKonzolaDTO.KonzolaId;
            if (biznesiKonzolaDTO.LokaliId != 0)
                dbBiznesiKonzola.LokaliId = biznesiKonzolaDTO.LokaliId;

            await _context.SaveChangesAsync();

            return Ok("BiznesKonzola u perditesua me sukses!");
        }

        [HttpDelete("fshijBiznesiKonzola")]
        public async Task<ActionResult> FshijBiznesiKonzola(int id)
        {
            var dbBiznesiKonzola = await _context.BiznesiKonzola.FindAsync(id);
            if (dbBiznesiKonzola == null)
                return NotFound("BiznesiKonzola me kete ID nuk ekziston!");

            _context.BiznesiKonzola.Remove(dbBiznesiKonzola);
            await _context.SaveChangesAsync();

            return Ok("BiznesiKonzola u fshi me sukses!");
        }
    }
}