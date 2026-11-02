using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiJwt.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        // Exige autenticação para acessar este método.
        [Authorize]
        [HttpGet("perfil")]
        public IActionResult Perfil()
        {
            // Recupera o nome do usuário identificado pelo JWT.
            string nomeUsuario = User.Identity?.Name ?? "Usuário";

            // Retorna uma mensagem com o nome autenticado.
            return Ok(new
            {
                mensagem = $"Bem-vindo, {nomeUsuario}!",
                usuario = nomeUsuario
            });
        }
    }
}