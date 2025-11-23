using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using SunniNooriMasjidAPI.Data.Entities;

namespace SunniNooriMasjidAPI.Data.MasjidDbContext;

public partial class SunniNooriMasjidDbContext : DbContext
{
    public SunniNooriMasjidDbContext()
    {
    }

    public SunniNooriMasjidDbContext(DbContextOptions<SunniNooriMasjidDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Imamhistory> Imamhistories { get; set; }

    public virtual DbSet<MasjidGullakCollection> MasjidGullakCollections { get; set; }

    public virtual DbSet<Masjidimam> Masjidimams { get; set; }

    public virtual DbSet<Masjidincome> Masjidincomes { get; set; }

    public virtual DbSet<Masjidyearlyexpense> Masjidyearlyexpenses { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Mohalla> Mohallas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SadqaMembersPayment> SadqaMembersPayments { get; set; }

    public virtual DbSet<SadqaPayment> SadqaPayments { get; set; }

    public virtual DbSet<SalaryPayment> SalaryPayments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Village> Villages { get; set; }

    public virtual DbSet<VillageMembersPayment> VillageMembersPayments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Imamhistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imamhistory");

            entity.HasIndex(e => e.ImamId, "imamId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignmentDate).HasColumnName("assignmentDate");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.ImamId).HasColumnName("imamId");
            entity.Property(e => e.MasjidAddress)
                .HasMaxLength(255)
                .HasColumnName("masjidAddress");
            entity.Property(e => e.Remarks)
                .HasColumnType("text")
                .HasColumnName("remarks");
            entity.Property(e => e.RoleDescription)
                .HasColumnType("text")
                .HasColumnName("roleDescription");
            entity.Property(e => e.Salary)
                .HasPrecision(10, 2)
                .HasColumnName("salary");

            entity.HasOne(d => d.Imam).WithMany(p => p.Imamhistories)
                .HasForeignKey(d => d.ImamId)
                .HasConstraintName("imamhistory_ibfk_1");
        });

        modelBuilder.Entity<MasjidGullakCollection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("masjid_gullak_collection");

            entity.HasIndex(e => e.CreatedBy, "FK_CreatedBy");

            entity.HasIndex(e => e.UpdatedBy, "FK_UpdatedBy");

            entity.HasIndex(e => e.VillageId, "FK_Village_ID");

            entity.Property(e => e.Amount).HasPrecision(10, 2);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.UpdatedOn)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MasjidGullakCollectionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreatedBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.MasjidGullakCollectionUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UpdatedBy");

