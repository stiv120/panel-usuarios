using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace Servicios.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsuariosController : ControllerBase
    {
        private readonly IObtenerUsuariosCasoUso _obtenerUsuariosCasoUso;

        public UsuariosController(IObtenerUsuariosCasoUso obtenerUsuariosCasoUso)
        {
            _obtenerUsuariosCasoUso = obtenerUsuariosCasoUso;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                var users = await _obtenerUsuariosCasoUso.EjecutarAsync(cancellationToken);
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(503, new { error = "Ha ocurrido un error. Por favor, intente de nuevo." });
            }
        }
    }
}
