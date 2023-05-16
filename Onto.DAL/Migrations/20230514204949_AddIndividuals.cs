using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onto.DAL.Migrations
{
    public partial class AddIndividuals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OntologyConceptProperties_OntologyConcepts_ConceptDomainUri",
                table: "OntologyConceptProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_OntologyPropertyRange_OntologyConcepts_ConceptRangeUri",
                table: "OntologyPropertyRange");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "OntologyProperties");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "OntologyProperties");

            migrationBuilder.AddColumn<string>(
                name: "Annotation",
                table: "OntologyProperties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Annotation",
                table: "OntologyConcepts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OntologyIndividual",
                columns: table => new
                {
                    Uri = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Annotation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OntologyConceptUri = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OntologyIndividual", x => x.Uri);
                    table.ForeignKey(
                        name: "FK_OntologyIndividual_OntologyConcepts_OntologyConceptUri",
                        column: x => x.OntologyConceptUri,
                        principalTable: "OntologyConcepts",
                        principalColumn: "Uri");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OntologyIndividual_OntologyConceptUri",
                table: "OntologyIndividual",
                column: "OntologyConceptUri");

            migrationBuilder.AddForeignKey(
                name: "FK_OntologyConceptProperties_OntologyIndividual_ConceptDomainUri",
                table: "OntologyConceptProperties",
                column: "ConceptDomainUri",
                principalTable: "OntologyIndividual",
                principalColumn: "Uri",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OntologyPropertyRange_OntologyIndividual_ConceptRangeUri",
                table: "OntologyPropertyRange",
                column: "ConceptRangeUri",
                principalTable: "OntologyIndividual",
                principalColumn: "Uri",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OntologyConceptProperties_OntologyIndividual_ConceptDomainUri",
                table: "OntologyConceptProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_OntologyPropertyRange_OntologyIndividual_ConceptRangeUri",
                table: "OntologyPropertyRange");

            migrationBuilder.DropTable(
                name: "OntologyIndividual");

            migrationBuilder.DropColumn(
                name: "Annotation",
                table: "OntologyProperties");

            migrationBuilder.DropColumn(
                name: "Annotation",
                table: "OntologyConcepts");

            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "OntologyProperties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "OntologyProperties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OntologyConceptProperties_OntologyConcepts_ConceptDomainUri",
                table: "OntologyConceptProperties",
                column: "ConceptDomainUri",
                principalTable: "OntologyConcepts",
                principalColumn: "Uri",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OntologyPropertyRange_OntologyConcepts_ConceptRangeUri",
                table: "OntologyPropertyRange",
                column: "ConceptRangeUri",
                principalTable: "OntologyConcepts",
                principalColumn: "Uri",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
