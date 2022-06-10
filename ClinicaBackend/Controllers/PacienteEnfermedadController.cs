using ClinicaBackend.Contexts;
using ClinicaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PacienteEnfermedadController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PacienteEnfermedadController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<PacienteEnfermedadController>
        [HttpGet]
        public IEnumerable<PacienteEnfermedad> Get()
        {
            var pacienteenfermedad = context.PacienteEnfermedad.Include(i => i.Enfermedad).Include(j => j.Paciente);
            return pacienteenfermedad as IEnumerable<PacienteEnfermedad>;
        }

        // GET api/<PacienteEnfermedadController>/5
        [HttpGet("{id}")]
        public PacienteEnfermedad Get(long id)
        {
            var pacienteenfermedad = context.PacienteEnfermedad.Find(id);

            return pacienteenfermedad;
        }

        // POST api/<PacienteEnfermedadController>
        [HttpPost]
        public ActionResult Post([FromBody] PacienteEnfermedad pacienteenfermedad)
        {
            try
            {
                context.PacienteEnfermedad.Add(pacienteenfermedad);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PacienteEnfermedadController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] PacienteEnfermedad pacienteenfermedad)
        {
            if (pacienteenfermedad.id == id)
            {
                context.Entry(pacienteenfermedad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<PacienteEnfermedadController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var pacienteenfermedad = context.PacienteEnfermedad.Find(id);
            if (pacienteenfermedad != null)
            {
                context.PacienteEnfermedad.Remove(pacienteenfermedad);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
