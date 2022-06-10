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
    public class RolController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public RolController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<DoctorController>
        [HttpGet]
        public IEnumerable<Rol> Get()
        {
            return context.Rol as IEnumerable<Rol>;
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public Rol Get(long id)
        {
            var rol = context.Rol.Find(id);

            return rol;
        }

        // POST api/<DoctorController>
        [HttpPost]
        public ActionResult Post([FromBody] Rol rol)
        {
            try
            {
                context.Rol.Add(rol);
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
        public ActionResult Put(long id, [FromBody] Rol rol)
        {
            if (rol.id == id)
            {
                context.Entry(rol).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            var rol = context.Rol.Find(id);
            if (rol != null)
            {
                context.Rol.Remove(rol);
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