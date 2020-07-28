
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestVM.Models
{
    public class PurchaseRequest
    {
        public string IdUser { get; set; }
        public string Amount { get; set; }
        public string Unit { get; set; }
    }
}