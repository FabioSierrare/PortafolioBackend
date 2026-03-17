using Portafolio.Model;

namespace Portafolio.Repositorie.Interfaces
{
    public interface IUsuario
    {
        Task<List<Usuario>> GetUsuario();
        Task<bool> PostUsuario(Usuario user);
        Task<bool> PutUsuario(Usuario user);
        Task<bool> DeleteUsuario(int id);
    }
}
