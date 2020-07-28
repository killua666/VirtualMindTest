
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestVM.Models
{
    public class Purchase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? IdPurchase { get; set; }

        [Required]
        [Column("IdUser")]
        public string IdUser { get; set; }

        [Required]
        [Column("Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Column("AmountTo")]
        public decimal? AmountTo { get; set; }

        [Required]
        [Column("Unit")]
        public string Unit { get; set; }

        [Required]
        [Column("CurrencyRate")]
        public decimal? CurrencyRate { get; set; }

        [Required]
        [Column("PurchaseDate")]
        public DateTime? PurchaseDate { get; set; }
       
    }
}