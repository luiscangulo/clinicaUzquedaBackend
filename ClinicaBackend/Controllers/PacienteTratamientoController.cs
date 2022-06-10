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
    public class PacienteTratamientoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PacienteTratamientoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<PacienteTratamientoController>
        [HttpGet]
        public IEnumerable<PacienteTratamiento> Get()
        {
            var pacientetratamiento = context.PacienteTratamiento.Include(i => i.Tratamiento).Include(j => j.Paciente);
            return pacientetratamiento as IEnumerable<PacienteTratamiento>;
        }

        // GET api/<PacienteTratamientoController>/5
        [HttpGet("{id}")]
        public PacienteTratamiento Get(long id)
        {
            var pacientetratamiento = context.PacienteTratamiento.Find(id);

            return pacientetratamiento;
        }

        // POST api/<PacienteTratamientoController>
        [HttpPost]
        public ActionResult Post([FromBody] PacienteTratamiento pacientetratamiento)
        {
            try
            {
                context.PacienteTratamiento.Add(pacientetratamiento);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PacienteTratamientoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] PacienteTratamiento pacientetratamiento)
        {
            if (pacientetratamiento.id == id)
            {
                context.Entry(pacientetratamiento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<PacienteTratamientoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var pacientetratamiento = context.PacienteTratamiento.Find(id);
            if (pacientetratamiento != null)
            {
                context.PacienteTratamiento.Remove(pacientetratamiento);
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
