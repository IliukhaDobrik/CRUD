using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(x => x.ContactId);

        builder.Property(x => x.ContactId).HasDefaultValueSql("newid()");
        
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.MobilePhone).HasMaxLength(13);

        builder.HasIndex(x => x.MobilePhone).IsUnique();
    }
}