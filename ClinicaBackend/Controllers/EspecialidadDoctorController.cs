
using ClinicaBackend.Contexts;
using ClinicaBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EspecialidadDoctorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public EspecialidadDoctorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<EspecialidadDoctorController>
        [HttpGet]
        public IEnumerable<EspecialidadDoctor> Get()
        {
            var especialidaddoctor = context.EspecialidadDoctor.Include(i => i.Doctor).Include(j => j.Especialidad);
            return especialidaddoctor as IEnumerable<EspecialidadDoctor>;
        }

        // GET api/<EspecialidadDoctorController>/5
        [HttpGet("{id}")]
        public EspecialidadDoctor Get(long id)
        {
            var especialidaddoctor = context.EspecialidadDoctor.Find(id);

            return especialidaddoctor;
        }

        // POST api/<EspecialidadDoctorController>
        [HttpPost]
        public ActionResult Post([FromBody] EspecialidadDoctor especialidaddoctor)
        {
            try
            {
                context.EspecialidadDoctor.Add(especialidaddoctor);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EspecialidadDoctorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] EspecialidadDoctor especialidaddoctor)
        {
            if (especialidaddoctor.id == id)
            {
                context.Entry(especialidaddoctor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<EspecialidadDoctorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var especialidaddoctor = context.EspecialidadDoctor.Find(id);
            if (especialidaddoctor != null)
            {
                context.EspecialidadDoctor.Remove(especialidaddoctor);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }



        // GET api/<EspecialidadDoctorController>/5
        [HttpGet("Especialidades/{id}")]
        public IEnumerable<EspecialidadDoctor>  GetEspecialidadDoctor(long id)
        {
            var doctor = context.Doctor.Find(id);
            var doctorespecialidad = context.EspecialidadDoctor.Where(k => k.Doctor.id == id)
                                                                .Include(i => i.Especialidad);
                
                return doctorespecialidad;

            
        }
    }
}