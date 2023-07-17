using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RegionController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;

    public RegionController(IUnitOfWork unitofwork)
    {
        this.unitofwork = unitofwork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Region>>> Get()
    {
        var region = await unitofwork.Regiones.GetAllAsync();
        return Ok(region);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(string id)
    {
        var region = await unitofwork.Regiones.GetByIdAsync(id);
        return Ok(region);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Post(Region region){
        this.unitofwork.Regiones.Add(region);
        await unitofwork.SaveAsync();
        if(region == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= region.codRegion}, region);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Put(string id, [FromBody]Region region){
        if(region == null)
            return NotFound(); 
        unitofwork.Regiones.Update(region); // Esto
        await unitofwork.SaveAsync(); // Esto
        return region; // Sacar de las llaves si algo
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var region = await unitofwork.Regiones.GetByIdAsync(id);
        if(region == null){
            return NotFound();
        }
        unitofwork.Regiones.Remove(region);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}