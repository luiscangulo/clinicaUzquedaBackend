
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
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public DoctorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<DoctorController>
        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
            return context.Doctor as IEnumerable<Doctor>;
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public Doctor Get(long id)
        {
            var doctor = context.Doctor.Find(id);

            return doctor;
        }

        // POST api/<DoctorController>
        [HttpPost]
        public ActionResult Post([FromBody] Doctor doctor)
        {
            try
            {
                context.Doctor.Add(doctor);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Doctor doctor)
        {
            if (doctor.id == id)
            {
                context.Entry(doctor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var doctor = context.Doctor.Find(id);
            if (doctor != null)
            {
                context.Doctor.Remove(doctor);
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