using System.ComponentModel.DataAnnotations;

namespace ClinicaBackend.Models
{
    public class Especialidad
    {
        [Key]
        public long id { get; set; }
        public string nombreEspecialidad { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
    }
}
