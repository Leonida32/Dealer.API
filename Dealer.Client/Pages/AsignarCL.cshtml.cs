using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models_Services;
using Newtonsoft.Json;

namespace Dealer.Client.Pages
{
    public class AsignarCLModel : PageModel
    {
        public async Task OnGet(List<Vehiculos> _vehiculos, int IDV)
        {

            HttpClient Http = new();


            var geth = await Http.GetStringAsync(uricl);
            //var ge = await Http.GetStringAsync(Uri);
            var clien = JsonConvert.DeserializeObject<List<Clientes>>(geth);
            //var vehi = JsonConvert.DeserializeObject<List<Vehiculos>>(ge);

            clientes = clien;
            vehiculos = _vehiculos;

        }
        [BindProperty(SupportsGet =true)]
        public int vehiculo { get; set; }
        [Inject]
        public SweetAlertService Swal {  get; set; }    
        public List<Clientes> clientes { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<Vehiculos>vehiculos { get; set; }
       

        public string Uri = "https://localhost:7124/api/DealerVehiculos";
        public string uricl = "https://localhost:7124/api/Clientes";

    }
}

