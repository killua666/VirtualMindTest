using TestVM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestVM.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace TestVM.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class QuotationController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public QuotationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [Route("CurrencyRate/{unit}")]
        [HttpGet]
        public ActionResult<string> Get(string unit)
        {
            unit=unit.ToLower();
            var units = configuration["Units"].Split(',');
            if (unit == null || !units.Contains(unit))
            {
                return BadRequest("La moneda que desea cotizar no fue reconocida");
            }

            QuotationService call = new QuotationService(configuration);
            Quotation quote = call.GetCotizacion(unit).Result;
            
            return Ok(quote);
              
        }
    }
}
