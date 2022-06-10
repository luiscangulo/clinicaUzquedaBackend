using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaBackend.Models
{
    public class Medicacion
    {
        [Key]
        public long id { get; set; }
        public string prescripcion { get; set; }
        public string estado { get; set; }
        [ForeignKey("PacienteMedicacionid")]
        public virtual PacienteMedicacion PacienteMedicacion { get; set; }
    }
}
