using CursoOnline.Application.Interfaces;
using CursoOnline.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private readonly ITipoUsuarioApplication _tipoUsuarioApplication;

    public TipoUsuarioController(ITipoUsuarioApplication tipoUsuarioApplication)
    {
        _tipoUsuarioApplication = tipoUsuarioApplication;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _tipoUsuarioApplication.GetAll();
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _tipoUsuarioApplication.GetById(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TipoUsuarioRequest tipoUsuarioRequest)
    {
        await _tipoUsuarioApplication.Add(tipoUsuarioRequest);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TipoUsuarioRequest tipoUsuarioRequest)
    {
        var response = await _tipoUsuarioApplication.Update(tipoUsuarioRequest);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        var response = await _tipoUsuarioApplication.Delete(id);

        if (response != null)
            return Ok(response);
        else
            return NotFound();
    }
}
