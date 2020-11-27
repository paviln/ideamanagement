using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// The Customers and their potentially lists of addrsses and emaills
/// </summary>
namespace EFDataAccessLibrary.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Email> EmailAddresses { get; set; } = new List<Email>();
    }
}
