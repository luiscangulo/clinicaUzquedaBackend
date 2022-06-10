using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaBackend.Models
{
    public class PacienteMedicacion
    {
        [Key]
        public long id { get; set; }
        public string estado { get; set; }
        [ForeignKey("Pacienteid")]
        public virtual Paciente Paciente { get; set; }
    }
}
