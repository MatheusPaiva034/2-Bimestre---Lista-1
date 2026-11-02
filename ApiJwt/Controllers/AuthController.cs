using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiJwt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiJwt.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        // Recebe as configurações da aplicação.
        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        // POST: /api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel dados)
        {
            // Usuário e senha fixos, somente para fins didáticos.
            string usuarioCorreto = "admin";
            string senhaCorreta = "123456";

            // Confere se o usuário e a senha estão corretos.
            if (dados.Usuario != usuarioCorreto || dados.Senha != senhaCorreta)
            {
                // Retorna 401 quando as credenciais são inválidas.
                return Unauthorized(new { mensagem = "Usuário ou senha incorretos." });
            }

            // Lê a chave usada para assinar o token.
            string chave = _config["Jwt:Key"]!;

            // Cria a chave de segurança.
            var chaveSeguranca = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chave));

            // Define o algoritmo utilizado na assinatura.
            var credenciais = new SigningCredentials(chaveSeguranca, SecurityAlgorithms.HmacSha256);

            // Adiciona o nome do usuário ao token.
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, dados.Usuario)
            };

            // Cria o token com emissor, público, usuário e validade.
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credenciais
            );

            // Transforma o token em uma string.
            string tokenGerado = new JwtSecurityTokenHandler().WriteToken(token);

            // Retorna o token para o cliente.
            return Ok(new
            {
                mensagem = "Login realizado com sucesso!",
                token = tokenGerado
            });
        }
    }
}