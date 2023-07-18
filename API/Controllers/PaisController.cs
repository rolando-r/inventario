using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PaisController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;

    public PaisController(IUnitOfWork unitofwork)
    {
        this.unitofwork = unitofwork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Pais>>> Get()
    {
        var pais = await unitofwork.Paises.GetAllAsync();
        return Ok(pais);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(string id)
    {
        var pais = await unitofwork.Paises.GetByIdAsync(id);
        return Ok(pais);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post(Pais pais){
        this.unitofwork.Paises.Add(pais);
        await unitofwork.SaveAsync();
        if(pais == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= pais.CodPais}, pais);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Put(string id, [FromBody]Pais pais){
        if(pais == null)
            return NotFound();
        unitofwork.Paises.Update(pais);
        await unitofwork.SaveAsync();
        return pais; // Sacar de las llaves si algo
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var pais = await unitofwork.Paises.GetByIdAsync(id);
        if(pais == null){
            return NotFound();
        }
        unitofwork.Paises.Remove(pais);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}