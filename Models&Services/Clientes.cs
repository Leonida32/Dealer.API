
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models_Services
{

    [PrimaryKey(nameof(iD))]
    public class Clientes
    {
        [Column("iD" ,Order = 1)]
        public int iD { get; set; }
        
        [Column("Nombre"),Display(Name ="Nombre: ")]
        public string Nombre {  get; set; }
        [Column("Apellido"),Display(Name = "Apellido: ")]
        public string Apellido { get; set; }
        
        [Column("Carroallevar"), Display(Name = "Carro a llevar: ")]
        public int?  Carroallevar { get; set; }

        [Column("edad"), Display(Name ="Edad: ")]
        public int edad { get; set; }
        [Column("Correo"), Display(Name = "Correo: ")]
        public string Correo {  get; set; }
        [Column("Telefono"), Display(Name = "Telefono: ")]
        public string Telefono { get; set; }


    }
}
