using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models_Services;
using Dealer.API.Correos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dealer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerVehiculosController : ControllerBase
    {
        private readonly DbContex Context;
        private Emails Mailkit { get; set; }
        public DealerVehiculosController(DbContex Db)
        {
            Context = Db;
            Mailkit = new Emails();
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
            //var s = new Vehiculos() { Ano = new DateOnly(value.Ano.Year, 01, 01), Asignado = value.Asignado, Marca = value.Marca, Modelo = value.Modelo }; ;
            Context.Vehiculos.Add(value); await Context.SaveChangesAsync();  return Ok();
        }
            


        // PUT api/<DealerVehiculosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Vehiculos>> Put(int id,  Vehiculos value)
        {
            var get = Context.Vehiculos.FirstOrDefault(c => c.ID == id);
            if (get is null ){ return BadRequest(); }
            try {
             
                get.Ano = value.Ano;
                    get.Asignado = value.Asignado;
                    get.Marca = value.Marca;
                    get.Modelo = value.Modelo;
                    get.Imagen = value.Imagen;
                    get.IDTH = value.IDTH;
                    get.Desde = value.Desde;
                    get.Hasta = value.Hasta;
                
                await Context.SaveChangesAsync(); 
                
            }
            catch (Exception e) 
            {
                Console.Clear(); Console.WriteLine("Error en carro: " + e); 
            }   
            return Ok();
        }

        [HttpPost("Alquilar")]
        public async Task<ActionResult<ClientesyVehiculos>> Alquilar([FromBody] ClientesyVehiculos value)
        {

            if (!ModelState.IsValid)
            {
                Console.Clear(); Console.WriteLine("SE JODIO UN MODELO");
            }
            try
            {
            var cliente = value.clientes; var vehiculo = value.vehiculos;
            Context.Clientes.Add(cliente);
            await Context.SaveChangesAsync();

         

            //luego de sacar el cliente
            var get = Context.Vehiculos.FirstOrDefault(c => c.ID == vehiculo.ID);
            if (get is null) { return BadRequest(); }
                get.Ano = vehiculo.Ano;
                get.Asignado = vehiculo.Asignado;
                get.Marca = vehiculo.Marca;
                get.Modelo = vehiculo.Modelo;
                get.Imagen = vehiculo.Imagen;
                get.IDTH = cliente.iD;
                get.Desde = vehiculo.Desde;
                get.Hasta = vehiculo.Hasta;

                await Context.SaveChangesAsync();
                await Mailkit.Enviar(cliente.Correo, vehiculo.Asignado, vehiculo.Marca, vehiculo.Modelo, vehiculo.Desde, vehiculo.Hasta);
            }
            catch (Exception e)
            {
                Console.Clear(); Console.WriteLine("Error en carro: " + e); return BadRequest();
            }
            return Ok();
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
