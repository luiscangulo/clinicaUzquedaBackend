
using ClinicaBackend.Contexts;
using ClinicaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CitaPacienteController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CitaPacienteController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<CitaPacienteController>
        [HttpGet]
        public IEnumerable<CitaPaciente> Get()
        {
            var citaspaciente = context.CitaPaciente.Include(i => i.Doctor).Include(j => j.Paciente).Include(k => k.Cita);
            return citaspaciente as IEnumerable<CitaPaciente>;
        }

        // GET api/<CitaPacienteController>/5
        [HttpGet("{id}")]
        public CitaPaciente Get(long id)
        {
            var citapaciente = context.CitaPaciente.Find(id);

            return citapaciente;
        }

        // POST api/<CitaPacienteController>
        [HttpPost]
        public ActionResult Post([FromBody] CitaPaciente citapaciente)
        {
            try
            {
                context.CitaPaciente.Add(citapaciente);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CitaPacienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] CitaPaciente citapaciente)
        {
            if (citapaciente.id == id)
            {
                context.Entry(citapaciente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<CitaPacienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var citapaciente = context.CitaPaciente.Find(id);
            if (citapaciente != null)
            {
                context.CitaPaciente.Remove(citapaciente);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("ClientesMorosos")]
        //[Route("[controller]/ClientesMorosos")]
        public IEnumerable<CitaPaciente> GetDefaulters()
        {
            //var citaspaciente = context.CitaPaciente as IEnumerable<CitaPaciente>;
            var citaspaciente = context.CitaPaciente.Include(i => i.Doctor).Include(j => j.Paciente).Include(k => k.Cita);
            return citaspaciente.Where(e => e.estado == "Deuda") as IEnumerable<CitaPaciente>;

        }



        // GET api/<CitaPacienteController>/5
        [HttpGet("HistorialCitas/{id}")]
        public IEnumerable<CitaPaciente>  GetHistorialCitas(long id)
        {
            var pacientecita = context.CitaPaciente.Where(j => j.Paciente.id == id)
                                                    .Include(i => i.Doctor)
                                                    .Include(u => u.Cita);

            return pacientecita;
        }




        // GET api/<CitaPaciente/Pendientes>/5
        [HttpGet("AppointmentsPaciente/{id}")]
        public IEnumerable<CitaPaciente> GetCAppointmentsPatient(long id)
        {
            var appointments = context.CitaPaciente.Where(p => p.Paciente.id == id && p.estado == "Active")
                                                    .Include(i => i.Doctor)
                                                    .Include(u => u.Cita);

            return appointments;
        }



        // GET api/<CitaPaciente/AppointmentsDoctor/{id}
        [HttpGet("AppointmentsDoctor/{id}")]
        public IEnumerable<CitaPaciente> GetCAppointmentsDoctor(long id)
        {
            var appointments = context.CitaPaciente.Where(p => p.Doctor.id == id && p.estado == "Active")
                                                    .Include(i => i.Paciente)
                                                    .Include(u => u.Cita);

            return appointments;
        }
    }
}