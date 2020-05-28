using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using eHealthcare.Models;

namespace eHealthcare.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Consultation> Consultation { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<MedicalCentre> MedicalCentre { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectronicHealthCareSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultation>(entity =>
            {
                entity.Property(e => e.ConsultationDate).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Consultation)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Consultation_Doctor");

                entity.HasOne(d => d.MedicalCentre)
                    .WithMany(p => p.Consultation)
                    .HasForeignKey(d => d.MedicalCentreId)
                    .HasConstraintName("FK_Consultation_MedicalCentre");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Consultation)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Consultation_Patient");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.PersonId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Speciality).HasMaxLength(50);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Doctor_Person");
            });

            modelBuilder.Entity<MedicalCentre>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.StreetNo).HasMaxLength(50);

                entity.Property(e => e.Suburb).HasMaxLength(50);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MedicalCentre)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_MedicalCentre_Doctor");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.MedicareNum).HasMaxLength(50);

                entity.Property(e => e.PatientEmail)
                    .HasColumnName("Patient_Email")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Patient_Person");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Suburb).HasMaxLength(255);

                //entity.HasOne(d => d.IdNavigation)
                //    .WithOne(p => p.Person)
                //    .HasForeignKey<Person>(d => d.Id)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Person_Doctor");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(e => e.Dosage).HasMaxLength(50);

                entity.Property(e => e.MedicationName).HasMaxLength(255);

                entity.HasOne(d => d.Consultation)
                    .WithMany(p => p.Subscription)
                    .HasForeignKey(d => d.ConsultationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subscription_Consultation");
            });

            //OnModelCreatingPartial(modelBuilder);
        }
    }
}
