using EskobInnovation.IdeaManagement.WPF.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Tests.CustomerServiceTests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        
        private CustomerService _customerService;

        [SetUp]
        public void SetUp()
        {
            _customerService = new CustomerService();
        }
      
    }
}
