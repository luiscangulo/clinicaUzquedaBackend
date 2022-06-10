using System.ComponentModel.DataAnnotations;

namespace ClinicaBackend.Models
{
    public class Tratamiento
    {
        [Key]
        public long id { get; set; }
        public string tipoTratamiento { get; set; }
        public string estado { get; set; }
    }
}
