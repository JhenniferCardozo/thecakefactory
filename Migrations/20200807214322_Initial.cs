using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCakeFactory.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CookingSteps",
                columns: table => new
                {
                    CookingStepId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CookingStepNumber = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RecipeId = table.Column<int>(nullable: false),
                    RecipeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingSteps", x => x.CookingStepId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Preparation = table.Column<int>(nullable: false),
                    Cook = table.Column<int>(nullable: false),
                    Dificulty = table.Column<string>(nullable: true),
                    Ingredients = table.Column<string>(nullable: true),
                    Chef = table.Column<string>(nullable: true),
                    Stars = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    RecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CookingSteps");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
