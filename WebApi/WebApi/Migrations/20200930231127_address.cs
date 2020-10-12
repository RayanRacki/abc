using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "addressModelId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cep = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    street = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    neighborhood = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_addressModelId",
                table: "User",
                column: "addressModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address_addressModelId",
                table: "User",
                column: "addressModelId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_addressModelId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_User_addressModelId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "addressModelId",
                table: "User");
        }
    }
}
