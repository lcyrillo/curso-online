using CursoOnline.Application.Interfaces;
using CursoOnline.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CursoController : ControllerBase
{
    private readonly ICursoApplication _cursoApplication;

    public CursoController(ICursoApplication cursoApplication)
    {
        _cursoApplication = cursoApplication;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _cursoApplication.GetAll();
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await _cursoApplication.GetById(id);
        return Ok(response);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName([FromRoute] string name)
    {
        var response = await _cursoApplication.GetByName(name);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CursoRequest cursoRequest)
    {
        await _cursoApplication.Add(cursoRequest);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CursoRequest cursoRequest)
    {
        var response = await _cursoApplication.Update(cursoRequest);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        var response = await _cursoApplication.Delete(id);

        if (response != null)
            return Ok(response);
        else
            return BadRequest();
    }
}
