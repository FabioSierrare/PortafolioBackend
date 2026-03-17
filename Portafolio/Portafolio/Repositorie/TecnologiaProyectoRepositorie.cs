using Portafolio.Repositorie.Interfaces;
using Portafolio.Context;
using Portafolio.Model;
using Microsoft.EntityFrameworkCore;

namespace Portafolio.Repositorie
{
    public class TecnologiaProyectoRepositorie : ITecnologiaProyecto
    {
        private readonly ContextDB _context;

        public TecnologiaProyectoRepositorie(ContextDB context)
        {
            _context = context;
        }

        public async Task<List<TecnologiaProyecto>> GetTecnologiaProyecto()
        {
            var data = await _context.TecnologiaProyecto.ToListAsync();
            return data;
        }

        public async Task<bool> PostTecnologiaProyecto(TecnologiaProyecto tec)
        {
            await _context.TecnologiaProyecto.AddAsync(tec);
            var res = _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PutTecnologiaProyecto(TecnologiaProyecto tec)
        {
            _context.TecnologiaProyecto.Update(tec);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTecnologiaProyecto(int id)
        {
            var tec = await _context.TecnologiaProyecto.FindAsync(id);
            if (tec == null) return false;

            _context.TecnologiaProyecto.Remove(tec);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
