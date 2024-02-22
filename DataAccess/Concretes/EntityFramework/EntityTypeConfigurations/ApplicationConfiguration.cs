using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.ApplicantId).HasColumnName("ApplicantId").IsRequired();
        builder.Property(x => x.ApplicationStateId).HasColumnName("ApplicationStateId").IsRequired();
        builder.Property(x => x.BootcampId).HasColumnName("BootcampId").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasOne(p => p.Bootcamp);

        builder.HasOne(p => p.ApplicationState);
        builder.HasOne(p => p.Applicant);
    }
}
