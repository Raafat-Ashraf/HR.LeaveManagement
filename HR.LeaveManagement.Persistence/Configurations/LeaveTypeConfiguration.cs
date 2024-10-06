using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);



        builder.HasData(new LeaveType()
        {
            Id = 1,
            Name = "Vacation",
            DefaultDays = 10,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now
        });
    }
}
