using System.ComponentModel.DataAnnotations;

namespace ClinicaBackend.Models
{
    public class Doctor
    {
        [Key]
        public long id { get; set; }
        public string ciDoctor { get; set; }
        public string nombreDoctor { get; set; }
        public string apellidosDoctor { get; set; }
        public string celularDoctor { get; set; }
        public int cupoCitas { get; set; }
        public string estado { get; set; }
    }
}
