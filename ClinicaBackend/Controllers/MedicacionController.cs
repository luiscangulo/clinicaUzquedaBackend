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
    public class MedicacionController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public MedicacionController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<MedicacionController>
        [HttpGet]
        public IEnumerable<Medicacion> Get()
        {
            var medicacion = context.Medicacion.Include(i => i.PacienteMedicacion);
            return medicacion as IEnumerable<Medicacion>;
        }

        // GET api/<MedicacionController>/5
        [HttpGet("{id}")]
        public Medicacion Get(long id)
        {
            var medicacion = context.Medicacion.Find(id);

            return medicacion;
        }

        // POST api/<MedicacionController>
        [HttpPost]
        public ActionResult Post([FromBody] Medicacion medicacion)
        {
            try
            {
                context.Medicacion.Add(medicacion);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MedicacionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Medicacion medicacion)
        {
            if (medicacion.id == id)
            {
                context.Entry(medicacion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<MedicacionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var medicacion = context.Medicacion.Find(id);
            if (medicacion != null)
            {
                context.Medicacion.Remove(medicacion);
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
