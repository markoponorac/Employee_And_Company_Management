using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_And_Company_Management.Migrations
{
    /// <inheritdoc />
    public partial class AddressUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "company",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "company");

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
        }
    }
}
