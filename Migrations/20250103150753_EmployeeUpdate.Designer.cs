﻿// <auto-generated />
using System;
using Employee_And_Company_Management.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Employee_And_Company_Management.Migrations
{
    [DbContext(typeof(EmployeeAndCompanyManagementContext))]
    [Migration("20250103150753_EmployeeUpdate")]
    partial class EmployeeUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb3_general_ci")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb3");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Administrator", b =>
                {
                    b.Property<int>("PersonProfileId")
                        .HasColumnType("int")
                        .HasColumnName("PERSON_PROFILE_ID");

                    b.HasKey("PersonProfileId")
                        .HasName("PRIMARY");

                    b.ToTable("administrator", (string)null);
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Company", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("int")
                        .HasColumnName("PROFILE_ID");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<DateOnly>("DateOfEstablishment")
                        .HasColumnType("date")
                        .HasColumnName("Date_of_establishment");

                    b.Property<string>("Jib")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("char(12)")
                        .HasColumnName("JIB")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("ProfileId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Jib" }, "JIB_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "ProfileId" }, "fk_COMPANY_PROFILE1_idx");

                    b.ToTable("company", (string)null);
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyProfileId")
                        .HasColumnType("int")
                        .HasColumnName("COMPANY_PROFILE_ID");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CompanyProfileId" }, "fk_DEPARTMENT_COMPANY1_idx");

                    b.ToTable("department", (string)null);
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Employee", b =>
                {
                    b.Property<int>("PersonProfileId")
                        .HasColumnType("int")
                        .HasColumnName("PERSON_PROFILE_ID");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("Date_of_birth");

                    b.Property<bool>("IsEmployed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Is_employed");

                    b.Property<int>("QualificationLevelId")
                        .HasColumnType("int")
                        .HasColumnName("QUALIFICATION_LEVEL_ID");

                    b.HasKey("PersonProfileId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "QualificationLevelId" }, "fk_EMPLOYEE_QUALIFICATION_LEVEL1_idx");

                    b.ToTable("employee", (string)null);
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Employment", b =>
                {
                    b.Property<DateOnly>("EmployedFrom")
                        .HasColumnType("date")
                        .HasColumnName("Employed_from");

                    b.Property<int>("WorkPlaceId")
                        .HasColumnType("int")
                        .HasColumnName("WORK_PLACE_ID");

                    b.Property<int>("CompanyProfileId")
                        .HasColumnType("int")
                        .HasColumnName("COMPANY_PROFILE_ID");

                    b.Property<int>("EmployeePersonProfileId")
                        .HasColumnType("int")
                        .HasColumnName("EMPLOYEE_PERSON_PROFILE_ID");

                    b.Property<DateOnly?>("EmployedTo")
                        .HasColumnType("date")
                        .HasColumnName("Employed_to");

                    b.Property<int>("NumberOfDaysOff")
                        .HasColumnType("int")
                        .HasColumnName("Number_of_days_off");

                    b.Property<decimal>("PriceOfWork")
                        .HasPrecision(4)
                        .HasColumnType("decimal(4)")
                        .HasColumnName("Price_of_work");

                    b.HasKey("EmployedFrom", "WorkPlaceId", "CompanyProfileId", "EmployeePersonProfileId")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                    b.HasIndex(new[] { "CompanyProfileId" }, "fk_EMPLOYMENT_COMPANY1_idx");

                    b.HasIndex(new[] { "EmployeePersonProfileId" }, "fk_EMPLOYMENT_EMPLOYEE1_idx");

                    b.HasIndex(new[] { "WorkPlaceId" }, "fk_EMPLOYMENT_WORK_PLACE1_idx");

                    b.ToTable("employment", (string)null);
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Person", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("int")
                        .HasColumnName("PROFILE_ID");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("First_name");

                    b.Property<string>("Jmb")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("char(13)")
                        .HasColumnName("JMB")
                        .IsFixedLength();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Last_name");

                    b.HasKey("ProfileId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProfileId" }, "fk_PERSON_PROFILE1_idx");

                    b.ToTable("person", (string)null);
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("profile", (string)null);
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.QualificationLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("QualificationCode")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Qualification_code");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("qualification_level", (string)null);
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(4)
                        .HasColumnType("decimal(4)");

                    b.Property<int>("EmploymentCompanyProfileId")
                        .HasColumnType("int")
                        .HasColumnName("EMPLOYMENT_COMPANY_PROFILE_ID");

                    b.Property<DateOnly>("EmploymentEmployedFrom")
                        .HasColumnType("date")
                        .HasColumnName("EMPLOYMENT_Employed_from");

                    b.Property<int>("EmploymentEmployeePersonProfileId")
                        .HasColumnType("int")
                        .HasColumnName("EMPLOYMENT_EMPLOYEE_PERSON_PROFILE_ID");

                    b.Property<int>("EmploymentWorkPlaceId")
                        .HasColumnType("int")
                        .HasColumnName("EMPLOYMENT_WORK_PLACE_ID");

                    b.Property<int>("ForMonth")
                        .HasColumnType("int")
                        .HasColumnName("For_month");

                    b.Property<int>("ForYear")
                        .HasColumnType("int")
                        .HasColumnName("For_year");

                    b.Property<DateOnly>("PaymentDate")
                        .HasColumnType("date")
                        .HasColumnName("Payment_date");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "EmploymentEmployedFrom", "EmploymentWorkPlaceId", "EmploymentCompanyProfileId", "EmploymentEmployeePersonProfileId" }, "fk_SALARY_EMPLOYMENT1_idx");

                    b.ToTable("salary", (string)null);
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.WorkPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("DepartmentId");

                    b.ToTable("work_place", (string)null);
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Administrator", b =>
                {
                    b.HasOne("Employee_And_Company_Management.Data.Entities.Person", "PersonProfile")
                        .WithOne("Administrator")
                        .HasForeignKey("Employee_And_Company_Management.Data.Entities.Administrator", "PersonProfileId")
                        .IsRequired()
                        .HasConstraintName("fk_ADMINISTRATOR_PERSON1");

                    b.Navigation("PersonProfile");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Company", b =>
                {
                    b.HasOne("Employee_And_Company_Management.Data.Entities.Profile", "Profile")
                        .WithOne("Company")
                        .HasForeignKey("Employee_And_Company_Management.Data.Entities.Company", "ProfileId")
                        .IsRequired()
                        .HasConstraintName("fk_COMPANY_PROFILE1");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Department", b =>
                {
                    b.HasOne("Employee_And_Company_Management.Data.Entities.Company", "CompanyProfile")
                        .WithMany("Departments")
                        .HasForeignKey("CompanyProfileId")
                        .IsRequired()
                        .HasConstraintName("fk_DEPARTMENT_COMPANY1");

                    b.Navigation("CompanyProfile");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Employee", b =>
                {
                    b.HasOne("Employee_And_Company_Management.Data.Entities.Person", "PersonProfile")
                        .WithOne("Employee")
                        .HasForeignKey("Employee_And_Company_Management.Data.Entities.Employee", "PersonProfileId")
                        .IsRequired()
                        .HasConstraintName("fk_EMPLOYEE_PERSON1");

                    b.HasOne("Employee_And_Company_Management.Data.Entities.QualificationLevel", "QualificationLevel")
                        .WithMany("Employees")
                        .HasForeignKey("QualificationLevelId")
                        .IsRequired()
                        .HasConstraintName("fk_EMPLOYEE_QUALIFICATION_LEVEL1");

                    b.Navigation("PersonProfile");

                    b.Navigation("QualificationLevel");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Employment", b =>
                {
                    b.HasOne("Employee_And_Company_Management.Data.Entities.Company", "CompanyProfile")
                        .WithMany("Employments")
                        .HasForeignKey("CompanyProfileId")
                        .IsRequired()
                        .HasConstraintName("fk_EMPLOYMENT_COMPANY1");

                    b.HasOne("Employee_And_Company_Management.Data.Entities.Employee", "EmployeePersonProfile")
                        .WithMany("Employments")
                        .HasForeignKey("EmployeePersonProfileId")
                        .IsRequired()
                        .HasConstraintName("fk_EMPLOYMENT_EMPLOYEE1");

                    b.HasOne("Employee_And_Company_Management.Data.Entities.WorkPlace", "WorkPlace")
                        .WithMany("Employments")
                        .HasForeignKey("WorkPlaceId")
                        .IsRequired()
                        .HasConstraintName("fk_EMPLOYMENT_WORK_PLACE1");

                    b.Navigation("CompanyProfile");

                    b.Navigation("EmployeePersonProfile");

                    b.Navigation("WorkPlace");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Person", b =>
                {
                    b.HasOne("Employee_And_Company_Management.Data.Entities.Profile", "Profile")
                        .WithOne("Person")
                        .HasForeignKey("Employee_And_Company_Management.Data.Entities.Person", "ProfileId")
                        .IsRequired()
                        .HasConstraintName("fk_PERSON_PROFILE1");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Salary", b =>
                {
                    b.HasOne("Employee_And_Company_Management.Data.Entities.Employment", "Employment")
                        .WithMany("Salaries")
                        .HasForeignKey("EmploymentEmployedFrom", "EmploymentWorkPlaceId", "EmploymentCompanyProfileId", "EmploymentEmployeePersonProfileId")
                        .IsRequired()
                        .HasConstraintName("fk_SALARY_EMPLOYMENT1");

                    b.Navigation("Employment");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.WorkPlace", b =>
                {
                    b.HasOne("Employee_And_Company_Management.Data.Entities.Department", "Department")
                        .WithMany("WorkPlaces")
                        .HasForeignKey("DepartmentId")
                        .IsRequired()
                        .HasConstraintName("fk_WORK_PLACE_DEPARTMENT");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Company", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Employments");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Department", b =>
                {
                    b.Navigation("WorkPlaces");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Employee", b =>
                {
                    b.Navigation("Employments");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Employment", b =>
                {
                    b.Navigation("Salaries");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Person", b =>
                {
                    b.Navigation("Administrator");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.Profile", b =>
                {
                    b.Navigation("Company");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.QualificationLevel", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Employee_And_Company_Management.Data.Entities.WorkPlace", b =>
                {
                    b.Navigation("Employments");
                });
#pragma warning restore 612, 618
        }
    }
}
