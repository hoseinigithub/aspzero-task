using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    /// <inheritdoc />
    public partial class AddLoanContractsAndPersons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "LoanContracts");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "LoanContracts");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "LoanContracts");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "LoanContracts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LoanContracts");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "LoanContracts");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "LoanContracts");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "LoanContractPersons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Persons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Persons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Persons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "LoanContracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "LoanContracts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "LoanContracts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "LoanContracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LoanContracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "LoanContracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "LoanContracts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "LoanContractPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
