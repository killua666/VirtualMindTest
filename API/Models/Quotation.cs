using System;
using System.Globalization;

namespace TestVM.Models
{
    public class Quotation
    {
        public Quotation(string[] Datos)
        {
            Buy = Convert.ToDecimal(Datos[0], new CultureInfo("en-US"));
            Sell = Convert.ToDecimal(Datos[1], new CultureInfo("en-US"));
            UpdateDate = Datos[2].Replace("Actualizada al ","").Trim();
        }

        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
        public string UpdateDate { get; set; }

        public string Print()
        {
            return "Compra: " + Buy + "  Venta: " + Sell + "  Fecha de Cotización: " + UpdateDate;
        }
    }
}