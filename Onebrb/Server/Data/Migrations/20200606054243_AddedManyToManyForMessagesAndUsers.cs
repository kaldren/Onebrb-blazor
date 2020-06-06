using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onebrb.Server.Data.Migrations
{
    public partial class AddedManyToManyForMessagesAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserMessage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<Guid>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUserMessage_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserMessage_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserMessage_ApplicationUserId",
                table: "ApplicationUserMessage",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserMessage_MessageId",
                table: "ApplicationUserMessage",
                column: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserMessage");
        }
    }
}
