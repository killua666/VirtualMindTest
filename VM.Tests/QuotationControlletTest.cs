using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestVM.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace VM.Tests
{
    [TestClass]
    public class QuotationControlletTest
    {
        
        private readonly Dictionary<string, string> myConfiguration =
            new Dictionary<string, string>
            {
                {"Units", "dolar,real"},
                {"UnitCorrection:dolar", "1"},
                {"UnitCorrection:real", "4"},
                {"UrlService:dolar", "http://www.bancoprovincia.com.ar/Principal/Dolar" },
                {"UrlService:real", "http://www.bancoprovincia.com.ar/Principal/Dolar" },
            };

        [TestMethod]
        public void GetQuotationDolarOK()
        {
            // Arrange
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(myConfiguration).Build();
            var quotationController = new QuotationController(configuration);
            // Act
            var response = quotationController.Get("dolar").Result;
            // Assert
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetQuotationRealOK()
        {
            // Arrange
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(myConfiguration).Build();
            var quotationController = new QuotationController(configuration);
            // Act
            var response = quotationController.Get("real").Result;
            // Assert
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetQuotationBadRequest()
        {
            // Arrange
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(myConfiguration).Build();
            var quotationController = new QuotationController(configuration);
            // Act
            var response = quotationController.Get("").Result;
            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
        }
    }
}
