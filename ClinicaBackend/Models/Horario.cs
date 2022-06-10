using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaBackend.Models
{
    public class Horario
    {
        [Key]
        public long id { get; set; }
        public string dia { get; set; }
        public DateTime fechaHora { get; set; }
        public string estado { get; set; }
        public DateTime vigencia { get; set; }
        [ForeignKey("Doctorid")]
        public virtual Doctor Doctor { get; set; }
    }
}
