using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eHealthcare.Data.Migrations
{
    public partial class AddDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    address2 = table.Column<string>(nullable: true),
                    postcode = table.Column<int>(nullable: false),
                    state = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    doctorIDNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}
