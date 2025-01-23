using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Employee_And_Company_Management.Data.Entities;

public partial class EmployeeAndCompanyManagementContext : DbContext
{
    public EmployeeAndCompanyManagementContext()
    {
    }

    public EmployeeAndCompanyManagementContext(DbContextOptions<EmployeeAndCompanyManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employment> Employments { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<QualificationLevel> QualificationLevels { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<WorkPlace> WorkPlaces { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=staff_and_structure_DB;user=root;password=marko", ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.PersonProfileId).HasName("PRIMARY");

            entity.ToTable("administrator");

            entity.Property(e => e.PersonProfileId)
                .ValueGeneratedNever()
                .HasColumnName("PERSON_PROFILE_ID");

            entity.HasOne(d => d.PersonProfile).WithOne(p => p.Administrator)
                .HasForeignKey<Administrator>(d => d.PersonProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ADMINISTRATOR_PERSON1");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PRIMARY");

            entity.ToTable("company");

            entity.HasIndex(e => e.Jib, "JIB_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ProfileId, "fk_COMPANY_PROFILE1_idx");

            entity.Property(e => e.ProfileId)
                .ValueGeneratedNever()
                .HasColumnName("PROFILE_ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.DateOfEstablishment).HasColumnName("Date_of_establishment");
            entity.Property(e => e.Jib)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("JIB");
            entity.Property(e => e.Name).HasMaxLength(45);

            entity.HasOne(d => d.Profile).WithOne(p => p.Company)
                .HasForeignKey<Company>(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_COMPANY_PROFILE1");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("department");

            entity.HasIndex(e => e.CompanyProfileId, "fk_DEPARTMENT_COMPANY1_idx");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyProfileId).HasColumnName("COMPANY_PROFILE_ID");
            entity.Property(e => e.Name).HasMaxLength(45);

            entity.HasOne(d => d.CompanyProfile).WithMany(p => p.Departments)
                .HasForeignKey(d => d.CompanyProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DEPARTMENT_COMPANY1");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.PersonProfileId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.QualificationLevelId, "fk_EMPLOYEE_QUALIFICATION_LEVEL1_idx");

            entity.Property(e => e.PersonProfileId)
                .ValueGeneratedNever()
                .HasColumnName("PERSON_PROFILE_ID");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_of_birth");
            entity.Property(e => e.IsEmployed).HasColumnName("Is_employed");
            entity.Property(e => e.QualificationLevelId).HasColumnName("QUALIFICATION_LEVEL_ID");

            entity.HasOne(d => d.PersonProfile).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.PersonProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EMPLOYEE_PERSON1");

            entity.HasOne(d => d.QualificationLevel).WithMany(p => p.Employees)
                .HasForeignKey(d => d.QualificationLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EMPLOYEE_QUALIFICATION_LEVEL1");
        });

        modelBuilder.Entity<Employment>(entity =>
        {
            entity.HasKey(e => new { e.EmployedFrom, e.WorkPlaceId, e.CompanyProfileId, e.EmployeePersonProfileId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity.ToTable("employment");

            entity.HasIndex(e => e.CompanyProfileId, "fk_EMPLOYMENT_COMPANY1_idx");

            entity.HasIndex(e => e.EmployeePersonProfileId, "fk_EMPLOYMENT_EMPLOYEE1_idx");

            entity.HasIndex(e => e.WorkPlaceId, "fk_EMPLOYMENT_WORK_PLACE1_idx");

            entity.Property(e => e.EmployedFrom).HasColumnName("Employed_from");
            entity.Property(e => e.WorkPlaceId).HasColumnName("WORK_PLACE_ID");
            entity.Property(e => e.CompanyProfileId).HasColumnName("COMPANY_PROFILE_ID");
            entity.Property(e => e.EmployeePersonProfileId).HasColumnName("EMPLOYEE_PERSON_PROFILE_ID");
            entity.Property(e => e.EmployedTo).HasColumnName("Employed_to");
            entity.Property(e => e.NumberOfDaysOff).HasColumnName("Number_of_days_off");
            entity.Property(e => e.PriceOfWork)
                .HasPrecision(4)
                .HasColumnName("Price_of_work");

            entity.HasOne(d => d.CompanyProfile).WithMany(p => p.Employments)
                .HasForeignKey(d => d.CompanyProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EMPLOYMENT_COMPANY1");

            entity.HasOne(d => d.EmployeePersonProfile).WithMany(p => p.Employments)
                .HasForeignKey(d => d.EmployeePersonProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EMPLOYMENT_EMPLOYEE1");

            entity.HasOne(d => d.WorkPlace).WithMany(p => p.Employments)
                .HasForeignKey(d => d.WorkPlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EMPLOYMENT_WORK_PLACE1");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PRIMARY");

            entity.ToTable("person");

            entity.HasIndex(e => e.ProfileId, "fk_PERSON_PROFILE1_idx");

            entity.Property(e => e.ProfileId)
                .ValueGeneratedNever()
                .HasColumnName("PROFILE_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("First_name");
            entity.Property(e => e.Jmb)
                .HasMaxLength(13)
                .IsFixedLength()
                .HasColumnName("JMB");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("Last_name");

            entity.HasOne(d => d.Profile).WithOne(p => p.Person)
                .HasForeignKey<Person>(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PERSON_PROFILE1");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("profile");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Language).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.Theme).HasMaxLength(45);
            entity.Property(e => e.Username).HasMaxLength(45);
        });

        modelBuilder.Entity<QualificationLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("qualification_level");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.QualificationCode)
                .HasMaxLength(45)
                .HasColumnName("Qualification_code");
            entity.Property(e => e.Title).HasMaxLength(45);
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("salary");

            entity.HasIndex(e => new { e.EmploymentEmployedFrom, e.EmploymentWorkPlaceId, e.EmploymentCompanyProfileId, e.EmploymentEmployeePersonProfileId }, "fk_SALARY_EMPLOYMENT1_idx");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasPrecision(4);
            entity.Property(e => e.EmploymentCompanyProfileId).HasColumnName("EMPLOYMENT_COMPANY_PROFILE_ID");
            entity.Property(e => e.EmploymentEmployedFrom).HasColumnName("EMPLOYMENT_Employed_from");
            entity.Property(e => e.EmploymentEmployeePersonProfileId).HasColumnName("EMPLOYMENT_EMPLOYEE_PERSON_PROFILE_ID");
            entity.Property(e => e.EmploymentWorkPlaceId).HasColumnName("EMPLOYMENT_WORK_PLACE_ID");
            entity.Property(e => e.ForMonth).HasColumnName("For_month");
            entity.Property(e => e.ForYear).HasColumnName("For_year");
            entity.Property(e => e.PaymentDate).HasColumnName("Payment_date");

            entity.HasOne(d => d.Employment).WithMany(p => p.Salaries)
                .HasForeignKey(d => new { d.EmploymentEmployedFrom, d.EmploymentWorkPlaceId, d.EmploymentCompanyProfileId, d.EmploymentEmployeePersonProfileId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_SALARY_EMPLOYMENT1");
        });

        modelBuilder.Entity<WorkPlace>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("work_place");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(45);

            entity.HasOne(wp => wp.Department)
            .WithMany(d => d.WorkPlaces)
            .HasForeignKey(wp => wp.DepartmentId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_WORK_PLACE_DEPARTMENT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
