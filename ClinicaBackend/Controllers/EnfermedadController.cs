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
    public class EnfermedadController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public EnfermedadController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<EnfermedadController>
        [HttpGet]
        public IEnumerable<Enfermedad> Get()
        {
            return context.Enfermedad as IEnumerable<Enfermedad>;
        }

        // GET api/<EnfermedadController>/5
        [HttpGet("{id}")]
        public Enfermedad Get(long id)
        {
            var enfermedad = context.Enfermedad.Find(id);

            return enfermedad;
        }

        // POST api/<EnfermedadController>
        [HttpPost]
        public ActionResult Post([FromBody] Enfermedad enfermedad)
        {
            try
            {
                context.Enfermedad.Add(enfermedad);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EnfermedadController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Enfermedad enfermedad)
        {
            if (enfermedad.id == id)
            {
                context.Entry(enfermedad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<EnfermedadController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var enfermedad = context.Enfermedad.Find(id);
            if (enfermedad != null)
            {
                context.Enfermedad.Remove(enfermedad);
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