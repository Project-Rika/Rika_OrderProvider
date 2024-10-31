﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rika_OrderProvider.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class spelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentMehod",
                table: "Orders",
                newName: "PaymentMethod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "Orders",
                newName: "PaymentMehod");
        }
    }
}
