using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Entity.Models.Offers;

namespace Entity.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.
                Property(p => p.Title).
                HasColumnType("nvarchar");

            builder.
                Property(p => p.Description).
                HasColumnType("nvarchar");

            builder.
                Property(p => p.UserId).
                HasColumnType("int").
                IsRequired();

            builder.
                HasOne(x => x.User).WithMany(x => x.Offers).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
