using Portafolio.Model;

namespace Portafolio.Repositorie.Interfaces
{
    public interface ITecnologia
    {
        Task<List<Tecnologia>> GetTecnologia();
        Task<bool> PostTecnologia(Tecnologia tecn);
        Task<bool> PutTecnologia(Tecnologia tecn);
        Task<bool> DeleteTecnologia(int id);
    }
}
