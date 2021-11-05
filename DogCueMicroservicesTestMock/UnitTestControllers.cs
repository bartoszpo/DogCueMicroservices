using DogCueMicroservices.Controllers;
using DogCueMicroservices.DBContexts;
using DogCueMicroservices.Models;
using DogCueMicroservices.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DogCueMicroservicesTestMock
{
    public class UnitTestControllers
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CustomerController_Index_OK()
        {
            var data = new List<Customer>
            {
                new Customer { FirstName = "BBB",LastName = "BBB" },
                new Customer { FirstName  = "ZZZ",LastName = "BBB"  },
                new Customer{ FirstName  = "AAA" ,LastName = "BBB" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());




            var mockContext = new Mock<DogCueDBEntities>();
            mockContext.Setup(m => m.Customer).Returns(mockSet.Object);

            CustomerController cc = new CustomerController(new CustomerRepository(mockContext.Object));
            ActionResult ar = cc.Index();
            Assert.AreEqual("OkObjectResult", ar.GetType().Name);

            
        }
    }
}