using Portafolio.Repositorie.Interfaces;
using Portafolio.Context;
using Portafolio.Model;
using Microsoft.EntityFrameworkCore;

namespace Portafolio.Repositorie
{
    public class TecnologiaRepositorie : ITecnologia
    {
        private readonly ContextDB _context;
        private readonly ICloudy _cloudinary;
        public TecnologiaRepositorie(ContextDB context, ICloudy cloudy)
        {
            _context = context;
            _cloudinary = cloudy;
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

        public async Task<bool> PostTecnologia(TecnologiaImagen tec)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var file = tec.Imagen;

                var url = await _cloudinary.GuardarImagen(file, "Tecnologia");

                Imagen img = new Imagen
                {
                    Url = url
                };

                Tecnologia tecno = new Tecnologia
                {
                    Nombre = tec.Nombre,
                    Imagen = img
                };

                _context.Tecnologia.Add(tecno);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine(ex.Message);
                throw new Exception("Error si señor");
            }
        }
    }
}
