using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallangeMottu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_Usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_USUARIOS-MOTTU",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false, defaultValueSql: "SYS_GUID()"),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    MotoId = table.Column<Guid>(type: "RAW(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USUARIOS-MOTTU", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_USUARIOS-MOTTU_T_MOTOS-MOTTU_MotoId",
                        column: x => x.MotoId,
                        principalTable: "T_MOTOS-MOTTU",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_USUARIOS-MOTTU_MotoId",
                table: "T_USUARIOS-MOTTU",
                column: "MotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_USUARIOS-MOTTU");
        }
    }
}
