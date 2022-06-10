
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
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public UsuarioController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            var usuario = context.Usuario.Include(i => i.Doctor).Include(j => j.Paciente);
            return usuario as IEnumerable<Usuario>;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public Usuario Get(long id)
        {
            var usuario = context.Usuario.Find(id);

            return usuario;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                context.Usuario.Add(usuario);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Usuario usuario)
        {
            if (usuario.id == id)
            {
                context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var usuario = context.Usuario.Find(id);
            if (usuario != null)
            {
                context.Usuario.Remove(usuario);
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