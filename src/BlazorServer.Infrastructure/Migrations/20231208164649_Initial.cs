using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cookies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cookies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Id", "Message" },
                values: new object[,]
                {
                    { 1, "fortune: No such file or directory" },
                    { 2, "A computer scientist is someone who fixes things that aren't broken." },
                    { 3, "After enough decimal places, nobody gives a damn." },
                    { 4, "A bad random number generator: 1, 1, 1, 1, 1, 4.33e+67, 1, 1, 1" },
                    { 5, "A computer program does what you tell it to do, not what you want it to do." },
                    { 6, "Emacs is a nice operating system, but I prefer UNIX. — Tom Christaensen" },
                    { 7, "Any program that runs right is obsolete." },
                    { 8, "A list is only as strong as its weakest link. — Donald Knuth" },
                    { 9, "Feature: A bug with seniority." },
                    { 10, "Computers make very fast, very accurate mistakes." },
                    { 11, "<script>alert('This should not be displayed in a browser alert box.');</script>" },
                    { 12, "フレームワークのベンチマーク" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cookies");
        }
    }
}
