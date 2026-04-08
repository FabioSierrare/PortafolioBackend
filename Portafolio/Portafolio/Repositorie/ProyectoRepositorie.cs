using Portafolio.Context;
using Portafolio.Model;
using Microsoft.EntityFrameworkCore;
using Portafolio.Repositorie.Interfaces;
using Portafolio.Model.ProyectModel;
using Portafolio.Model.TecnologiaModel;

namespace Portafolio.Repositorie
{
    public class ProyectoRepositorie : IProyecto
    {
        private readonly ContextDB _context;
        private readonly ICloudy _cloudinary;

        public ProyectoRepositorie(ContextDB context, ICloudy cloudinary)
        {
            _context = context;
            _cloudinary = cloudinary;
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

        public async Task<bool> PostProyecto(ProyectoTecPro proye)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var file = proye.Imagen;
                var Url = await _cloudinary.GuardarImagen(file, "Proyectos");
                var img = new Imagen
                {
                    Url = Url
                };

                var Proyecto = new Proyecto
                {
                    Titulo = proye.Titulo,
                    Descripcion = proye.Descripcion,
                    UrlGitHub = proye.UrlGitHub,
                    UrlDemo = proye.UrlDemo,
                    Imagen = img,
                    TecnologiaProyecto = proye.TecnologiaId.Select(id => new TecnologiaProyecto
                    {
                        TecnologiaId = id
                    }).ToList()
                };

                _context.Proyecto.Add(Proyecto);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<List<ProyectoCompleto>> GetProyectosInfo()
        {
            var info = await _context.Proyecto
                .Select(p => new ProyectoCompleto
                {
                    Titulo = p.Titulo,
                    Descripcion = p.Descripcion,
                    UrlGitHub = p.UrlGitHub,
                    UrlDemo = p.UrlDemo,
                    UrlImagen = _context.Imagen.Where(i => i.Id == p.ImgId).Select(i => i.Url).FirstOrDefault(),
                    Tecnoinfo = _context.TecnologiaProyecto.Where(t => t.ProyectoId == p.Id).Select(t => new TecnologiaCompleto
                    {
                        Nombre = t.Tecnologia.Nombre,
                        UrlLogo = _context.Imagen.Where(i => i.Id == t.Tecnologia.ImgId).Select(i => i.Url).FirstOrDefault()
                    }).ToList()
                }).ToListAsync();


            return info;
        }

        public async Task<List<ProyectoCompleto>> GetProyectosInfolimit()
        {
            var info = await _context.Proyecto
            .OrderByDescending(p => p.Id) // Ordena del más nuevo al más viejo
            .Take(5) // Toma solo los últimos 5
            .Select(p => new ProyectoCompleto
            {
                Titulo = p.Titulo,
                Descripcion = p.Descripcion,
                UrlGitHub = p.UrlGitHub,
                UrlDemo = p.UrlDemo,
                UrlImagen = _context.Imagen
                    .Where(i => i.Id == p.ImgId)
                    .Select(i => i.Url)
                    .FirstOrDefault(),
                Tecnoinfo = _context.TecnologiaProyecto
                    .Where(t => t.ProyectoId == p.Id)
                    .Select(t => new TecnologiaCompleto
                    {
                        Nombre = t.Tecnologia.Nombre,
                        UrlLogo = _context.Imagen
                            .Where(i => i.Id == t.Tecnologia.ImgId)
                            .Select(i => i.Url)
                            .FirstOrDefault()
                    }).ToList()
            })
            .ToListAsync();


            return info;
        }
    }
}
