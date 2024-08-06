using Core.Input;
using Core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TechChallangeCadastroContatosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] LoginInput loginInput)
        {
            if (loginInput.Usuario == "usuario-fiap" && loginInput.Senha == "senha-fiap")
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Utils.CHAVE_TOKEN));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(null,
                  null,
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return Ok(token);                
            }
            else
            {
                return Unauthorized("Usuário ou senha incorretos");
            }
        }
    }
}
