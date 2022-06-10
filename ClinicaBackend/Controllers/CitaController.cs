
using ClinicaBackend.Contexts;
using ClinicaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CitaController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<CitaController>
        [HttpGet]
        public IEnumerable<Cita> Get()
        {
            return context.Cita as IEnumerable<Cita>;
        }

        // GET api/<CitaController>/5
        [HttpGet("{id}")]
        public Cita Get(long id)
        {
            var cita = context.Cita.Find(id);

            return cita;
        }

        // POST api/<CitaController>
        [HttpPost]
        public ActionResult Post([FromBody] Cita cita)
        {
            try
            {
                context.Cita.Add(cita);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CitaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Cita cita)
        {
            if (cita.id == id)
            {
                context.Entry(cita).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<CitaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var cita = context.Cita.Find(id);
            if (cita != null)
            {
                context.Cita.Remove(cita);
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