using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using MultiService.Models;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiService.Controllers
{
    public class CustomerController : Controller
    {
        private string url = "http://localhost:10975/api/Customer";
        HttpClient client = new HttpClient();
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(this.url);
            var json = await response.Content.ReadAsStringAsync();
            Customer[] obj = JsonConvert.DeserializeObject<Customer[]>(json);
            return View(obj);
        }
    }
}
