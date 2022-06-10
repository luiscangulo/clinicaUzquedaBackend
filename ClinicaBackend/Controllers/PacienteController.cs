
using ClinicaBackend.Contexts;
using ClinicaBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaBackend.Controllers
{
    //[EnableCors("Mycors")]
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    
    public class PacienteController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PacienteController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<PacienteController>
        [HttpGet]
        public IEnumerable<Paciente> Get()
        {
            return context.Paciente as IEnumerable<Paciente>;
        }

        // GET api/<PacienteController>/5
        [HttpGet("{id}")]
        public Paciente Get(long id)
        {
            var paciente = context.Paciente.Find(id);

            return paciente;
        }

        // POST api/<PacienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Paciente paciente)
        {
            try
            {
                context.Paciente.Add(paciente);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PacienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Paciente paciente)
        {
            if (paciente.id == id)
            {
                context.Entry(paciente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
        // DELETE api/<PacienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var paciente = context.Paciente.Find(id);
            if(paciente != null)
            {
                context.Paciente.Remove(paciente);
                context.SaveChanges();
                return Ok();
    }
            else
            {
                return BadRequest();
}
        }


        // DELETE api/<BanPaciente>/
        [HttpPut("Baneado/{id}")]
        public ActionResult Ban(long id)
        {
            var paciente = context.Paciente
                .Find(id);
            if (paciente.id == id)
            {
                paciente.estado = "Baneado";
                context.Entry(paciente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
