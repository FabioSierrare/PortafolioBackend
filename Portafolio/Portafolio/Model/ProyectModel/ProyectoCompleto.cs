using Portafolio.Model.TecnologiaModel;

namespace Portafolio.Model.ProyectModel
{
    public class ProyectoCompleto
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string UrlGitHub { get; set; }
        public string? UrlDemo { get; set; }
        public string UrlImagen { get; set; }
        public List<TecnologiaCompleto> Tecnoinfo { get; set; } 
    }
}
