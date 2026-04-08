using System.Text.Json.Serialization;

namespace Portafolio.Model
{
    public class Tecnologia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ImgId { get; set; }
        [JsonIgnore]
        public Imagen? Imagen { get; set; }
        [JsonIgnore]
        public List<TecnologiaProyecto> TecnologiaProyectos { get; set; }

    }
}
