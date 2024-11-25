using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sirotti.Domus.Archimagirus.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "recipes");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                schema: "recipes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                schema: "recipes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "recipes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                schema: "recipes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTags",
                schema: "recipes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTags", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecipeTags_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalSchema: "recipes",
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeTags_Tags_TagID",
                        column: x => x.TagID,
                        principalSchema: "recipes",
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                schema: "recipes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeID = table.Column<int>(type: "int", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: false),
                    UnitID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalSchema: "recipes",
                        principalTable: "Ingredients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalSchema: "recipes",
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Units_UnitID",
                        column: x => x.UnitID,
                        principalSchema: "recipes",
                        principalTable: "Units",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Name",
                schema: "recipes",
                table: "Ingredients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientID",
                schema: "recipes",
                table: "RecipeIngredients",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeID_IngredientID",
                schema: "recipes",
                table: "RecipeIngredients",
                columns: new[] { "RecipeID", "IngredientID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_UnitID",
                schema: "recipes",
                table: "RecipeIngredients",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTags_RecipeID_TagID",
                schema: "recipes",
                table: "RecipeTags",
                columns: new[] { "RecipeID", "TagID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTags_TagID",
                schema: "recipes",
                table: "RecipeTags",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                schema: "recipes",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_Label",
                schema: "recipes",
                table: "Units",
                column: "Label",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_Name",
                schema: "recipes",
                table: "Units",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients",
                schema: "recipes");

            migrationBuilder.DropTable(
                name: "RecipeTags",
                schema: "recipes");

            migrationBuilder.DropTable(
                name: "Ingredients",
                schema: "recipes");

            migrationBuilder.DropTable(
                name: "Units",
                schema: "recipes");

            migrationBuilder.DropTable(
                name: "Recipes",
                schema: "recipes");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "recipes");
        }
    }
}
