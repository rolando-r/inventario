using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EstadoController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;

    public EstadoController(IUnitOfWork unitofwork)
    {
        this.unitofwork = unitofwork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Estado>>> Get()
    {
        var estado = await unitofwork.Estados.GetAllAsync();
        return Ok(estado);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(string id)
    {
        var estado = await unitofwork.Estados.GetByIdAsync(id);
        return Ok(estado);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Estado>> Post(Estado estado){
        this.unitofwork.Estados.Add(estado);
        await unitofwork.SaveAsync();
        if(estado == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= estado.codEstado}, estado);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Estado>> Put(string id, [FromBody]Estado estado){
        if(estado == null)
            return NotFound();
        unitofwork.Estados.Update(estado);
        await unitofwork.SaveAsync();
        return estado; // Sacar de las llaves si algo
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var estado = await unitofwork.Estados.GetByIdAsync(id);
        if(estado == null){
            return NotFound();
        }
        unitofwork.Estados.Remove(estado);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}