using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.API.Data;
using ProAgil.API.Models;

namespace ProAgil.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    public DataContext Context { get; }

    public ValuesController(DataContext context)
    {
      this.Context = context;

    }
    // GET api/values
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var results = await this.Context.Eventos.ToListAsync();
            return Ok(results);
        }
        catch (System.Exception)
        {
            
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falou");
        }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var results = await this.Context.Eventos.FirstOrDefaultAsync();
            return Ok(results);
        }
        catch (System.Exception)
        {
            
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falou");
        }
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
