using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaBackend.Models
{
    public class PacienteAlergia
    {
        [Key]
        public long id { get; set; }
        public string estado { get; set; }
        [ForeignKey("Alergiaid")]
        public virtual Alergia Alergia { get; set; }
        [ForeignKey("Pacienteid")]
        public virtual Paciente Paciente { get; set; }
    }
}
