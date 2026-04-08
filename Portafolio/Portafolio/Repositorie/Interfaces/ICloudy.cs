namespace Portafolio.Repositorie.Interfaces
{
    public interface ICloudy
    {
        Task<string> GuardarImagen(IFormFile file, string folder);
    }
}
