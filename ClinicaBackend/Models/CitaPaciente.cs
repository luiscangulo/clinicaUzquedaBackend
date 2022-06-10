using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaBackend.Models
{
    public class CitaPaciente
    {
        [Key]
        public long id { get; set; }
        public DateTime fechaCita { get; set; }
        public int montoPagado { get; set; }
        public string tipoMoneda { get; set; }
        public string estado { get; set; }

        [ForeignKey("Pacienteid")]
        public virtual Paciente Paciente { get; set; }
        [ForeignKey("Doctorid")]
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("Citaid")]
        public virtual Cita Cita { get; set; }
    }
}
