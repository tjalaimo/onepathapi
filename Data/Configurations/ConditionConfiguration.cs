using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onepathapi.Models;

public class ConditionConfiguration : IEntityTypeConfiguration<Condition>
{
    public void Configure(EntityTypeBuilder<Condition> builder)
    {
        // Condition has a foreign key to Patient and Appointment
        builder.HasOne(c => c.Patient)
            .WithMany(p => p.Conditions)
            .HasForeignKey(c => c.PatientId)
            .OnDelete(DeleteBehavior.Cascade); // Condition will be deleted if the patient is deleted

        builder.HasOne(c => c.Appointment)
            .WithMany()
            .HasForeignKey(c => c.AppointmentId)
            .OnDelete(DeleteBehavior.SetNull); // Condition will be set to null if appointment is deleted (not cascading)
    }
}