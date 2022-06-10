using System.ComponentModel.DataAnnotations;

namespace ClinicaBackend.Models
{
    public class Cita
    {
        [Key]
        public long id { get; set; }
        public string tipoCita { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
    }
}
