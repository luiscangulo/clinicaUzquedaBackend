using System.ComponentModel.DataAnnotations;

namespace ClinicaBackend.Models
{
    public class Alergia
    {
        [Key]
        public long id { get; set; }
        public string nombreAlergia { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
    }
}
