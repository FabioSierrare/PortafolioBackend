using Portafolio.Repositorie.Interfaces;
using Portafolio.Context;
using Portafolio.Model;
using Microsoft.EntityFrameworkCore;

namespace Portafolio.Repositorie
{
    public class TecnologiaRepositorie : ITecnologia
    {
        private readonly ContextDB _context;
        public TecnologiaRepositorie(ContextDB context)
        {
            _context = context;
        }
        public async Task<List<Tecnologia>> GetTecnologia()
        {
            var data = await _context.Tecnologia.ToListAsync();
            return data;
        }

        public async Task<bool> PostTecnologia(Tecnologia tec)
        {
            await _context.Tecnologia.AddAsync(tec);
            var res = _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PutTecnologia(Tecnologia tec)
        {
            _context.Tecnologia.Update(tec);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTecnologia(int id)
        {
            var tec = await _context.Tecnologia.FindAsync(id);
            if (tec == null) return false;

            _context.Tecnologia.Remove(tec);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
