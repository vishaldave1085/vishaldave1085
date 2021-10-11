using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Investeer.DataAccess.Migrations
{
    public partial class AddPropertyDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(nullable: true),
                    AddedBy = table.Column<string>(nullable: true),
                    AddedDt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDt = table.Column<DateTime>(nullable: true),
                    A = table.Column<string>(nullable: true),
                    B = table.Column<string>(nullable: true),
                    D = table.Column<string>(nullable: true),
                    E = table.Column<string>(nullable: true),
                    F = table.Column<string>(nullable: true),
                    G = table.Column<string>(nullable: true),
                    H = table.Column<string>(nullable: true),
                    I = table.Column<string>(nullable: true),
                    J = table.Column<string>(nullable: true),
                    K = table.Column<string>(nullable: true),
                    M = table.Column<string>(nullable: true),
                    N = table.Column<string>(nullable: true),
                    O = table.Column<string>(nullable: true),
                    P = table.Column<string>(nullable: true),
                    Q = table.Column<string>(nullable: true),
                    R = table.Column<string>(nullable: true),
                    S = table.Column<string>(nullable: true),
                    T = table.Column<string>(nullable: true),
                    U = table.Column<string>(nullable: true),
                    V = table.Column<string>(nullable: true),
                    W = table.Column<string>(nullable: true),
                    X = table.Column<string>(nullable: true),
                    Y = table.Column<string>(nullable: true),
                    Z = table.Column<string>(nullable: true),
                    AA = table.Column<string>(nullable: true),
                    AB = table.Column<string>(nullable: true),
                    AC = table.Column<string>(nullable: true),
                    AD = table.Column<string>(nullable: true),
                    AE = table.Column<string>(nullable: true),
                    AF = table.Column<string>(nullable: true),
                    AG = table.Column<string>(nullable: true),
                    AH = table.Column<string>(nullable: true),
                    AI = table.Column<string>(nullable: true),
                    AJ = table.Column<string>(nullable: true),
                    AK = table.Column<string>(nullable: true),
                    AL = table.Column<string>(nullable: true),
                    AM = table.Column<string>(nullable: true),
                    AN = table.Column<string>(nullable: true),
                    AO = table.Column<string>(nullable: true),
                    AP = table.Column<string>(nullable: true),
                    SheetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertyDetail_AspNetUsers_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyDetail_AspNetUsers_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyDetail_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetail_AddedBy",
                table: "PropertyDetail",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetail_ModifiedBy",
                table: "PropertyDetail",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetail_StatusId",
                table: "PropertyDetail",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyDetail");
        }
    }
}
