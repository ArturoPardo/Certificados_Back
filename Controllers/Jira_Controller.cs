using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiGTT.Models;

namespace ApiGTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Jira_Controller : ControllerBase
    {
        private readonly AppDBContext _context;
        public Jira_Controller(AppDBContext context)
        {
            this._context = context;
            if (this._context.Jira.Count() == 0)
            {
                Console.WriteLine("No existe usuario");
                Jira usuario = new Jira();
                usuario.username = "Jiraname";
                usuario.password = "jiraPass";
                usuario.proyecto = "pass";
                usuario.url = "pass";
                usuario.componente = "pass";
                this._context.Jira.Add(usuario);
                this._context.SaveChanges();

            }
        }


        // GET api/jira
        [HttpGet]
        public ActionResult<List<Jira>> GetAll()
        {
            return this._context.Jira.ToList();
        }

        // GET api/jira/5
        [HttpGet("{id}")]
        public ActionResult<Jira> Get(long id)
        {
            Jira user = this._context.Jira.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/jira
        [HttpPost]
        public void Post([FromBody] Jira value)
        {
            this._context.Jira.Add(value);
            this._context.SaveChanges();
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Jira value)
        {
           Jira user = this._context.Jira.Find(id);
            user.username = value.username;
            user.password = value.password;
            this._context.SaveChanges();
          
        }

        // DELETE api/jira/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            Jira userEliminar = this._context.Jira.Where(
                user => user.id == id).First();
            if (userEliminar == null)
            {
                return "No existe usuario";
            }
            this._context.Remove(userEliminar);
            this._context.SaveChanges();
            return "Se ha borrado -> " + userEliminar.id;
        }
    }
}