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
    public class RecetarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public RecetarioController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<RecetarioController>
        [HttpGet]
        public IEnumerable<Recetario> Get()
        {
            return context.Recetario as IEnumerable<Recetario>;
        }

        // GET api/<RecetarioController>/5
        [HttpGet("{id}")]
        public Recetario Get(long id)
        {
            var recetario = context.Recetario.Find(id);

            return recetario;
        }

        // POST api/<RecetarioController>
        [HttpPost]
        public ActionResult Post([FromBody] Recetario recetario)
        {
            try
            {
                context.Recetario.Add(recetario);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RecetarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Recetario recetario)
        {
            if (recetario.id == id)
            {
                context.Entry(recetario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<RecetarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var recetario = context.Recetario.Find(id);
            if (recetario != null)
            {
                context.Recetario.Remove(recetario);
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
