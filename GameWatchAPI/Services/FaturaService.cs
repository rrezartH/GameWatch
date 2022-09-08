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

        public FaturaService(GameWatchDBContext context, CmimorjaService cmimorjaService)
        {
            _context = context;
            _cmimorjaService = cmimorjaService;
        }

        public async Task AddFaturaAsync(FaturaDTO faturaDTO)
        {
            var cmimi = await _cmimorjaService.GetCmimorjaByLokaliAndLojtaret(faturaDTO.LokaliId, faturaDTO.NrLojtareve);
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

            fatura.MbarimiLojes = fatura.Oret != 0 && fatura.Oret != null ? DateTime.Now.AddMinutes((double)fatura.Oret * 60).ToString() : null;

            var dbBiznesiKonzola = await _context.BiznesiKonzola.FindAsync(faturaDTO.BiznesiKonzola);
            dbBiznesiKonzola.Statusi = true;
            _context.Fatura.Add(fatura);

            await _context.SaveChangesAsync();
        }

        public async Task FinalizoFaturaAsync(int id)
        {
            var fatura = await _context.Fatura.FindAsync(id);

            var cmimi = await _cmimorjaService.GetCmimorjaByLokaliAndLojtaret(fatura.LokaliId, fatura.NrLojtareve);

            fatura.Closed = true;

            if (fatura.CmimiTotal == 0 || fatura.Oret == 0)
            {
                TimeSpan oret = DateTime.Now - DateTime.Parse(fatura.FillimiLojes);

                fatura.MbarimiLojes = DateTime.Now.ToString();
                fatura.Oret = (decimal)oret.TotalHours;
                fatura.CmimiTotal = cmimi * (decimal)oret.TotalHours;
            }

            var konzola = await _context.BiznesiKonzola.FindAsync(fatura.BiznesiKonzola);
            konzola.Statusi = false;

            await _context.SaveChangesAsync();
        }

        //kjo metode perdoret kur nuk dihen oret, cmimi dhe mbarimi i lojes
        public async Task<PreviewFaturaDTO> GetPreviewFaturaAsync(Fatura fatura)
        {
            var cmimi = await _cmimorjaService.GetCmimorjaByLokaliAndLojtaret(fatura.LokaliId, fatura.NrLojtareve);

            var previewFatura = new PreviewFaturaDTO()
            {
                Oret = Math.Round((decimal)(DateTime.Now - DateTime.Parse(fatura.FillimiLojes)).TotalHours, 2),
                MbarimiLojes = DateTime.Now.ToString(),
            };

            previewFatura.CmimiTotal = previewFatura.Oret ?? 0.0M * cmimi;

            return previewFatura;
        }

        public async Task UpdateFaturaAsync(Fatura dbFatura, UpdateFaturaDTO faturaDTO)
        {
            var cmimi = await _cmimorjaService.GetCmimorjaByLokaliAndLojtaret(dbFatura.LokaliId, dbFatura.NrLojtareve);

            if (faturaDTO.Oret != 0)
            {
                dbFatura.Oret = faturaDTO.Oret ?? 0;
                dbFatura.CmimiTotal = cmimi * dbFatura.Oret ?? 0.0M;
            }
            if (faturaDTO.CmimiTotal != 0)
            {
                dbFatura.CmimiTotal = faturaDTO.CmimiTotal ?? 0.0M;
                dbFatura.Oret = dbFatura.CmimiTotal / cmimi;
            }

            dbFatura.MbarimiLojes = DateTime.Parse(dbFatura.FillimiLojes).AddHours((double)dbFatura.Oret!).ToString();
                
            await _context.SaveChangesAsync();         
        }
    }
}
