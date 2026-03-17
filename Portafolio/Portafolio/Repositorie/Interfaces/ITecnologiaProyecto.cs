using Portafolio.Model;

namespace Portafolio.Repositorie.Interfaces
{
    public interface ITecnologiaProyecto
    {
        Task<List<TecnologiaProyecto>> GetTecnologiaProyecto();
        Task<bool> PostTecnologiaProyecto(TecnologiaProyecto tp);
        Task<bool> PutTecnologiaProyecto(TecnologiaProyecto tp);
        Task<bool> DeleteTecnologiaProyecto(int id);
    }
}
