using Microsoft.EntityFrameworkCore;
using Portafolio.Repositorie.Interfaces;
using Portafolio.Context;
using Portafolio.Model;

namespace Portafolio.Repositorie
{
    public class ImagenRepositorie : IImagen
    {
        private readonly ContextDB _context;

        public ImagenRepositorie(ContextDB context)
        {
            _context = context;
        }

        public async Task<List<Imagen>> GetImagenes()
        {
            var data = await _context.Imagen.ToListAsync();
            return data;
        }

        public async Task<bool> PostImagen(Imagen img)
        {
            await _context.Imagen.AddAsync(img);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PutImagen(Imagen img)
        {
            _context.Imagen.Update(img);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteImagen(int id)
        {
            var img = await _context.Imagen.FindAsync(id);
            if (img == null) return false;

            _context.Imagen.Remove(img);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
