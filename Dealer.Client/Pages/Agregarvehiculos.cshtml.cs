using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models_Services;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
namespace Dealer.Client.Pages
{
    public class AgregarvehiculosModel : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty]
        public Vehiculos vehiculos {  get; set; }
        [BindProperty]
        public string ano { get; set; }    
        string uriv = "https://localhost:7124/api/DealerVehiculos";
        [Inject]
        SweetAlertService Swal { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
            HttpClient client = new HttpClient();
            int a() => int.Parse(ano);
            vehiculos.Ano = new DateOnly(a(), 1, 1);
            await  client.PostAsJsonAsync<Vehiculos>(uriv, vehiculos);
            return RedirectToPage("./VerVehiculos");
        }
    }
}
