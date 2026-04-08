using Portafolio.Model;
using Portafolio.Model.ProyectModel;

namespace Portafolio.Repositorie.Interfaces
{
    public interface IProyecto
    {
        Task<List<Proyecto>> GetProyectos();
        Task<bool> PostProyecto(Proyecto proyecto);
        Task<bool> PutProyecto(Proyecto proyecto);
        Task<bool> DeleteProyecto(int id);
        Task<bool> PostProyecto(ProyectoTecPro proyecto);
        Task<List<ProyectoCompleto>> GetProyectosInfo();
        Task<List<ProyectoCompleto>> GetProyectosInfolimit();
    }
}
