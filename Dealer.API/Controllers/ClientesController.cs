using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models_Services;
 


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dealer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DbContex _contex;
        public ClientesController(DbContex contex)
        {
            _contex = contex;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<ActionResult<List<Clientes?>>> GetAll()
        {
             var getall = await _contex.Clientes.ToListAsync();  return Ok(getall);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes?>> Get(int id)
        {
            await _contex.Database.OpenConnectionAsync(); var get = await _contex.Clientes.FirstOrDefaultAsync(c => c.iD == id); if(get is null) { _contex.Database.CloseConnection(); return NotFound(); }
            _contex.Database.CloseConnection(); return Ok(get);
        }

        // POST api/<ClientesController>
        [HttpPost("Cliente")]
        public async Task<ActionResult<Clientes>> Post( [FromBody] Clientes value)
        {
            if(!ModelState.IsValid) return BadRequest("El model me ta aszarando");
            if(value == null || new Clientes()  == value) return NotFound();
            _contex.Clientes.Add(value);
            await _contex.SaveChangesAsync();
            return Ok(value);
        }
        //[HttpPost("Alquilar")]
        //public async Task<ActionResult<ClientesyVehiculos>> Alquilar(ClientesyVehiculos value)
        //{
        //    if (value.clientes != new Clientes())
        //    {
        //        return BadRequest();
        //    }
        //    _contex.Clientes.Add(value.clientes);
        //    await _contex.SaveChangesAsync();
        //    var cliente = _contex.Clientes.FirstOrDefault(c => c.Carroallevar == value.vehiculos.ID);
        //    if ( cliente != null)
        //    {
                
        //    } 
                
        //}
   

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Clientes>> Put(int id, [FromBody] Clientes value)
        {
              var get = await _contex.Clientes.FirstOrDefaultAsync(x => x.iD == id);
            if (get is null) return NotFound();
            try { get = value; }catch(Exception e) { Console.Clear(); Console.WriteLine(e);}


            await _contex.SaveChangesAsync();   
            return Ok();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clientes>> Delete(int id)
        {
            var get = await _contex.Clientes.FirstOrDefaultAsync(c => c.iD == id); if (get is null) { _contex.Database.CloseConnection(); return NotFound(); }
            _contex.Clientes.Remove(get); await _contex.SaveChangesAsync();  return NoContent();
        }
    }
}
