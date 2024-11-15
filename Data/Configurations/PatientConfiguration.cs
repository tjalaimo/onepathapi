using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onepathapi.Models;

namespace onepathapi.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasOne(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<User>(u => u.PatientId)
                .OnDelete(DeleteBehavior.SetNull); // Set null if Provider is deleted

            // Patient has many Conditions, Medications, and Appointments
            builder.HasMany(p => p.Conditions)
                .WithOne(c => c.Patient)
                .HasForeignKey(c => c.PatientId)
                .OnDelete(DeleteBehavior.Cascade); // Conditions will be deleted if the patient is deleted

            builder.HasMany(p => p.Medications)
                .WithOne(m => m.Patient)
                .HasForeignKey(m => m.PatientId)
                .OnDelete(DeleteBehavior.Cascade); // Medications will be deleted if the patient is deleted

            builder.HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade); // Appointments will be deleted if the patient is deleted
        }
    }
}