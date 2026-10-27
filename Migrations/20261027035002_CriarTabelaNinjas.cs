using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiNaruto.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaNinjas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ninjas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cla = table.Column<string>(type: "TEXT", nullable: false),
                    Aldeia = table.Column<string>(type: "TEXT", nullable: false),
                    Idade = table.Column<int>(type: "INTEGER", nullable: false),
                    NivelDePoder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninjas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ninjas",
                columns: new[] { "Id", "Aldeia", "Cla", "Idade", "NivelDePoder", "Nome" },
                values: new object[,]
                {
                    { 1, "Konohagakure", "Uzumaki", 17, 9500, "Naruto Uzumaki" },
                    { 2, "Konohagakure", "Uchiha", 17, 9400, "Sasuke Uchiha" },
                    { 3, "Konohagakure", "Haruno", 17, 7800, "Sakura Haruno" },
                    { 4, "Konohagakure", "Hatake", 31, 8900, "Kakashi Hatake" },
                    { 5, "Sunagakure", "Sabaku", 17, 8700, "Gaara" },
                    { 6, "Konohagakure", "Hyuuga", 17, 7200, "Hinata Hyuuga" },
                    { 7, "Konohagakure", "Nara", 17, 7400, "Shikamaru Nara" },
                    { 8, "Konohagakure", "Hyuuga", 18, 8100, "Neji Hyuuga" },
                    { 9, "Konohagakure", "Uchiha", 21, 9600, "Itachi Uchiha" },
                    { 10, "Kumogakure", "Kumo", 40, 9200, "Killer Bee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ninjas");
        }
    }
}
