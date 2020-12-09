using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Helpers;
using System.Configuration;

namespace EskobInnovation.IdeaManagement.WPF.Service
{
  public class CustomerService : ICustomerService
  {
    private static ApiHelper client = new ApiHelper();
    public CustomerService()
    {
    }
    public async Task<IEnumerable<Customer>> GetCustomerAsync(int id)
    {
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
    public async Task<Uri> CreateCustomerAsync(string companyname, string streetaddresse, string zipcode, string contactperson)
    {
      string uri = "api/customer";

      Customer customer = new Customer()
      {
        CompanyName = companyname,
        StreetAdresse = streetaddresse,
        ZipCode = zipcode,
        ContactPerson = contactperson
      };
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
    public async Task<HttpStatusCode> DeleteCustomerAsync(string id)
    {
      HttpResponseMessage response = await client.DeleteAsync(
          $"api/customer/{id}");
      return response.StatusCode;
    }
  }
}
