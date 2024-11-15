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
        private readonly Servicio _contex;
        public ClientesController(Servicio contex)
        {
            _contex = contex;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<ActionResult<List<Clientes?>>> GetAll()
        {
            await _contex.Database.OpenConnectionAsync(); var getall = await _contex.Clientes.ToListAsync(); _contex.Database.CloseConnection(); return Ok(getall);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes?>> Get(int id)
        {
            await _contex.Database.OpenConnectionAsync(); var get = await _contex.Clientes.FirstOrDefaultAsync(c => c.iD == id); if(get is null) { _contex.Database.CloseConnection(); return NotFound(); }
            _contex.Database.CloseConnection(); return Ok(get);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<ActionResult<Clientes>> Post([FromBody] Clientes value)
        {
            await _contex.Database.OpenConnectionAsync(); var s = new Clientes() {  Apellido = value.Apellido, Carroallevar = value.Carroallevar,
            Correo = value.Correo, edad = value.edad, Nombre = value.Nombre, Telefono = value.Telefono, Clave = value.Clave};
            if (s.Carroallevar is null || s.Carroallevar == 0) {  _contex.Clientes.Add(s); await _contex.SaveChangesAsync(); _contex.Database.CloseConnection(); return Ok(); }
            var get = _contex.Vehiculos.Any(c => c.ID == s.Carroallevar); if (!get) return NotFound(); _contex.Clientes.Add(s); await _contex.SaveChangesAsync(); _contex.Database.CloseConnection(); return Ok();
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Clientes>> Put(int id, [FromBody] Clientes value)
        {
            await _contex.Database.OpenConnectionAsync(); var get = await _contex.Clientes.FirstOrDefaultAsync(x => x.iD == id); if (get is null) {_contex.Database.CloseConnection(); return NotFound(); }
            _contex.Clientes.Entry(get).State = EntityState.Modified; await _contex.SaveChangesAsync(); _contex.Database.CloseConnection(); return Ok();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clientes>> Delete(int id)
        {
            await _contex.Database.OpenConnectionAsync(); var get = await _contex.Clientes.FirstOrDefaultAsync(c => c.iD == id); if (get is null) { _contex.Database.CloseConnection(); return NotFound(); }
            _contex.Clientes.Remove(get); await _contex.SaveChangesAsync(); _contex.Database.CloseConnection(); return NoContent();
        }
    }
}
