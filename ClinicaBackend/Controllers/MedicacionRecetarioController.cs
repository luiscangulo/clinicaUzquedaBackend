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
    public class MedicacionRecetarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public MedicacionRecetarioController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<MedicacionRecetarioController>
        [HttpGet]
        public IEnumerable<MedicacionRecetario> Get()
        {
            var medicacionrecetario = context.MedicacionRecetario.Include(i => i.Recetario).Include(j => j.Medicacion);
            return medicacionrecetario as IEnumerable<MedicacionRecetario>;
        }

        // GET api/<MedicacionRecetarioController>/5
        [HttpGet("{id}")]
        public MedicacionRecetario Get(long id)
        {
            var medicacionrecetario = context.MedicacionRecetario.Find(id);

            return medicacionrecetario;
        }

        // POST api/<MedicacionRecetarioController>
        [HttpPost]
        public ActionResult Post([FromBody] MedicacionRecetario medicacionrecetario)
        {
            try
            {
                context.MedicacionRecetario.Add(medicacionrecetario);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MedicacionRecetarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] MedicacionRecetario medicacionrecetario)
        {
            if (medicacionrecetario.id == id)
            {
                context.Entry(medicacionrecetario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<MedicacionRecetarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var medicacionrecetario = context.MedicacionRecetario.Find(id);
            if (medicacionrecetario != null)
            {
                context.MedicacionRecetario.Remove(medicacionrecetario);
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