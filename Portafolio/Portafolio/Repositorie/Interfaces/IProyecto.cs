using Portafolio.Model;

namespace Portafolio.Repositorie.Interfaces
{
    public interface IProyecto
    {
        Task<List<Proyecto>> GetProyectos();
        Task<bool> PostProyecto(Proyecto proyecto);
        Task<bool> PutProyecto(Proyecto proyecto);
        Task<bool> DeleteProyecto(int id);
    }
}
