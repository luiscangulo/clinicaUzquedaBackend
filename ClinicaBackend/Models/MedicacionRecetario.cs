using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaBackend.Models
{
    public class MedicacionRecetario
    {
        [Key]
        public long id { get; set; }
        public int nroMedicamentos { get; set; }
        public string estado { get; set; }
        [ForeignKey("Recetarioid")]
        public virtual Recetario Recetario { get; set; }
        [ForeignKey("Medicacionid")]
        public virtual Medicacion Medicacion { get; set; }
    }
}
