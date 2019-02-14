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
    public class CertificatesController : ControllerBase
    {
        private readonly AppDBContext _context;
        public CertificatesController(AppDBContext context)
        {
            this._context = context;
            if (this._context.Certificates.Count() == 0)
            {
                Console.WriteLine("No existe Certificado");
                Certificates datos = new Certificates();
           
                datos.entidad_emisora = "Banesto";
                datos.numero_de_serie = "67123123123124124";
                datos.subject = "Alberto Prado";
                datos.alias = "jiraPass";
                datos.password = "hdhdht556";
                datos.id_orga = "Sabadell";
                datos.nombre_cliente = "Jose Luis";
                datos.contacto_renovacion = "Angel Moya";
                datos.repositorio = "";
                datos.observaciones = "ok";
                datos.integration_list = "Jose Luis-Angela Muñoz";

     
                this._context.Certificates.Add(datos);
                this._context.SaveChanges();

            }
        }


        // GET api/jira
        [HttpGet]
        public ActionResult<List<Certificates>> GetAll()
        {
            return this._context.Certificates.ToList();
        }

        // GET api/jira/5
        [HttpGet("{id}")]
        public ActionResult<Certificates> Get(long id)
        {
            Certificates user = this._context.Certificates.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/jira
        [HttpPost]
        public void Post([FromBody] Certificates value)
        {
            this._context.Certificates.Add(value);
            this._context.SaveChanges();
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Certificates value)
        {
           Certificates datos = this._context.Certificates.Find(id);

            datos.entidad_emisora = value.entidad_emisora;
            datos.numero_de_serie = value.numero_de_serie;
            datos.subject = value.subject;
            datos.alias = value.alias;
           
            datos.password = value.password;
            datos.id_orga = value.id_orga;
            datos.nombre_cliente = value.nombre_cliente;
            datos.contacto_renovacion = value.contacto_renovacion;
            datos.repositorio = value.repositorio;
            datos.observaciones = value.observaciones;
            datos.integration_list = value.integration_list;
         
            this._context.SaveChanges();
          
        }

        // DELETE api/jira/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            Certificates userEliminar = this._context.Certificates.Where(
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