using System.Text.Json.Serialization;

namespace Portafolio.Model
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string UrlGitHub { get; set; }
        public string? UrlDemo { get; set; }
        public int ImgId { get; set; }

        [JsonIgnore]
        public Imagen? Imagen { get; set; }
        [JsonIgnore]
        public List<TecnologiaProyecto>? TecnologiaProyecto { get; set; } = new();
    }
}
