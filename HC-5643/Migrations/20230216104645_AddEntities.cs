using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HC_5643.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileSystemDirectories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileSystemDirectories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileSystemDirectories_FileSystemDirectories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FileSystemDirectories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileSystemFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    ProbedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileSystemFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileSystemFiles_FileSystemDirectories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FileSystemDirectories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileSystemDirectories_ParentId",
                table: "FileSystemDirectories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FileSystemDirectories_Path",
                table: "FileSystemDirectories",
                column: "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileSystemFiles_ParentId",
                table: "FileSystemFiles",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FileSystemFiles_Path",
                table: "FileSystemFiles",
                column: "Path",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileSystemFiles");

            migrationBuilder.DropTable(
                name: "FileSystemDirectories");
        }
    }
}
