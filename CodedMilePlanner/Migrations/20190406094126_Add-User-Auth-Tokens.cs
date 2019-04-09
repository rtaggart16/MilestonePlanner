using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CodedMilePlanner.Migrations
{
    public partial class AddUserAuthTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Auth_Tokens",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    User_ID = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Auth_Tokens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Auth_Tokens_AspNetUsers_User_ID",
                        column: x => x.User_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Auth_Tokens_User_ID",
                table: "User_Auth_Tokens",
                column: "User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Auth_Tokens");
        }
    }
}
