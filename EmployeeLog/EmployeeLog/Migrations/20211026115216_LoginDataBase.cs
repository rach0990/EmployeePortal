using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeLog.Migrations
{
    public partial class LoginDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Surname = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IsEmployer = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
