using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RankApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "KerivSudNaukGurtok",
                table: "NaukRobs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "KerivSudNaukGurtokBool",
                table: "NaukRobs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "MaterialMijnNeScopus",
                table: "NaukRobs",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaterialScopus",
                table: "NaukRobs",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaterialUkrNeScopus",
                table: "NaukRobs",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TezMijn",
                table: "NaukRobs",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TezUkr",
                table: "NaukRobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KerivSudNaukGurtok",
                table: "NaukRobs");

            migrationBuilder.DropColumn(
                name: "KerivSudNaukGurtokBool",
                table: "NaukRobs");

            migrationBuilder.DropColumn(
                name: "MaterialMijnNeScopus",
                table: "NaukRobs");

            migrationBuilder.DropColumn(
                name: "MaterialScopus",
                table: "NaukRobs");

            migrationBuilder.DropColumn(
                name: "MaterialUkrNeScopus",
                table: "NaukRobs");

            migrationBuilder.DropColumn(
                name: "TezMijn",
                table: "NaukRobs");

            migrationBuilder.DropColumn(
                name: "TezUkr",
                table: "NaukRobs");
        }
    }
}
