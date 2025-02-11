using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Models_Services
{
    [PrimaryKey(nameof(ID))]
    public class Vehiculos
    {
        [Column("iD", Order = 1), Display(Name ="ID")]
        public int ID { get; set; }
        [Column("IDTH"), Display(Name ="IDTH")]
        public int? IDTH { get; set; }
        [Column("Asignado"), Display(Name = "Asignado")]
        public string? Asignado { get; set; }
        [Column("Marca"), Display(Name = "Marca")]
        public string Marca { get; set; }
        [Column("Modelo"), Display(Name = "Modelo")]
        public string Modelo { get; set; }
        [Column("Ano"), Display(Name = "Ano")]
        public DateOnly Ano { get; set; }

         [Column("Desde"), Display(Name = "Desde")]
        public DateOnly Desde {  get; set; }
         [Column("Hasta"), Display(Name = "Hasta")]

        public DateOnly Hasta { get; set; } 
        
         [Column("Imagen"), Display(Name = "Imagen")]
         public string Imagen {  get; set; }    
    }
}
