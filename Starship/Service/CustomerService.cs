using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Panel.Models;
using Starship.Helpers;

namespace Starship.Service
{
    public class CustomerService : ICustomerService
    {
        private static HttpCommon client = new HttpCommon();

        public CustomerService(){ }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            string path = "/api/customer";
            List<Customer> customer = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadAsAsync<List<Customer>>();
            }
         return customer;
        }
        public async Task<Uri> CreateCustomerAsync(string companyname)
        {
            Customer customer = new Customer();
            customer.CompanyName = companyname;
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/customer", customer);
            return response.Headers.Location;

        }
        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/customer/{customer.Id}", customer);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            customer = await response.Content.ReadAsAsync<Customer>();
            return customer;
        }
        public  async Task<HttpStatusCode> DeleteCustomerAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/customer/{id}");
            return response.StatusCode;
        }

    }
}