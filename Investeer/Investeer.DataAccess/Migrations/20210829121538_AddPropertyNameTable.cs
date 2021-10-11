using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Investeer.DataAccess.Migrations
{
    public partial class AddPropertyNameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyName",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(nullable: true),
                    AddedBy = table.Column<string>(nullable: true),
                    AddedDt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDt = table.Column<DateTime>(nullable: true),
                    Column = table.Column<string>(maxLength: 10, nullable: true),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyName_AspNetUsers_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyName_AspNetUsers_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyName_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyName_AddedBy",
                table: "PropertyName",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyName_ModifiedBy",
                table: "PropertyName",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyName_StatusId",
                table: "PropertyName",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyName");
        }
    }
}
