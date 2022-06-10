using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaBackend.Models
{
    public class EspecialidadDoctor
    {
        [Key]
        public long id { get; set; }
        public string estado { get; set; }
        [ForeignKey("Doctorid")]
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("Especialidadid")]
        public virtual Especialidad Especialidad { get; set; }
    }
}
