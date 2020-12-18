using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.ApiServices;

namespace EskobInnovation.IdeaManagement.WPF.Service
{
  public class ApiCustomerService : IApiCustomerService
  {
    private static PrepHttpClient client = new PrepHttpClient();
    public ApiCustomerService() { }

    public async Task<Customer> GetCustomerByID(int id)
    {
      
      HttpResponseMessage response = await client.GetAsync(
                $"api/customer/{id}");
      if (response.IsSuccessStatusCode)
      {
        Customer customer = await response.Content.ReadAsAsync<Customer>();

        return customer;
      }
      return null;
    }



    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
      string uri = "api/customer/";
      List<Customer> customers = null;
      HttpResponseMessage response = await client.GetAsync(uri);
      if (response.IsSuccessStatusCode)
      {
        customers = await response.Content.ReadAsAsync<List<Customer>>();
      }
      return customers;
    }
    //POST Request
    public async Task<Uri> CreateCustomerAsync(Customer customer)
    {
      string uri = "api/customer";
      HttpResponseMessage response = await client.PostAsJsonAsync(uri, customer);
      return response.Headers.Location;
    }
    //PUT Request
    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
      HttpResponseMessage response = await client.PutAsJsonAsync(
          $"api/customer/{customer.Id}", customer);
      response.EnsureSuccessStatusCode();

      // Deserialize the updated product from the response body.
      customer = await response.Content.ReadAsAsync<Customer>();
      return customer;
    }
    //DELETE Request
    public async Task<HttpStatusCode> DeleteCustomerAsync(int id)
    {
      HttpResponseMessage response = await client.DeleteAsync(
          $"api/customer/{id}");
      return response.StatusCode;
    }
  }
}
