
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
    public class EspecialidadController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public EspecialidadController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<EspecialidadController>
        [HttpGet]
        public IEnumerable<Especialidad> Get()
        {
            return context.Especialidad as IEnumerable<Especialidad>;
        }

        // GET api/<EspecialidadController>/5
        [HttpGet("{id}")]
        public Especialidad Get(long id)
        {
            var especialidad = context.Especialidad.Find(id);

            return especialidad;
        }

        // POST api/<EspecialidadController>
        [HttpPost]
        public ActionResult Post([FromBody] Especialidad especialidad)
        {
            try
            {
                context.Especialidad.Add(especialidad);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EspecialidadController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Especialidad especialidad)
        {
            if (especialidad.id == id)
            {
                context.Entry(especialidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<EspecialidadController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var especialidad = context.Especialidad.Find(id);
            if (especialidad != null)
            {
                context.Especialidad.Remove(especialidad);
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
