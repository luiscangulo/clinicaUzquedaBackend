using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaBackend.Models
{
    public class Usuario
    {
        [Key]
        public long id { get; set; }
        public string userName { get; set; }
        public string PasswordHash {  get; set; }
        public string PasswordSalt {  get; set; }
        public int rol { get; set; }

        public string cedula { get; set; }

        [ForeignKey("Doctorid")]
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("Pacienteid")]
        public virtual Paciente Paciente { get; set; }
    }
}
