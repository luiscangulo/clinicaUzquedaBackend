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
    public class TratamientoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public TratamientoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<TratamientoController>
        [HttpGet]
        public IEnumerable<Tratamiento> Get()
        {
            return context.Tratamiento as IEnumerable<Tratamiento>;
        }

        // GET api/<TratamientoController>/5
        [HttpGet("{id}")]
        public Tratamiento Get(long id)
        {
            var tratamiento = context.Tratamiento.Find(id);

            return tratamiento;
        }

        // POST api/<TratamientoController>
        [HttpPost]
        public ActionResult Post([FromBody] Tratamiento tratamiento)
        {
            try
            {
                context.Tratamiento.Add(tratamiento);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TratamientoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Tratamiento tratamiento)
        {
            if (tratamiento.id == id)
            {
                context.Entry(tratamiento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<TratamientoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var tratamiento = context.Tratamiento.Find(id);
            if (tratamiento != null)
            {
                context.Tratamiento.Remove(tratamiento);
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