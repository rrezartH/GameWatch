using GameWatchAPI.Data;

namespace GameWatchAPI.Services
{
    public class CmimorjaService
    {
        private readonly GameWatchDBContext _context;

        public CmimorjaService(GameWatchDBContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetCmimorjaByLokaliAndLojtaret(int lokaliId, int nrLojtareve)
        {
            int biznesiId = (await _context.Lokali.FirstOrDefaultAsync(f => f.Id == lokaliId))!.BiznesiId;

            var dbCmimorja = await _context.Cmimorja.FirstOrDefaultAsync(c => c.BiznesiId == biznesiId && c.NrLojtareve == nrLojtareve);
            return dbCmimorja.Cmimi;
        }
    }
}
