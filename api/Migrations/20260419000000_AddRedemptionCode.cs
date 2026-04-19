using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class AddRedemptionCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Redemptions",
                type: "character varying(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "0000000");

            migrationBuilder.Sql("UPDATE \"Redemptions\" SET \"Code\" = LPAD((\"Id\" % 10000000)::text, 7, '0') WHERE \"Code\" = '0000000';");

            migrationBuilder.CreateIndex(
                name: "IX_Redemptions_Code",
                table: "Redemptions",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Redemptions_Code",
                table: "Redemptions");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Redemptions");
        }
    }
}
