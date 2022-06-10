
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
    public class AlergiaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AlergiaController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<AlergiaController>
        [HttpGet]
        public IEnumerable<Alergia> Get()
        {
            return context.Alergia as IEnumerable<Alergia>;
        }

        // GET api/<AlergiaController>/5
        [HttpGet("{id}")]
        public Alergia Get(long id)
        {
            var alergia = context.Alergia.Find(id);

            return alergia;
        }

        // POST api/<AlergiaController>
        [HttpPost]
        public ActionResult Post([FromBody] Alergia alergia)
        {
            try
            {
                context.Alergia.Add(alergia);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AlergiaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Alergia alergia)
        {
            if (alergia.id == id)
            {
                context.Entry(alergia).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<AlergiaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var alergia = context.Alergia.Find(id);
            if (alergia != null)
            {
                context.Alergia.Remove(alergia);
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