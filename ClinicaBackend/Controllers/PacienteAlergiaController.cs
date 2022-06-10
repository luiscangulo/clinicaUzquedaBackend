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
    public class PacienteAlergiaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PacienteAlergiaController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<PacienteAlergiaController>
        [HttpGet]
        public IEnumerable<PacienteAlergia> Get()
        {
            var pacientealergia = context.PacienteAlergia.Include(i => i.Paciente).Include(j => j.Alergia);
            return pacientealergia as IEnumerable<PacienteAlergia>;
        }

        // GET api/<PacienteAlergiaController>/5
        [HttpGet("{id}")]
        public PacienteAlergia Get(long id)
        {
            var pacientealergia = context.PacienteAlergia.Find(id);

            return pacientealergia;
        }

        // POST api/<PacienteAlergiaController>
        [HttpPost]
        public ActionResult Post([FromBody] PacienteAlergia pacientealergia)
        {
            try
            {
                context.PacienteAlergia.Add(pacientealergia);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PacienteAlergiaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] PacienteAlergia pacientealergia)
        {
            if (pacientealergia.id == id)
            {
                context.Entry(pacientealergia).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<PacienteAlergiaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var pacientealergia = context.PacienteAlergia.Find(id);
            if (pacientealergia != null)
            {
                context.PacienteAlergia.Remove(pacientealergia);
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