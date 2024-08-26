using CursoOnline.API.Helpers;
using CursoOnline.Application.Interfaces;
using CursoOnline.Application.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CursoOnline.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioApplication _usuarioApplication;

    public UsuarioController(IUsuarioApplication usuarioApplication)
    {
        _usuarioApplication = usuarioApplication;
    }

    [HttpPost]
    [Route("GerarSenha")]
    [AllowAnonymous]
    public async Task<IActionResult> GerarSenha(UsuarioRequest usuarioRequest)
    {
        if (usuarioRequest != null)
        {
            await _usuarioApplication.GerarSenha(usuarioRequest);
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] UsuarioRequest usuarioRequest)
    {
        if (usuarioRequest != null)
        {
            await _usuarioApplication.Add(usuarioRequest);
            return Created();
        }

        return BadRequest();
    }

    [HttpPut]
    [Route("CriarSenha")]
    [AllowAnonymous]
    public async Task<IActionResult> GravarSenha([FromBody] UsuarioRequest usuarioRequest, [FromQuery] string password, [FromQuery] string passwordProv)
    {
        if (usuarioRequest != null)
        {
            var usuarioSenhaProv = await _usuarioApplication.GetBySenhaProv(usuarioRequest, passwordProv);

            if (usuarioSenhaProv != null)
            {
                await _usuarioApplication.GravarSenha(usuarioRequest, password);
                return Ok();
            }
        }

        return BadRequest();
    }

    [HttpPost]
    [Route("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Authenticate([FromBody] UsuarioLoginRequest usuarioLoginRequest)
    {
        if (usuarioLoginRequest != null)
        {
            var usuario = await _usuarioApplication.GetByMail(usuarioLoginRequest.Email);

            if (usuario == null)
                return NotFound("Usuário não encontrado");

            if (usuario.SenhaSalt.IsNullOrEmpty() && usuario.SenhaHash.IsNullOrEmpty())
                return BadRequest(new
                {
                    Message = "Usuário não possui senha cadastrada"
                });

            bool senhaValidada = _usuarioApplication.VerificarSenha(usuarioLoginRequest.Password, usuario.SenhaHash, usuario.SenhaSalt);

            if (!senhaValidada)
                return BadRequest(new
                {
                    Message = "Erro ao realizar login. Verifique os dados"
                });

            var token = TokenService.GenerateToken(usuarioLoginRequest);

            var result = 
                new
                {
                    UserLogin = usuario.Email,
                    Token = token,
                };

            return Ok(result);
        }

        return BadRequest();
    }
}
