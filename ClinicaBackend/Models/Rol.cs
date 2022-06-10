using System.ComponentModel.DataAnnotations;

namespace ClinicaBackend.Models
{
    public class Rol
    {

        [Key]
        public long id { get; set; }
        public string nombre { get; set; }
        public string cedula { get; set; }
    }
}
