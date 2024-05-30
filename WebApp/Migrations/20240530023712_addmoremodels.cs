using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class addmoremodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Subject_SubjectID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Profile_ProfileID",
                table: "Staff");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Staff_ProfileID",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Department_SubjectID",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Department");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectName",
                table: "Subject",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Student",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Student",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MidName",
                table: "Student",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Staff",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Staff",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Staff",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MidName",
                table: "Staff",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Department",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_DepartmentID",
                table: "Subject",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Department_DepartmentID",
                table: "Subject",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Department_DepartmentID",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_DepartmentID",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "MidName",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "MidName",
                table: "Staff");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectName",
                table: "Subject",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "ProfileID",
                table: "Staff",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Department",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_ProfileID",
                table: "Staff",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_SubjectID",
                table: "Department",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Subject_SubjectID",
                table: "Department",
                column: "SubjectID",
                principalTable: "Subject",
                principalColumn: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Profile_ProfileID",
                table: "Staff",
                column: "ProfileID",
                principalTable: "Profile",
                principalColumn: "ProfileID");
        }
    }
}
