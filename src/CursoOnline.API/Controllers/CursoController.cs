using CursoOnline.Application.Interfaces;
using CursoOnline.Application.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "admin,user")]
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

    [HttpGet("{name:string}")]
    public async Task<IActionResult> GetByName([FromRoute] string name)
    {
        var response = await _cursoApplication.GetByName(name);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CursoRequest cursoRequest)
    {
        var response = await _cursoApplication.Add(cursoRequest);
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

    [HttpPatch]
    [Route("Approve")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Approve([FromQuery] int id)
    {
        var response = await _cursoApplication.Approve(id);

        if (response != null) 
            return Ok(response);
        else 
            return BadRequest();
    }

    [HttpPatch]
    [Route("EnrollProfessor")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> EnrollProfessor([FromQuery] int idProfessor, [FromQuery] int idCurso)
    {
        var response = await _cursoApplication.EnrollProfessor(idProfessor, idCurso);

        if (response != null)
            return Ok(response);
        else
            return BadRequest();
    }
}
