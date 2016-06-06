using MultiService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace MultiService.Controllers
{
    public class WebAPIHelper
    {
        private string url = "http://localhost:10975/api/values";
        HttpClient client = new HttpClient();
        public WebAPIHelper(string url)
        {
            this.url = url;
        }

        public Customer[] Get(string customerId = "")
        {
            if (customerId == "")
            {
                HttpResponseMessage response = client.GetAsync(this.url).Result;
                Customer[] data = JsonConvert.DeserializeObject<Customer[]>(response.Content.ReadAsStringAsync().Result);
                return data;
            }
            else
            {
                HttpResponseMessage response = client.GetAsync(this.url + customerId).Result;
                Customer obj = JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);
                Customer[] data = new Customer[1];
                data[0] = obj;
                return data;
            }
        }

        //public string Post(Customer obj)
        //{
        //    HttpRequestMessage request = new HttpRequestMessage();

        //    //var postMessage = new HttpRequestMessage(HttpMethod.Post, "http://myapi.com/blah");
        //    //var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        //    //postMessage.Content.Headers.ContentType.MediaType = "application/json";

        //    //var result = client.SendAsync(postMessage).Result;
        //    client.PostAsJsonAsync("", obj);
        //    //MediaTypeFormatter[] formatter = new MediaTypeFormatter[] { new JsonMediaTypeFormatter() };
        //    //var content = request.CreateContent<Customer>(obj, MediaTypeHeaderValue.Parse("application/json"), formatter, new FormatterSelector());
        //    //HttpResponseMessage response = client.PostAsync(this.url, content).Result;
        //    //return result.Content.ToString();
        //}

        //public string Put(string customerId, Customer obj)
        //{
        //    HttpRequestMessage request = new HttpRequestMessage();
        //    MediaTypeFormatter[] formatter = new MediaTypeFormatter[] { new JsonMediaTypeFormatter() };
        //    var content = request.CreateContent<Customer>(obj, MediaTypeHeaderValue.Parse("application/json"), formatter, new FormatterSelector());
        //    HttpResponseMessage response = client.PutAsync(this.url + customerId, request.Content).Result;
        //    return response.Content.ToString();
        //}

        //public string Delete(string customerId)
        //{
        //    HttpResponseMessage response = client.DeleteAsync(this.url + customerId).Result;
        //    return response.Content.ToString();
        //}
    }
}
