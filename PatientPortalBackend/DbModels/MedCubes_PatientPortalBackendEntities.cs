using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PatientPortalBackend.Utils;

namespace PatientPortalBackend.DbModels;

public partial class MedCubes_PatientPortalBackendEntities : DbContext
{
    public MedCubes_PatientPortalBackendEntities()
    {
    }

    public MedCubes_PatientPortalBackendEntities(DbContextOptions<MedCubes_PatientPortalBackendEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<AppointmentRequestCount> AppointmentRequestCount { get; set; }

    public virtual DbSet<DocTypeOfPatientPortal> DocTypeOfPatientPortal { get; set; }

    public virtual DbSet<PatientAuthentication> PatientAuthentication { get; set; }

    public virtual DbSet<PatientExtension> PatientExtension { get; set; }

    public virtual DbSet<ResourceOfPatientPortal> ResourceOfPatientPortal { get; set; }

    public virtual DbSet<TenantExtension> TenantExtension { get; set; }

    public virtual DbSet<ServerConfig> ServerConfig { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer("Server=.\\mcdev22;Database=XXXX;Trusted_Connection=True;integrated security=True;TrustServerCertificate=True");
        => optionsBuilder.UseSqlServer(ConnectionStringProperties.GetInstance.GetConnectionString("MedCubes_PatientPortalBackendEntities"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppointmentRequestCount>(entity =>
        {
            entity.HasKey(e => e.PkId).IsClustered(false);

            entity.ToTable("AppointmentRequestCount", "PatientPortal");

            entity.HasIndex(e => new { e.CustomerId, e.TenantId, e.PkId }, "CL_AppointmentRequestCount")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.HardwareId).HasMaxLength(500);
            entity.Property(e => e.PatientHash).HasMaxLength(200);
            entity.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<DocTypeOfPatientPortal>(entity =>
        {
            entity.HasKey(e => e.PkId).IsClustered(false);

            entity.ToTable("DocTypeOfPatientPortal", "PatientPortal");

            entity.HasIndex(e => new { e.CustomerId, e.TenantId, e.PkId }, "CL_DocTypeOfPatientPortal")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<PatientAuthentication>(entity =>
        {
            entity.HasKey(e => e.PkId).IsClustered(false);

            entity.ToTable("PatientAuthentication", "PatientPortal");

            entity.HasIndex(e => new { e.CustomerId, e.TenantId, e.PkId }, "CL_PatientAuthentication")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.PatientHash).IsRequired();
            entity.Property(e => e.PatientIdNumber).HasMaxLength(100);
            entity.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<PatientExtension>(entity =>
        {
            entity.HasKey(e => e.PkId).IsClustered(false);

            entity.ToTable("PatientExtension", "PatientPortal");

            entity.HasIndex(e => new { e.CustomerId, e.TenantId, e.PkId }, "CL_PatientExtension")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.ConfirmationCode).HasMaxLength(50);
            entity.Property(e => e.PassHashWord).HasMaxLength(500);
            entity.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ResourceOfPatientPortal>(entity =>
        {
            entity.HasKey(e => e.PkId).IsClustered(false);

            entity.ToTable("ResourceOfPatientPortal", "PatientPortal");

            entity.HasIndex(e => new { e.CustomerId, e.TenantId, e.PkId }, "CL_ResourceOfPatientPortal")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<TenantExtension>(entity =>
        {
            entity.HasKey(e => e.PkId).IsClustered(false);

            entity.ToTable("TenantExtension", "PatientPortal");

            entity.HasIndex(e => new { e.CustomerId, e.TenantId, e.PkId }, "CL_TenantExtension")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.MedCubesIisUrl)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.PatientPortalUserName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.ResolvedUserName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ServerConfig>(entity =>
        {
            entity.HasKey(e => e.PkId).IsClustered(false);

            entity.ToTable("ServerConfig", "Framework");

            entity.HasIndex(e => new { e.CustomerId, e.TenantId, e.PkId }, "CL_ServerConfig")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.Key)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
