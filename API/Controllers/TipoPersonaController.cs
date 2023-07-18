using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoPersonaController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;

    public TipoPersonaController(IUnitOfWork unitofwork)
    {
        this.unitofwork = unitofwork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoPersona>>> Get()
    {
        var tipopersona = await unitofwork.TiposPersonas.GetAllAsync();
        return Ok(tipopersona);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(string id)
    {
        var tipopersona = await unitofwork.TiposPersonas.GetByIdAsync(id);
        return Ok(tipopersona);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoPersona>> Post(TipoPersona tipopersona){
        this.unitofwork.TiposPersonas.Add(tipopersona);
        await unitofwork.SaveAsync();
        if(tipopersona == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= tipopersona.Id}, tipopersona);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoPersona>> Put(string id, [FromBody]TipoPersona tipopersona){
        if(tipopersona == null)
            return NotFound();
        unitofwork.TiposPersonas.Update(tipopersona);
        await unitofwork.SaveAsync();
        return tipopersona; // Sacar de las llaves si algo
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var tipopersona = await unitofwork.TiposPersonas.GetByIdAsync(id);
        if(tipopersona == null){
            return NotFound();
        }
        unitofwork.TiposPersonas.Remove(tipopersona);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}