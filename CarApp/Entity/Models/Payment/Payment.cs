namespace Entity.Models.Payment
{
    public class Payment : EntityBaseClass
    {
        public long? SubscriptionId { get; set; }
        public Subscription subscription { get; set; }
        public long PaymentDetailsId { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }
}