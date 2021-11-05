using DogCueMicroservices;
using DogCueMicroservices.Controllers;
using DogCueMicroservices.DBContexts;
using DogCueMicroservices.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Configuration;
using System.IO;



namespace DogCueMicroservicesTest
{
    public class UnitTestControllers
    {
        DogCueDBEntities _dbContext;

        public UnitTestControllers()
        {
            //var env = Environment.CurrentDirectory;

            // find the shared folder in the parent folder
            //var sharedFolder = Path.Combine(env, "..", "Shared");
        }

        [SetUp]
        public void Setup()
        {
            String ConnString = "data source=10.10.10.208\\sqlexpress01,1433;initial catalog=DogCueDB;User ID=sa;Password=bubaking;MultipleActiveResultSets=True;";
            

            var builder = new DbContextOptionsBuilder<DogCueDBEntities>();

            builder.UseSqlServer(ConnString);
            _dbContext = new DogCueDBEntities(builder.Options);
            
        }

        [Test]
        public void CustomerController_Index_OK()
        {
            
            CustomerController cc = new CustomerController(new CustomerRepository(_dbContext));
            ActionResult ar = cc.Index();
            Assert.AreEqual("OkObjectResult", ar.GetType().Name);
        }

        [Test]
        public void Test2()
        {
        }

    }
}