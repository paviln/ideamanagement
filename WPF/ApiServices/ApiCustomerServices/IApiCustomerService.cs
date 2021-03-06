﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;

namespace EskobInnovation.IdeaManagement.WPF.Service
{
  public interface IApiCustomerService
  {
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<Uri> CreateCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(Customer customer);
    Task<HttpStatusCode> DeleteCustomerAsync(int id);

    Task<Customer> GetCustomerByID(int id);

  }
}
