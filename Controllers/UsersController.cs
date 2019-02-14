using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiGTT.Models;
using ApiGTT.Helpers;


namespace ApiGTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDBContext _context;
        public UsersController(AppDBContext context)
        {
            this._context = context;
           if (this._context.Users.Count() == 0)
            {
                Console.WriteLine("No existe usuario");
                Users usuario = new Users();
                usuario.username = "verde";
                usuario.password = "d4177dc752cddc204b22ec5798c4400e";
                usuario.role = true;

              


                this._context.Users.Add(usuario);
                this._context.SaveChanges();

            
               


              


            }
        }


        // GET api/users
        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
            return this._context.Users.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(long id)
        {
            Users user = this._context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody] Users value)
        {
            value.password = Encrypt.GetMD5(value.password);
            Console.WriteLine("Role " +value.role+ "Usuario" + value.username);
            this._context.Users.Add(value);
            this._context.SaveChanges();
            
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Users value)
        {
            Users user = this._context.Users.Find(id);
            user.username = value.username;
            user.password = value.password;
            this._context.SaveChanges();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            Users userEliminar = this._context.Users.Where(
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