            entity.HasOne(d => d.Village).WithMany(p => p.MasjidGullakCollections)
                .HasForeignKey(d => d.VillageId)
                .HasConstraintName("FK_Village_ID");
        });

        modelBuilder.Entity<Masjidimam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("masjidimam");

            entity.HasIndex(e => e.RoleId, "roleId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Bio)
                .HasColumnType("text")
                .HasColumnName("bio");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(255)
                .HasColumnName("contactNumber");
            entity.Property(e => e.Education)
                .HasMaxLength(255)
                .HasColumnName("education");
            entity.Property(e => e.FatherName)
                .HasMaxLength(255)
                .HasColumnName("fatherName");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.ImamName)
                .HasMaxLength(255)
                .HasColumnName("imamName");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("isActive");
            entity.Property(e => e.JoinedDate).HasColumnName("joinedDate");
            entity.Property(e => e.LastServingDay).HasColumnName("lastServingDay");
            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("'1'")
                .HasColumnName("roleId");
            entity.Property(e => e.Salary)
                .HasPrecision(10, 2)
                .HasColumnName("salary");
            entity.Property(e => e.TotalService)
                .HasMaxLength(50)
                .HasColumnName("totalService");
            entity.Property(e => e.Vision)
                .HasColumnType("text")
                .HasColumnName("vision");

            entity.HasOne(d => d.Role).WithMany(p => p.Masjidimams)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("masjidimam_ibfk_1");
        });

        modelBuilder.Entity<Masjidincome>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("masjidincome");

            entity.HasIndex(e => new { e.VillageMemberId, e.Year }, "idx_member_year");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.MasjidAmount).HasPrecision(18, 2);
            entity.Property(e => e.MasjidProgamAmount).HasPrecision(18, 2);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.QabristanAmount).HasPrecision(18, 2);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.VillageMember).WithMany(p => p.Masjidincomes)
                .HasForeignKey(d => d.VillageMemberId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("masjidincome_ibfk_1");
        });

        modelBuilder.Entity<Masjidyearlyexpense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("masjidyearlyexpenses");

            entity.HasIndex(e => e.MemberId, "MemberId");

            entity.Property(e => e.Amount).HasPrecision(10, 2);
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.PaidTo).HasMaxLength(100);

            entity.HasOne(d => d.Member).WithMany(p => p.Masjidyearlyexpenses)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("masjidyearlyexpenses_ibfk_1");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("members");

            entity.HasIndex(e => e.MohallaId, "fk_mohalla_id");

            entity.HasIndex(e => e.RoleId, "fk_role_id");

            entity.Property(e => e.FatherName)
                .HasMaxLength(100)
                .HasColumnName("fatherName");
            entity.Property(e => e.JoiningDate).HasColumnName("joiningDate");
            entity.Property(e => e.MemberPic)
                .HasMaxLength(255)
                .HasColumnName("memberPic");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(15)
                .HasColumnName("mobileNumber");
            entity.Property(e => e.MohallaId).HasColumnName("mohalla_id");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Mohalla).WithMany(p => p.Members)
                .HasForeignKey(d => d.MohallaId)
                .HasConstraintName("fk_mohalla_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Members)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_id");
        });

        modelBuilder.Entity<Mohalla>(entity =>
        {
            entity.HasKey(e => e.MohallaId).HasName("PRIMARY");

            entity.ToTable("mohallas");

            entity.HasIndex(e => e.VillageId, "village_id");

            entity.Property(e => e.MohallaId).HasColumnName("mohalla_id");
            entity.Property(e => e.MohallaName)
                .HasMaxLength(255)
                .HasColumnName("mohalla_name");
            entity.Property(e => e.Population).HasColumnName("population");
            entity.Property(e => e.VillageId).HasColumnName("village_id");

            entity.HasOne(d => d.Village).WithMany(p => p.Mohallas)
                .HasForeignKey(d => d.VillageId)
                .HasConstraintName("mohallas_ibfk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasDefaultValueSql("'Member'")
                .HasColumnType("enum('Imam','President','Secretary','Treasurer','Member','Other')")
                .HasColumnName("role_name");
            entity.Property(e => e.RoleType)
                .HasMaxLength(50)
                .HasColumnName("role_type");
        });

        modelBuilder.Entity<SadqaMembersPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sadqa_members_payment");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.FatherName)
                .HasMaxLength(100)
                .HasColumnName("fatherName");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("'1'")
                .HasColumnName("isActive");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .HasColumnName("mobileNumber");
            entity.Property(e => e.MohallaId).HasColumnName("mohallaId");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.VillageId).HasColumnName("villageId");
        });

        modelBuilder.Entity<SadqaPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sadqa_payments");

            entity.HasIndex(e => e.MemberId, "memberId");

            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.Month)
                .HasMaxLength(50)
                .HasColumnName("month");
            entity.Property(e => e.PaymentDate).HasColumnName("paymentDate");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Member).WithMany(p => p.SadqaPayments)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sadqa_payments_ibfk_1");
        });

        modelBuilder.Entity<SalaryPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");

            entity.ToTable("salary_payments");

            entity.HasIndex(e => e.MemberId, "memberId");

            entity.Property(e => e.PaymentId).HasColumnName("paymentId");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.PaymentDate).HasColumnName("paymentDate");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Member).WithMany(p => p.SalaryPayments)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("salary_payments_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.HasIndex(e => e.MemberId, "fk_member_id");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PasswordHash).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.Member).WithMany(p => p.Users)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("fk_member_id");
        });

        modelBuilder.Entity<Village>(entity =>
        {
            entity.HasKey(e => e.VillageId).HasName("PRIMARY");

            entity.ToTable("villages");

            entity.Property(e => e.VillageId).HasColumnName("village_id");
            entity.Property(e => e.AreaSize)
                .HasPrecision(10, 2)
                .HasColumnName("area_size");
            entity.Property(e => e.EstablishedDate).HasColumnName("established_date");
            entity.Property(e => e.TotalPopulation).HasColumnName("total_population");
            entity.Property(e => e.VillageName)
                .HasMaxLength(255)
                .HasColumnName("village_name");
        });

        modelBuilder.Entity<VillageMembersPayment>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PRIMARY");

            entity.ToTable("village_members_payment");

            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.FatherName)
                .HasMaxLength(100)
                .HasColumnName("fatherName");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .HasColumnName("mobileNumber");
            entity.Property(e => e.MohallaId).HasColumnName("mohallaId");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.VillageId).HasColumnName("villageId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
