using Portafolio.Context;
using Portafolio.Model;
using Microsoft.EntityFrameworkCore;
using Portafolio.Repositorie.Interfaces;

namespace Portafolio.Repositorie
{
    public class ProyectoRepositorie : IProyecto
    {
        private readonly ContextDB _context;

        public ProyectoRepositorie(ContextDB context)
        {
            _context = context;
        }

        public async Task<List<Proyecto>> GetProyectos()
        {
            var data = await _context.Proyecto.ToListAsync();
            return data;
        }

        public async Task<bool> PostProyecto(Proyecto proye)
        {
            await _context.Proyecto.AddAsync(proye);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PutProyecto(Proyecto proye)
        {
            _context.Proyecto.Update(proye);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyecto.FindAsync(id);
            if (proyecto == null) return false;

            _context.Proyecto.Remove(proyecto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
