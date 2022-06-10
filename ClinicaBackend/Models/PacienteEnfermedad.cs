using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaBackend.Models
{
    public class PacienteEnfermedad
    {
        [Key]
        public long id { get; set; }
        public string estado { get; set; }
        [ForeignKey("Enfermedadid")]
        public virtual Enfermedad Enfermedad { get; set; }
        [ForeignKey("Pacienteid")]
        public virtual Paciente Paciente { get; set; }
    }
}
