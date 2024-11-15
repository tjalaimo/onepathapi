using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onepathapi.Models;

public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {
        // Medication has a foreign key to Patient and Appointment
        builder.HasOne(m => m.Patient)
            .WithMany(p => p.Medications)
            .HasForeignKey(m => m.PatientId)
            .OnDelete(DeleteBehavior.Cascade); // Medication will be deleted if the patient is deleted

        builder.HasOne(m => m.Appointment)
            .WithMany()
            .HasForeignKey(m => m.AppointmentId)
            .OnDelete(DeleteBehavior.SetNull); // Medication will be set to null if appointment is deleted (not cascading)
    }
}