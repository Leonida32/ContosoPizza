using ContosoPizza.model;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]

public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    //GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    //GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza == null)
        {return NotFound();}
        return pizza;
    }

    // POst action
    [HttpPost]
    public IActionResult Create (Pizza pizza) 
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id}, pizza); 
        //este codigo guardara una pizza y devolvera un resultado
    }
    //Put action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id) return BadRequest();
        var existingPizza = PizzaService.Get(id);
        if (existingPizza == null) { return NotFound(); }
        PizzaService.Update(pizza);
        return NoContent();
        //este codigo actualizara y devolvera un resultado
    }
    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult delete(int id)
    {
        var pizzaSearch = PizzaService.Get(id);
        if (id == null) return NotFound();
        PizzaService.delete(id);
        return NoContent();
        //este codigo borrara una pizza esecifica
    }

   }

