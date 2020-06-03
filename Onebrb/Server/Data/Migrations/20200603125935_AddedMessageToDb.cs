using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onebrb.Server.Data.Migrations
{
    public partial class AddedMessageToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    DateSent = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    RecipientId = table.Column<string>(nullable: true),
                    IsDeletedForAuthor = table.Column<bool>(nullable: false),
                    IsArchivedForAuthor = table.Column<bool>(nullable: false),
                    IsDeletedForRecipient = table.Column<bool>(nullable: false),
                    IsArchivedForRecipient = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
