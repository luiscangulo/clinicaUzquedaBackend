using System.ComponentModel.DataAnnotations;
using System;

namespace ClinicaBackend.Models
{
    public class Paciente
    {
        [Key]
        public long id {  get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string ci { get; set; }
        public string celular {  get; set; }
        public string telefono {  get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string estado { get; set; }
    }
}
