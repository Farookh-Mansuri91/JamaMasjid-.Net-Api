using Microsoft.EntityFrameworkCore;
using SunniNooriMasjidAPI.Data.Entities;

namespace SunniNooriMasjidAPI.Data.MasjidDbContext;

public partial class SunniNooriMasjidDbContext : DbContext
{

    public SunniNooriMasjidDbContext(DbContextOptions<SunniNooriMasjidDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Imamhistory> Imamhistories { get; set; }

    public virtual DbSet<Masjidgullak> Masjidgullaks { get; set; }

    public virtual DbSet<Masjidimam> Masjidimams { get; set; }

    public virtual DbSet<Masjidyearlyincome> Masjidyearlyincomes { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Mohalla> Mohallas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sadqamember> Sadqamembers { get; set; }

    public virtual DbSet<Village> Villages { get; set; }

    public virtual DbSet<Villagemember> Villagemembers { get; set; }

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

        modelBuilder.Entity<Masjidgullak>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("masjidgullak");

            entity.HasIndex(e => e.MemberId, "MemberId");

            entity.Property(e => e.Amount).HasPrecision(10, 2);

            entity.HasOne(d => d.Member).WithMany(p => p.Masjidgullaks)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("masjidgullak_ibfk_1");
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

        modelBuilder.Entity<Masjidyearlyincome>(entity =>
        {
            entity.HasKey(e => e.IncomeId).HasName("PRIMARY");

            entity.ToTable("masjidyearlyincome");

            entity.HasIndex(e => e.CreatedBy, "CreatedBy");

            entity.HasIndex(e => e.MohallaId, "MohallaId");

            entity.HasIndex(e => e.UpdatedBy, "UpdatedBy");

            entity.HasIndex(e => e.VillageMemberId, "VillageMemberId");

            entity.Property(e => e.MasjidIncome).HasPrecision(10, 2);
            entity.Property(e => e.MasjidProgramIncome).HasPrecision(10, 2);
            entity.Property(e => e.QabristaanIncome).HasPrecision(10, 2);
            entity.Property(e => e.Remarks).HasColumnType("text");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MasjidyearlyincomeCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("masjidyearlyincome_ibfk_4");

            entity.HasOne(d => d.Mohalla).WithMany(p => p.Masjidyearlyincomes)
                .HasForeignKey(d => d.MohallaId)
                .HasConstraintName("masjidyearlyincome_ibfk_1");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.MasjidyearlyincomeUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("masjidyearlyincome_ibfk_3");

            entity.HasOne(d => d.VillageMember).WithMany(p => p.Masjidyearlyincomes)
                .HasForeignKey(d => d.VillageMemberId)
                .HasConstraintName("masjidyearlyincome_ibfk_2");
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

        modelBuilder.Entity<Sadqamember>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PRIMARY");

            entity.ToTable("sadqamember");

            entity.HasIndex(e => e.AddedBy, "AddedBy");

            entity.Property(e => e.Amount).HasPrecision(10, 2);
            entity.Property(e => e.Caste).HasMaxLength(50);
            entity.Property(e => e.FatherName).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MobileNumber).HasMaxLength(15);
            entity.Property(e => e.Mohalla).HasMaxLength(100);
            entity.Property(e => e.PaymentDate).HasColumnType("timestamp");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.Sadqamembers)
                .HasForeignKey(d => d.AddedBy)
                .HasConstraintName("sadqamember_ibfk_1");
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

        modelBuilder.Entity<Villagemember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("villagemember");

            entity.HasIndex(e => e.MohallaId, "mohalla_id");

            entity.HasIndex(e => e.MemberId, "villagemember_ibfk_2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Caste)
                .HasMaxLength(50)
                .HasColumnName("caste");
            entity.Property(e => e.FatherName)
                .HasMaxLength(100)
                .HasColumnName("fatherName");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(15)
                .HasColumnName("mobileNumber");
            entity.Property(e => e.MohallaId).HasColumnName("mohalla_id");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("paymentDate");

            entity.HasOne(d => d.Member).WithMany(p => p.Villagemembers)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("villagemember_ibfk_2");

            entity.HasOne(d => d.Mohalla).WithMany(p => p.Villagemembers)
                .HasForeignKey(d => d.MohallaId)
                .HasConstraintName("villagemember_ibfk_1");
        });

      //  OnModelCreatingPartial(modelBuilder);
    }

   // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
