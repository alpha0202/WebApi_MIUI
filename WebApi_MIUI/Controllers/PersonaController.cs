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
        private readonly DbAa0bbfDbveterinariaContext _context;

        public PersonaController(DbAa0bbfDbveterinariaContext context)
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
                    IdPersona = a.Iidpersona,
                    NombreCompleto = a.Nombre +" "+a.Appaterno+" "+a.Apmaterno,
                    Correo = a.Correo,
                    FechaNacimientoStr = a.Fechanacimiento == null ? "": a.Fechanacimiento.Value.ToString("dd/MMM/yy")

                }).ToList();
            }
            catch (Exception e)
            {

                return list;
            }

            return list;

        }


        
    }
}
