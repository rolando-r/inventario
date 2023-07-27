using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PersonaController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;

    public PersonaController(IUnitOfWork unitofwork)
    {
        this.unitofwork = unitofwork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Persona>>> Get()
    {
        var persona = await unitofwork.Personas.GetAllAsync();
        return Ok(persona);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(string id)
    {
        var persona = await unitofwork.Personas.GetByIdAsync(id);
        return Ok(persona);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persona>> Post(Persona persona){
        this.unitofwork.Personas.Add(persona);
        await unitofwork.SaveAsync();
        if(persona == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= persona.IdPersona}, persona);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persona>> Put(string id, [FromBody]Persona persona){
        if(persona == null)
            return NotFound();
        unitofwork.Personas.Update(persona);
        await unitofwork.SaveAsync();
        return persona; // Sacar de las llaves si algo
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var persona = await unitofwork.Personas.GetByIdAsync(id);
        if(persona == null){
            return NotFound();
        }
        unitofwork.Personas.Remove(persona);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}