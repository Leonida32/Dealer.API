using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models_Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dealer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerVehiculosController : ControllerBase
    {
        private readonly Servicio Context;
        public DealerVehiculosController(Servicio Db)
        {
            Context = Db;
            Context.Database.MigrateAsync();
        }


        // GET: api/<DealerVehiculosController>
        [HttpGet]
        public async Task<ActionResult<List<Vehiculos>>> GetAll()
        {
            Context.Database.OpenConnectionAsync().Wait();
            var lista = await Context.Vehiculos.ToListAsync(); Ok();
            Context.Database.CloseConnection();
            return lista;
        }

        // GET api/<DealerVehiculosController>/5
        [HttpGet("{id}")]
        public ActionResult<Vehiculos> Get(int id)
        {
            Context.Database.OpenConnectionAsync().Wait();   
            var get = Context.Vehiculos.FirstOrDefault(c => c.ID == id); Context.Database.CloseConnection();
            return (get is null) ? NotFound() : get;
        }

        // POST api/<DealerVehiculosController>
        [HttpPost]
        public async Task<ActionResult<Vehiculos>> Post([FromBody] Vehiculos value)
        {
            Context.Database.OpenConnectionAsync().Wait(); var s = new Vehiculos() { Ano = new DateOnly(value.Ano.Year,01,01), Asignado = value.Asignado, Marca = value.Marca, Modelo = value.Modelo }; ; 
            await Context.Vehiculos.AddAsync(s); await Context.SaveChangesAsync(); Context.Database.CloseConnection(); return Ok();
            

        }

        // PUT api/<DealerVehiculosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Vehiculos>> Put(int id, [FromBody] Vehiculos value)
        {
            await Context.Database.OpenConnectionAsync();  var get = Context.Vehiculos.Any(c => c.ID == id);
            if (!get){ Context.Database.CloseConnection(); return BadRequest(); } Context.Vehiculos.Entry(value).State = EntityState.Modified; await Context.SaveChangesAsync(); Context.Database.CloseConnection(); return NoContent();
        }




        // DELETE api/<DealerVehiculosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehiculos>> Delete(int id)
        {
            await Context.Database.OpenConnectionAsync();
            var get = await Context.Vehiculos.FirstOrDefaultAsync(c => c.ID == id);
            if (get is null) return NotFound(); Context.Remove(get); await Context.SaveChangesAsync(); Context.Database.CloseConnection();   return Ok();

            
        }
    }
}
