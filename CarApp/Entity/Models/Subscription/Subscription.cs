
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    public class Subscription : EntityBaseClass
    {
        public long UserId { get; set; }
        public virtual User Customer { get; set; }
        public long OfferId { get; set; }
        public virtual Offer Offer { get; set; }

        [Required]
        public DateTime SubscriptionStartTimestamp { get; set; }
        [Required]
        public DateTime SubscriptionStopTimestamp { get; set; }

        [NotMapped]
        public bool IsActive { get => DateTime.Compare(SubscriptionStartTimestamp, SubscriptionStopTimestamp) <= 0; }
    }
}
