using CapaEntidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_MIUI.Models;

namespace WebApi_MIUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly DbveterinariaContext _context;

        public PersonaController(DbveterinariaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<PersonaCLS> ListarPersona()
        {
            List<PersonaCLS> list = new List<PersonaCLS>();
            try
            {
                list = _context.Personas.Where(p => p.Bhabilitado ==1).Select(a =>  new PersonaCLS
                {
                    idPersona = a.Iidpersona,
                    nombreCompleto = a.Nombre +" "+a.Appaterno+" "+a.Apmaterno,
                    correo = a.Correo,
                    fechaNacimientoStr = a.Fechanacimiento == null ? "": a.Fechanacimiento.Value.ToString("dd/MMM/yy")

                }).ToList();
            }
            catch (Exception e)
            {

                return list;
            }

            return list;

        }


        [HttpGet("{nombre}")]
        public List<PersonaCLS> ListarPersona(string nombre)
        {
            List<PersonaCLS> list = new List<PersonaCLS>();
            try
            {
                list = _context.Personas
                    .Where(p => p.Bhabilitado == 1  && (p.Nombre + " " + p.Appaterno + " " + p.Apmaterno).Contains(nombre))
                
                    .Select(a => new PersonaCLS
                {
                    idPersona = a.Iidpersona,
                    nombreCompleto = a.Nombre + " " + a.Appaterno + " " + a.Apmaterno,
                    correo = a.Correo,
                    fechaNacimientoStr = a.Fechanacimiento == null ? "" : a.Fechanacimiento.Value.ToString("dd/MMM/yy")

                }).ToList();
            }
            catch (Exception e)
            {

                return list;
            }

            return list;

        }

        [HttpGet("personaid/{id:int}")]
        public PersonaCLS RecuperarPersonaId(int id)
        {
            PersonaCLS persona = new PersonaCLS();

            try
            {
                persona = _context.Personas.Where(p=> p.Iidpersona == id).Select(p => new PersonaCLS
                {
                    idPersona= p.Iidpersona,
                    nombre = p.Nombre,
                    apePaterno= p.Appaterno,
                    apeMaterno=p.Apmaterno,
                    fechaNacimiento = (DateTime)p.Fechanacimiento,
                    fechaNacimientoStr = p.Fechanacimiento == null ? "" : p.Fechanacimiento.Value.ToString("yyyy-MM-dd"),
                    correo = p.Correo
                }).FirstOrDefault();

                return persona;
            }
            catch (Exception e)
            {

                return persona;
            }
        }
    }
}
