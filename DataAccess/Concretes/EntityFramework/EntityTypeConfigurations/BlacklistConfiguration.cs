using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class BlacklistConfiguration : IEntityTypeConfiguration<Blacklist>
{
    public void Configure(EntityTypeBuilder<Blacklist> builder)
    {
        builder.ToTable("Blacklist").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.Reason).HasColumnName("Reason").IsRequired();
        builder.Property(x => x.Date).HasColumnName("BlacklistDate").IsRequired();
        builder.Property(x => x.ApplicantId).HasColumnName("ApplicantId").IsRequired();

        builder.HasOne(x => x.Applicant);
        
    }
}
