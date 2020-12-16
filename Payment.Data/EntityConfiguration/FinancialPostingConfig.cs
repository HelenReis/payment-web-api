using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.EntityConfiguration
{
    internal class FinancialPostingConfig : IEntityTypeConfiguration<FinancialPosting>
    {
        public void Configure(EntityTypeBuilder<FinancialPosting> builder)
        {
            builder.HasOne(x => x.BankAccount)
                .WithMany(y => y.FinancialPostings)
                .HasForeignKey(y => y.BankAccountId);
        }
    }
}
