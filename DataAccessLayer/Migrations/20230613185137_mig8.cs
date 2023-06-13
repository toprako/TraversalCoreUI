using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.CreateTable(
          name: "Comments",
          columns: table => new
          {
              CommentId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
              NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
              Date = table.Column<DateTime>(type: "datetime2", nullable: false),
              Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
              State = table.Column<bool>(type: "bit", nullable: false),
              DestinationID = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
              table.PrimaryKey("PK_Comments", x => x.CommentId);
              table.ForeignKey(
                  name: "FK_Comments_Destinations_DestinationID",
                  column: x => x.DestinationID,
                  principalTable: "Destinations",
                  principalColumn: "DestinationID",
                  onDelete: ReferentialAction.Cascade);
          });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Comments");
        }
    }
}
