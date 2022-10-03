using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaGranTitan.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Number",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdColor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Number", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roulette",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roulette", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roulette_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouletteId = table.Column<int>(type: "int", nullable: false),
                    NumberId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ValueBet = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bet_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bet_Number_NumberId",
                        column: x => x.NumberId,
                        principalTable: "Number",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bet_Roulette_RouletteId",
                        column: x => x.RouletteId,
                        principalTable: "Roulette",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultBet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentValue = table.Column<double>(type: "float", nullable: false),
                    BetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultBet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultBet_Bet_BetId",
                        column: x => x.BetId,
                        principalTable: "Bet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bet_ColorId",
                table: "Bet",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_NumberId",
                table: "Bet",
                column: "NumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_RouletteId",
                table: "Bet",
                column: "RouletteId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultBet_BetId",
                table: "ResultBet",
                column: "BetId");

            migrationBuilder.CreateIndex(
                name: "IX_Roulette_StateId",
                table: "Roulette",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultBet");

            migrationBuilder.DropTable(
                name: "Bet");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Number");

            migrationBuilder.DropTable(
                name: "Roulette");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
