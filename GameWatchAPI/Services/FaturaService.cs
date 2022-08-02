using GameWatchAPI.Controllers;
using GameWatchAPI.Data;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;
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
            var cmimi = await _cmimorjaService.GetCmimorjaByLokali(faturaDTO.LokaliId, faturaDTO.NrLojtareve);
            Fatura fatura = new()
            {
                Oret = faturaDTO.CmimiTotal != 0 ? faturaDTO.CmimiTotal / cmimi : faturaDTO.Oret,
                NrLojtareve = faturaDTO.NrLojtareve,
                BiznesiKonzola = faturaDTO.BiznesiKonzola,
                VideoLojaId = faturaDTO.VideoLojaId,
                LokaliId = faturaDTO.LokaliId,
                CmimiTotal = faturaDTO.CmimiTotal != 0 ? faturaDTO.CmimiTotal : (decimal)(cmimi * faturaDTO.Oret)!
            };

            fatura.MbarimiLojes = fatura.Oret != 0 ? DateTime.Now.AddMinutes((double)fatura.Oret * 60).ToString() : null;

            _context.Fatura.Add(fatura);

            await _context.SaveChangesAsync();
        }
    }
}
