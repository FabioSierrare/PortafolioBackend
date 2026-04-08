using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Portafolio.Repositorie.Interfaces;

namespace Portafolio.Repositorie
{
    public class CloudinaryRepositorie : ICloudy
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryRepositorie(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        public async Task<string> GuardarImagen(IFormFile file, string folder)
        {
            await using var stream = file.OpenReadStream();
            Console.WriteLine(_cloudinary.Api.Account.Cloud);
            Console.WriteLine(_cloudinary.Api.Account.ApiKey);
            Console.WriteLine(_cloudinary.Api.Account.ApiSecret);

            var parametros =new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = folder
            };

            var resultado = await _cloudinary.UploadAsync(parametros);

            if(resultado.Error != null)
            {
                throw new Exception("Error no se pudo subir la imagen");
            }

            return resultado.SecureUrl.ToString();
        }
    }
}
