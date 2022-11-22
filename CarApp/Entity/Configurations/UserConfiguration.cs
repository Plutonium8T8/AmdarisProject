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

namespace Entity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.
                Property(p => p.DOB).
                HasColumnType("date");

            builder.
                HasMany(x => x.Offers).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
