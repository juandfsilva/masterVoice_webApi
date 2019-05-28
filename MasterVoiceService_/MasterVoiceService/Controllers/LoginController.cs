using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MasterVoiceService.Dao;
using MasterVoiceService.Model;
using MasterVoiceService.Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MasterVoiceService.Controllers
{
    [Route("api/[Controller]")]
    public class LoginController : Controller
    {
        private readonly mastervoiceContext _context;
        private LoginDAO loginDAO;
        private readonly IConfiguration _configuration;

        public LoginController(mastervoiceContext ctx, IConfiguration config)
        {
            _context = ctx;
            _configuration = config;
            loginDAO = new LoginDAO(ctx);
        }

        [HttpPost("logar")]
        public async Task<IActionResult> RealizaLogin([FromBody] Login login)
        {
            ActionResult<Login> loginUsuario = await loginDAO.BuscarLogin(login.Login1);

            if (loginUsuario != null && loginUsuario.Result == null)
            {
                if (Criptografia.Compara(login.Senha, loginUsuario.Value.Senha))
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, login.Login1)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["CodigoSeguranca"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "MasterVoice",
                        audience: "MasterVoice",
                        claims: claims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: creds);

                    UsuarioDAO usuarioDAO = new UsuarioDAO(_context);
                    var usuario = usuarioDAO.BuscarUsuario(loginUsuario.Value.IdUsuario);

                    return Ok(new
                    {
                        nome = usuario.Result.Value.Nome,
                        login = login.Login1,
                        idUsuario = loginUsuario.Value.IdUsuario,
                        tokenAcesso = new JwtSecurityTokenHandler().WriteToken(token)
                    });

                }
                //else return BadRequest("Dados invalidos");
                else return NotFound(new { Menssagem = "Dados não encontrados" });
            }
            else return BadRequest("Usuario não existe");

        }
    }
}