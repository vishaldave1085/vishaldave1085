using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Investeer.DataAccess.Migrations
{
    public partial class RemoveCommanPropertyFromPropertyDetailAndPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetail_AspNetUsers_AddedBy",
                table: "PropertyDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetail_AspNetUsers_ModifiedBy",
                table: "PropertyDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetail_Status_StatusId",
                table: "PropertyDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyName_AspNetUsers_AddedBy",
                table: "PropertyName");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyName_AspNetUsers_ModifiedBy",
                table: "PropertyName");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyName_Status_StatusId",
                table: "PropertyName");

            migrationBuilder.DropIndex(
                name: "IX_PropertyName_AddedBy",
                table: "PropertyName");

            migrationBuilder.DropIndex(
                name: "IX_PropertyName_ModifiedBy",
                table: "PropertyName");

            migrationBuilder.DropIndex(
                name: "IX_PropertyName_StatusId",
                table: "PropertyName");

            migrationBuilder.DropIndex(
                name: "IX_PropertyDetail_AddedBy",
                table: "PropertyDetail");

            migrationBuilder.DropIndex(
                name: "IX_PropertyDetail_ModifiedBy",
                table: "PropertyDetail");

            migrationBuilder.DropIndex(
                name: "IX_PropertyDetail_StatusId",
                table: "PropertyDetail");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "PropertyName");

            migrationBuilder.DropColumn(
                name: "AddedDt",
                table: "PropertyName");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PropertyName");

            migrationBuilder.DropColumn(
                name: "ModifiedDt",
                table: "PropertyName");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "PropertyName");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "PropertyDetail");

            migrationBuilder.DropColumn(
                name: "AddedDt",
                table: "PropertyDetail");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PropertyDetail");

            migrationBuilder.DropColumn(
                name: "ModifiedDt",
                table: "PropertyDetail");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "PropertyDetail");

            migrationBuilder.AddColumn<string>(
                name: "C",
                table: "PropertyDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "L",
                table: "PropertyDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "C",
                table: "PropertyDetail");

            migrationBuilder.DropColumn(
                name: "L",
                table: "PropertyDetail");

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "PropertyName",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDt",
                table: "PropertyName",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "PropertyName",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDt",
                table: "PropertyName",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "PropertyName",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "PropertyDetail",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDt",
                table: "PropertyDetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "PropertyDetail",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDt",
                table: "PropertyDetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "PropertyDetail",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetail_AspNetUsers_AddedBy",
                table: "PropertyDetail",
                column: "AddedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetail_AspNetUsers_ModifiedBy",
                table: "PropertyDetail",
                column: "ModifiedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetail_Status_StatusId",
                table: "PropertyDetail",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyName_AspNetUsers_AddedBy",
                table: "PropertyName",
                column: "AddedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyName_AspNetUsers_ModifiedBy",
                table: "PropertyName",
                column: "ModifiedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyName_Status_StatusId",
                table: "PropertyName",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
