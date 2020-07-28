using Microsoft.AspNetCore.Mvc;
using TestVM.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using TestVM.DataAccess;
using System.Linq;
using System.Collections.Generic;
using TestVM.Services;
using Microsoft.AspNetCore.Cors;

namespace TestVM.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly APIContext dataContext;

        public PurchaseController(IConfiguration configuration, APIContext dataContext)
        {
            this.configuration = configuration;
            this.dataContext = dataContext;
        }

        [Route("Purchase")]
        [HttpPost]
        public IActionResult Post([FromBody] PurchaseRequest purchaseRequest)
        {
            try
            {
                var units = configuration["Units"].Split(',');
                if (!units.Contains(purchaseRequest.Unit.ToLower()))
                {
                    return BadRequest();
                }
                QuotationService call = new QuotationService(configuration);
                Quotation quote = call.GetCotizacion(purchaseRequest.Unit.ToLower()).Result;

                Purchase purchase = new Purchase();
                purchase.IdUser = purchaseRequest.IdUser;
                purchase.Unit = purchaseRequest.Unit.ToLower();
                purchase.Amount = Convert.ToDecimal(purchaseRequest.Amount);
                purchase.CurrencyRate = quote.Buy;
                purchase.AmountTo = Math.Round(purchase.Amount / quote.Buy, 3); 
                purchase.PurchaseDate = DateTime.Now;

                DateTime from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime to = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 1);


                List<Purchase> purchaseDataDB = dataContext.Purchase
                           .Where(p => p.IdUser == purchase.IdUser
                               && p.Unit == purchase.Unit
                               && p.PurchaseDate >= from
                               && p.PurchaseDate < to)
                           .ToList();
                
                decimal compraMensual = 0;
                foreach (Purchase p in purchaseDataDB)
                {
                    compraMensual += p.AmountTo.Value;
                }

                if (compraMensual + purchase.AmountTo >= Convert.ToDecimal(configuration["BuyLimit:" + purchase.Unit]))
                {
                    return BadRequest("Se sobrepaso el limete maximo de compra."+ Environment.NewLine + "Usted ya compro: " + compraMensual + ", el maximo mensual es: " + configuration["BuyLimit:" + purchaseRequest.Unit]);
                }
                else
                {
                    dataContext.Purchase.Add(purchase);
                    dataContext.SaveChanges();
                }


                return Ok(purchase);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
