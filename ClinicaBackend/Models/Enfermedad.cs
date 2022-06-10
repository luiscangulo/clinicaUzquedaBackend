using System.ComponentModel.DataAnnotations;

namespace ClinicaBackend.Models
{
    public class Enfermedad
    {
        [Key]
        public long id { get; set; }
        public string nombreEnfermedad { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
    }
}
