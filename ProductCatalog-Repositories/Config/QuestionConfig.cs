using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories.Config
{
    public class QuestionConfig : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {
            builder.HasOne(q => q.Customer).WithMany(c => c.Questions).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
