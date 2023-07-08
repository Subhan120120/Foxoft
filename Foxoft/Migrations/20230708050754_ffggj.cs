﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class ffggj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures",
                columns: new[] { "ProductCode", "FeatureTypeId", "FeatureCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures",
                columns: new[] { "ProductCode", "FeatureTypeId" });
        }
    }
}
