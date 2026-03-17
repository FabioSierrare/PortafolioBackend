using Portafolio.Model;
namespace Portafolio.Repositorie.Interfaces
{
    public interface IImagen
    {
        Task<List<Imagen>> GetImagenes();
        Task<bool> PostImagen(Imagen img);
        Task<bool> PutImagen(Imagen img);
        Task<bool> DeleteImagen(int id);
    }
}
