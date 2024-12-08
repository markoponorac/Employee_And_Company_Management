using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_And_Company_Management.Migrations
{
    /// <inheritdoc />
    public partial class AddressUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_KOMPANIJA_ADDRESS1",
                table: "company");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropIndex(
                name: "fk_KOMPANIJA_ADDRESS1_idx",
                table: "company");

            migrationBuilder.DropColumn(
                name: "ADDRESS_ID",
                table: "company");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "salary",
                type: "decimal(4)",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,30)",
                oldPrecision: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_of_work",
                table: "employment",
                type: "decimal(4)",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,30)",
                oldPrecision: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "salary",
                type: "decimal(4,30)",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4)",
                oldPrecision: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_of_work",
                table: "employment",
                type: "decimal(4,30)",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4)",
                oldPrecision: 4);

            migrationBuilder.AddColumn<int>(
                name: "ADDRESS_ID",
                table: "company",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Country = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Number = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Street = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "fk_KOMPANIJA_ADDRESS1_idx",
                table: "company",
                column: "ADDRESS_ID");

            migrationBuilder.AddForeignKey(
                name: "fk_KOMPANIJA_ADDRESS1",
                table: "company",
                column: "ADDRESS_ID",
                principalTable: "address",
                principalColumn: "ID");
        }
    }
}
