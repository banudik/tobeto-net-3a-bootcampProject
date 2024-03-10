using Core.Utilities.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(t => t.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.UserId).HasColumnName("UserId");
        builder.Property(x => x.OperationClaimId).HasColumnName("OperationClaimId");

        builder.HasOne(t => t.User);
        builder.HasOne(t => t.OperationClaim);
        
    }
}
