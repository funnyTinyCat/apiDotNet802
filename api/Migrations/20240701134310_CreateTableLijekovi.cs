using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableLijekovi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lijekovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImeLijeka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpisLijeka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Doziranje = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lijekovi", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lijekovi");
        }
    }
}
