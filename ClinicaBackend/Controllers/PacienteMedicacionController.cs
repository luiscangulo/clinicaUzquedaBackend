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
    public class PacienteMedicacionController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PacienteMedicacionController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<PacienteMedicacionController>
        [HttpGet]
        public IEnumerable<PacienteMedicacion> Get()
        {
            var pacientemedicacion = context.PacienteMedicacion.Include(i => i.Paciente);
            return pacientemedicacion as IEnumerable<PacienteMedicacion>;
        }

        // GET api/<PacienteMedicacionController>/5
        [HttpGet("{id}")]
        public PacienteMedicacion Get(long id)
        {
            var pacientemedicacion = context.PacienteMedicacion.Find(id);

            return pacientemedicacion;
        }

        // POST api/<PacienteMedicacionController>
        [HttpPost]
        public ActionResult Post([FromBody] PacienteMedicacion pacientemedicacion)
        {
            try
            {
                context.PacienteMedicacion.Add(pacientemedicacion);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PacienteMedicacionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] PacienteMedicacion pacientemedicacion)
        {
            if (pacientemedicacion.id == id)
            {
                context.Entry(pacientemedicacion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<PacienteMedicacionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var pacientemedicacion = context.PacienteMedicacion.Find(id);
            if (pacientemedicacion != null)
            {
                context.PacienteMedicacion.Remove(pacientemedicacion);
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