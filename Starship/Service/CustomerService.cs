using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using EskobInnovation.IdeaManagement.API.Models;
using Starship.Helpers;

namespace Starship.Service
{
    public class CustomerService {
        private static HttpCommon client = new HttpCommon();
        public static async Task<List<Customer>> GetCustomerAsync(string path)
        {
            List<Customer> customer = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadAsAsync<List<Customer>>();
            }
         return customer;
        }
        public static async Task<Uri> CreateCustomerAsync(string companyname)
        {
            Customer customer = new Customer();
            customer.CompanyName = companyname;
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/customer", customer);
            return response.Headers.Location;

        }
    }
}