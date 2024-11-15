using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Models_Services;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using CurrieTechnologies.Razor.SweetAlert2;
using System.Runtime.CompilerServices;
namespace Dealer.Client.Pages
{
    public class VerVehiculosModel : PageModel
    {
        public async Task OnGet()
        {

            HttpClient Http = new();
            

            var geth = await Http.GetStringAsync(uricl);
            var ge = await Http.GetStringAsync(Uri);
          var clien =  JsonConvert.DeserializeObject<List<Clientes>>(geth);
           var vehi = JsonConvert.DeserializeObject<List<Vehiculos>>(ge);

            clientes = clien;
            vehiculos = vehi;

        }
        SweetAlertService Swal;
        public List<Clientes> clientes {  get; set; }
       public List<Vehiculos> vehiculos { get; set; }
          
        public string Uri = "https://localhost:7124/api/DealerVehiculos";
        public string uricl = "https://localhost:7124/api/Clientes";

        public async Task OnPostAsignar()
        {

        }
    }
}
