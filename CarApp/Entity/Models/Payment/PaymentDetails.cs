using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Payment
{
    public class PaymentDetails : EntityBaseClass
    {
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

    }
}