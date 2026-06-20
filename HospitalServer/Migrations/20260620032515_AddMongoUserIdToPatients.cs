using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalServer.Migrations
{
    /// <inheritdoc />
    public partial class AddMongoUserIdToPatients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MongoUserId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MongoUserId",
                table: "Patients",
                column: "MongoUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_MongoUserId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MongoUserId",
                table: "Patients");
        }
    }
}
