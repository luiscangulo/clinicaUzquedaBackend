using System.ComponentModel.DataAnnotations;

namespace ClinicaBackend.Models
{
    public class Recetario
    {
        [Key]
        public long id { get; set; }
        public string nombreMedicamento { get; set; }
        public string estado { get; set; }
    }
}
