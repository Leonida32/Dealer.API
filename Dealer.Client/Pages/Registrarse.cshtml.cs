using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.JSInterop;
using Models_Services;
using Newtonsoft.Json;
 
 

namespace Dealer.Client.Pages
{
    public class RegistrarseModel : PageModel
    {
        private JSRuntime Java;
        public string UriClientes = "https://localhost:7124/api/Clientes";
        public string UriVehiculos = "https://localhost:7124/api/DealerVehiculos";
        
        public void OnGet()        { }

        [BindProperty]
        public Clientes cliente { get; set; }
        [BindProperty]
        public string Cfclave {  get; set; }
        

        public async Task<IActionResult> OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
           if(cliente.Clave == Cfclave){ 
            HttpClient HttpClient = new();
            if (string.IsNullOrEmpty(cliente.Nombre)) { await Java.InvokeAsync<string>("alert","Favor completar Campos");  }
            //var th = JsonConvert.SerializeObject(cliente);
           await HttpClient.PostAsJsonAsync<Clientes>(UriClientes, cliente);
                /* await Java.InvokeAsync<string>("alert", response);*/
                return RedirectToPage("./VerVehiculos");
            }
           return Page();
        }
       

    }
}
