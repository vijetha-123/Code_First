using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codefirst.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    cust_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cust_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cust_age = table.Column<int>(type: "int", nullable: false),
                    d_order = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cust_dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cust_mob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cust_mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cust_pswd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cust_confirmpswd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.cust_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
