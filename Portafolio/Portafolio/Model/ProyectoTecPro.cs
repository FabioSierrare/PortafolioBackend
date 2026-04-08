using System.ComponentModel.DataAnnotations;

namespace Portafolio.Model
{
    public class ProyectoTecPro
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string UrlGitHub { get; set; }
        public string? UrlDemo { get; set; }
        [Required]
        public IFormFile Imagen { get; set; }
        [Required]
        [MinLength(1)]
        public List<int> TecnologiaId { get; set; }
    }
}
