using Ejercicio5Modulo3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio5Modulo3.Controllers
{
    [Route("api/v1/usuarios/")]
    [ApiController]
    public class UsuarioController
    {
        private IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers([FromQuery] String? apellido, [FromQuery] String? genero)
        {
            var result = await _usuarioService.getAllUsersAsync(apellido, genero);
            return Ok(result);
        }

        [HttpPost]
        [Route("seed")]
        public async Task PostUser()
        {
            await _usuarioService.postUserBySeed();
        }

    }
}
