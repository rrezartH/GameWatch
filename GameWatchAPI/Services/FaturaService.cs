using AutoMapper;
using GameWatchAPI.Controllers;
using GameWatchAPI.Data;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace GameWatchAPI.Services
{
    public class FaturaService
    {
        private readonly GameWatchDBContext _context;
        private readonly CmimorjaService _cmimorjaService;
        private readonly IMapper _mapper;

        public FaturaService(GameWatchDBContext context, CmimorjaService cmimorjaService, IMapper mapper)
        {
            _context = context;
            _cmimorjaService = cmimorjaService;
            _mapper = mapper;
        }

        public async Task AddFaturaAsync(FaturaDTO faturaDTO)
        {
            var cmimi = await _cmimorjaService.GetCmimorjaByLokali(faturaDTO.LokaliId, faturaDTO.NrLojtareve);
            Fatura fatura = new()
            {
                FillimiLojes = DateTime.Now.ToString(),
                Oret = faturaDTO.CmimiTotal != 0 ? faturaDTO.CmimiTotal / cmimi : faturaDTO.Oret,
                NrLojtareve = faturaDTO.NrLojtareve,
                BiznesiKonzola = faturaDTO.BiznesiKonzola,
                VideoLojaId = faturaDTO.VideoLojaId,
                LokaliId = faturaDTO.LokaliId,
                CmimiTotal = faturaDTO.CmimiTotal != 0 ? faturaDTO.CmimiTotal : (decimal)(cmimi * faturaDTO.Oret)!,
                Closed = false,
            };

            fatura.MbarimiLojes = fatura.Oret != 0 ? DateTime.Now.AddMinutes((double)fatura.Oret * 60).ToString() : null;

            var dbBiznesiKonzola = await _context.BiznesiKonzola.FindAsync(faturaDTO.BiznesiKonzola);
            dbBiznesiKonzola.Statusi = true;
            _context.Fatura.Add(fatura);

            await _context.SaveChangesAsync();
        }

        public async Task FinalizoFaturaAsync(int id)
        {
            var fatura = await _context.Fatura.FindAsync(id);

            var cmimi = await _cmimorjaService.GetCmimorjaByLokali(fatura.LokaliId, fatura.NrLojtareve);

            fatura.Closed = true;

            if (fatura.CmimiTotal == 0 || fatura.Oret == 0)
            {
                DateTime fillimi = DateTime.Parse(fatura.FillimiLojes);
                TimeSpan oret = DateTime.Now - fillimi;

                fatura.MbarimiLojes = DateTime.Now.ToString();
                fatura.Oret = (decimal)oret.TotalHours;
                fatura.CmimiTotal = cmimi * (decimal)oret.TotalHours;
            }

            var konzola = await _context.BiznesiKonzola.FindAsync(fatura.BiznesiKonzola);
            konzola.Statusi = false;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateFaturaAsync(int id, FaturaDTO faturaDTO)
        {
            var dbFatura = await _context.Fatura.FindAsync(id);

            _mapper.Map(mappedFatura, fatura);

            if (faturaDTO == null)

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
        }
    }
}
