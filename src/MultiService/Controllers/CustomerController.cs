using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using MultiService.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiService.Controllers
{

    public class CustomerController : Controller
    {
        HttpClient client = new HttpClient();

        // Pull settings from configuration
        private Settings _settings;
        public CustomerController(IOptions<Settings> options)
        {
            _settings = options.Value;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(_settings.CustomerAPIService);
            var json = await response.Content.ReadAsStringAsync();
            Customer[] obj = JsonConvert.DeserializeObject<Customer[]>(json);
            return View(obj);
        }
    }
}
