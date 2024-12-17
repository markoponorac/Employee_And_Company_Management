using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_And_Company_Management.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Password = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Theme = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Language = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "qualification_level",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Qualification_code = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "work_place",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Description = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    PROFILE_ID = table.Column<int>(type: "int", nullable: false),
                    JIB = table.Column<string>(type: "char(12)", fixedLength: true, maxLength: 12, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Date_of_establishment = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PROFILE_ID);
                    table.ForeignKey(
                        name: "fk_COMPANY_PROFILE1",
                        column: x => x.PROFILE_ID,
                        principalTable: "profile",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    PROFILE_ID = table.Column<int>(type: "int", nullable: false),
                    JMB = table.Column<string>(type: "char(13)", fixedLength: true, maxLength: 13, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    First_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Last_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PROFILE_ID);
                    table.ForeignKey(
                        name: "fk_PERSON_PROFILE1",
                        column: x => x.PROFILE_ID,
                        principalTable: "profile",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    COMPANY_PROFILE_ID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "fk_DEPARTMENT_COMPANY1",
                        column: x => x.COMPANY_PROFILE_ID,
                        principalTable: "company",
                        principalColumn: "PROFILE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "administrator",
                columns: table => new
                {
                    PERSON_PROFILE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PERSON_PROFILE_ID);
                    table.ForeignKey(
                        name: "fk_ADMINISTRATOR_PERSON1",
                        column: x => x.PERSON_PROFILE_ID,
                        principalTable: "person",
                        principalColumn: "PROFILE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    PERSON_PROFILE_ID = table.Column<int>(type: "int", nullable: false),
                    Date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    Is_employed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    QUALIFICATION_LEVEL_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PERSON_PROFILE_ID);
                    table.ForeignKey(
                        name: "fk_EMPLOYEE_PERSON1",
                        column: x => x.PERSON_PROFILE_ID,
                        principalTable: "person",
                        principalColumn: "PROFILE_ID");
                    table.ForeignKey(
                        name: "fk_EMPLOYEE_QUALIFICATION_LEVEL1",
                        column: x => x.QUALIFICATION_LEVEL_ID,
                        principalTable: "qualification_level",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "work_place_has_department",
                columns: table => new
                {
                    WORK_PLACE_ID = table.Column<int>(type: "int", nullable: false),
                    DEPARTMENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.WORK_PLACE_ID, x.DEPARTMENT_ID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "fk_WORK_PLACE_has_DEPARTMENT_DEPARTMENT1",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "department",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_WORK_PLACE_has_DEPARTMENT_WORK_PLACE1",
                        column: x => x.WORK_PLACE_ID,
                        principalTable: "work_place",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "employment",
                columns: table => new
                {
                    Employed_from = table.Column<DateOnly>(type: "date", nullable: false),
                    WORK_PLACE_ID = table.Column<int>(type: "int", nullable: false),
                    COMPANY_PROFILE_ID = table.Column<int>(type: "int", nullable: false),
                    EMPLOYEE_PERSON_PROFILE_ID = table.Column<int>(type: "int", nullable: false),
                    Employed_to = table.Column<DateOnly>(type: "date", nullable: true),
                    Price_of_work = table.Column<decimal>(type: "decimal(4)", precision: 4, nullable: false),
                    Number_of_days_off = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Employed_from, x.WORK_PLACE_ID, x.COMPANY_PROFILE_ID, x.EMPLOYEE_PERSON_PROFILE_ID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });
                    table.ForeignKey(
                        name: "fk_EMPLOYMENT_COMPANY1",
                        column: x => x.COMPANY_PROFILE_ID,
                        principalTable: "company",
                        principalColumn: "PROFILE_ID");
                    table.ForeignKey(
                        name: "fk_EMPLOYMENT_EMPLOYEE1",
                        column: x => x.EMPLOYEE_PERSON_PROFILE_ID,
                        principalTable: "employee",
                        principalColumn: "PERSON_PROFILE_ID");
                    table.ForeignKey(
                        name: "fk_EMPLOYMENT_WORK_PLACE1",
                        column: x => x.WORK_PLACE_ID,
                        principalTable: "work_place",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "salary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(type: "decimal(4)", precision: 4, nullable: false),
                    Payment_date = table.Column<DateOnly>(type: "date", nullable: false),
                    For_month = table.Column<int>(type: "int", nullable: false),
                    For_year = table.Column<int>(type: "int", nullable: false),
                    EMPLOYMENT_Employed_from = table.Column<DateOnly>(type: "date", nullable: false),
                    EMPLOYMENT_WORK_PLACE_ID = table.Column<int>(type: "int", nullable: false),
                    EMPLOYMENT_COMPANY_PROFILE_ID = table.Column<int>(type: "int", nullable: false),
                    EMPLOYMENT_EMPLOYEE_PERSON_PROFILE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "fk_SALARY_EMPLOYMENT1",
                        columns: x => new { x.EMPLOYMENT_Employed_from, x.EMPLOYMENT_WORK_PLACE_ID, x.EMPLOYMENT_COMPANY_PROFILE_ID, x.EMPLOYMENT_EMPLOYEE_PERSON_PROFILE_ID },
                        principalTable: "employment",
                        principalColumns: new[] { "Employed_from", "WORK_PLACE_ID", "COMPANY_PROFILE_ID", "EMPLOYEE_PERSON_PROFILE_ID" });
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "fk_COMPANY_PROFILE1_idx",
                table: "company",
                column: "PROFILE_ID");

            migrationBuilder.CreateIndex(
                name: "JIB_UNIQUE",
                table: "company",
                column: "JIB",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_DEPARTMENT_COMPANY1_idx",
                table: "department",
                column: "COMPANY_PROFILE_ID");

            migrationBuilder.CreateIndex(
                name: "fk_EMPLOYEE_QUALIFICATION_LEVEL1_idx",
                table: "employee",
                column: "QUALIFICATION_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "fk_EMPLOYMENT_COMPANY1_idx",
                table: "employment",
                column: "COMPANY_PROFILE_ID");

            migrationBuilder.CreateIndex(
                name: "fk_EMPLOYMENT_EMPLOYEE1_idx",
                table: "employment",
                column: "EMPLOYEE_PERSON_PROFILE_ID");

            migrationBuilder.CreateIndex(
                name: "fk_EMPLOYMENT_WORK_PLACE1_idx",
                table: "employment",
                column: "WORK_PLACE_ID");

            migrationBuilder.CreateIndex(
                name: "fk_PERSON_PROFILE1_idx",
                table: "person",
                column: "PROFILE_ID");

            migrationBuilder.CreateIndex(
                name: "JMB_UNIQUE",
                table: "person",
                column: "JMB",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_SALARY_EMPLOYMENT1_idx",
                table: "salary",
                columns: new[] { "EMPLOYMENT_Employed_from", "EMPLOYMENT_WORK_PLACE_ID", "EMPLOYMENT_COMPANY_PROFILE_ID", "EMPLOYMENT_EMPLOYEE_PERSON_PROFILE_ID" });

            migrationBuilder.CreateIndex(
                name: "fk_WORK_PLACE_has_DEPARTMENT_DEPARTMENT1_idx",
                table: "work_place_has_department",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "fk_WORK_PLACE_has_DEPARTMENT_WORK_PLACE1_idx",
                table: "work_place_has_department",
                column: "WORK_PLACE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrator");

            migrationBuilder.DropTable(
                name: "salary");

            migrationBuilder.DropTable(
                name: "work_place_has_department");

            migrationBuilder.DropTable(
                name: "employment");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "work_place");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "qualification_level");

            migrationBuilder.DropTable(
                name: "profile");
        }
    }
}
