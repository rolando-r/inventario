using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductoController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;

    public ProductoController(IUnitOfWork unitofwork)
    {
        this.unitofwork = unitofwork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Producto>>> Get()
    {
        var producto = await unitofwork.Productos.GetAllAsync();
        return Ok(producto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(string id)
    {
        var producto = await unitofwork.Productos.GetByIdAsync(id);
        return Ok(producto);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Producto>> Post(Producto producto){
        this.unitofwork.Productos.Add(producto);
        await unitofwork.SaveAsync();
        if(producto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= producto.IdProducto}, producto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Producto>> Put(string id, [FromBody]Producto producto){
        if(producto == null)
            return NotFound();
        unitofwork.Productos.Update(producto);
        await unitofwork.SaveAsync();
        return producto; // Sacar de las llaves si algo
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var producto = await unitofwork.Productos.GetByIdAsync(id);
        if(producto == null){
            return NotFound();
        }
        unitofwork.Productos.Remove(producto);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}