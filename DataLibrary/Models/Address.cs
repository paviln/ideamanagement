using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Maybe to be used for Customer Addresses
/// </summary>
namespace EFDataAccessLibrary.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

    }
}
