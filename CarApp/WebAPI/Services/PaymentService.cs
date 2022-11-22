using Entity;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task CreateCharge(string token, int amount, string currency, string description)
        {
            try
            {
                var options = new ChargeCreateOptions
                {
                    Amount = amount,
                    Currency = currency,
                    Source = token,
                    Description = description
                };

                var service = new ChargeService();

                service.Create(options);
            }
            catch (StripeException e)
            {
                return;
            }
        }
    }
}
