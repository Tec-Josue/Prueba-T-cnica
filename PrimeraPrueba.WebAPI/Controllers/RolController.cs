using PrimeraPrueba.EN;
using PrimeraPrueba.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace PrimeraPrueba.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RolController : ControllerBase
    {
        private RolBL rolBL = new RolBL();

        [HttpGet]
        public async Task<IEnumerable<Roles>> Get()
        {
            return await rolBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Roles> Get(int id)
        {
            Roles rol = new Roles();
            rol.Id = id;
            return await rolBL.ObtenerPorIdAsync(rol);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Roles rol)
        {
            try
            {
                await rolBL.CrearAsync(rol);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Roles rol)
        {

            if (rol.Id == id)
            {
                await rolBL.ModificarAsync(rol);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Roles rol = new Roles();
                rol.Id = id;
                await rolBL.EliminarAsync(rol);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Roles>> Buscar([FromBody] object pRol)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strRol = JsonSerializer.Serialize(pRol);
            Roles rol = JsonSerializer.Deserialize<Roles>(strRol, option);
            return await rolBL.BuscarAsync(rol);

        }
    }
}
