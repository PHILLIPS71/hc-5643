using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HC_5643.Migrations
{
    /// <inheritdoc />
    public partial class v001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "FileSystemEntrySequence");

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    PathInfo_Name = table.Column<string>(type: "text", nullable: false),
                    PathInfo_FullName = table.Column<string>(type: "text", nullable: false),
                    PathInfo_Extension = table.Column<string>(type: "text", nullable: true),
                    PathInfo_DirectoryPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"FileSystemEntrySequence\"')"),
                    ParentDirectoryId = table.Column<int>(type: "integer", nullable: true),
                    LibraryId = table.Column<int>(type: "integer", nullable: false),
                    PathInfo_Name = table.Column<string>(type: "text", nullable: false),
                    PathInfo_FullName = table.Column<string>(type: "text", nullable: false),
                    PathInfo_Extension = table.Column<string>(type: "text", nullable: true),
                    PathInfo_DirectoryPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directories_Directories_ParentDirectoryId",
                        column: x => x.ParentDirectoryId,
                        principalTable: "Directories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Directories_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"FileSystemEntrySequence\"')"),
                    ParentDirectoryId = table.Column<int>(type: "integer", nullable: true),
                    LibraryId = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    PathInfo_Name = table.Column<string>(type: "text", nullable: false),
                    PathInfo_FullName = table.Column<string>(type: "text", nullable: false),
                    PathInfo_Extension = table.Column<string>(type: "text", nullable: true),
                    PathInfo_DirectoryPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Directories_ParentDirectoryId",
                        column: x => x.ParentDirectoryId,
                        principalTable: "Directories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Files_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directories_LibraryId",
                table: "Directories",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Directories_ParentDirectoryId",
                table: "Directories",
                column: "ParentDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_LibraryId",
                table: "Files",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ParentDirectoryId",
                table: "Files",
                column: "ParentDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_Slug",
                table: "Libraries",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Directories");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropSequence(
                name: "FileSystemEntrySequence");
        }
    }
}
