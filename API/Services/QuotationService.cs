using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Threading.Tasks;
using TestVM.Models;

namespace TestVM.Services
{
    public class QuotationService
    {
        private readonly IConfiguration configuration;

        public QuotationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<Quotation> GetCotizacion(string unit)
        {
            string url = configuration["UrlService:"+ unit];
            var result = await url.GetAsync().ReceiveJson<string[]>();
            var quote = new Quotation(result);
            quote.Buy /= Convert.ToInt32(configuration["UnitCorrection:"+ unit]);
            quote.Sell /= Convert.ToInt32(configuration["UnitCorrection:"+unit]);
            return quote;
        }

    }
}