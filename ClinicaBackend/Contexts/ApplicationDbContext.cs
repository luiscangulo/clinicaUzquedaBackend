using ClinicaBackend.Models;
using Microsoft.EntityFrameworkCore;


namespace ClinicaBackend.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Alergia> Alergia { get; set; }
        public DbSet<Cita> Cita { get; set; }
        public DbSet<CitaPaciente> CitaPaciente { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Enfermedad> Enfermedad { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<EspecialidadDoctor> EspecialidadDoctor { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<Medicacion> Medicacion { get; set; }
        public DbSet<MedicacionRecetario> MedicacionRecetario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<PacienteAlergia> PacienteAlergia { get; set; }
        public DbSet<PacienteEnfermedad> PacienteEnfermedad { get; set; }
        public DbSet<PacienteMedicacion> PacienteMedicacion { get; set; }
        public DbSet<PacienteTratamiento> PacienteTratamiento { get; set; }
        public DbSet<Recetario> Recetario { get; set; }
        public DbSet<Tratamiento> Tratamiento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Rol> Rol { get; set; }

    }
}
