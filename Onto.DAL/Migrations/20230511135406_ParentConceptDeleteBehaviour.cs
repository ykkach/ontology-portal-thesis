using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onto.DAL.Migrations
{
    public partial class ParentConceptDeleteBehaviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OntologyConcepts",
                columns: table => new
                {
                    Uri = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OntologyConcepts", x => x.Uri);
                    table.ForeignKey(
                        name: "FK_OntologyConcepts_OntologyConcepts_ParentId",
                        column: x => x.ParentId,
                        principalTable: "OntologyConcepts",
                        principalColumn: "Uri",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OntologyProperties",
                columns: table => new
                {
                    Uri = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OntologyProperties", x => x.Uri);
                });

            migrationBuilder.CreateTable(
                name: "OntologyConceptProperties",
                columns: table => new
                {
                    ConceptDomainUri = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyUri = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OntologyConceptProperties", x => new { x.ConceptDomainUri, x.PropertyUri });
                    table.ForeignKey(
                        name: "FK_OntologyConceptProperties_OntologyConcepts_ConceptDomainUri",
                        column: x => x.ConceptDomainUri,
                        principalTable: "OntologyConcepts",
                        principalColumn: "Uri",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OntologyConceptProperties_OntologyProperties_PropertyUri",
                        column: x => x.PropertyUri,
                        principalTable: "OntologyProperties",
                        principalColumn: "Uri",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OntologyPropertyRange",
                columns: table => new
                {
                    ConceptRangeUri = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyUri = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OntologyPropertyRange", x => new { x.ConceptRangeUri, x.PropertyUri });
                    table.ForeignKey(
                        name: "FK_OntologyPropertyRange_OntologyConcepts_ConceptRangeUri",
                        column: x => x.ConceptRangeUri,
                        principalTable: "OntologyConcepts",
                        principalColumn: "Uri",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OntologyPropertyRange_OntologyProperties_PropertyUri",
                        column: x => x.PropertyUri,
                        principalTable: "OntologyProperties",
                        principalColumn: "Uri",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OntologyConceptProperties_PropertyUri",
                table: "OntologyConceptProperties",
                column: "PropertyUri");

            migrationBuilder.CreateIndex(
                name: "IX_OntologyConcepts_ParentId",
                table: "OntologyConcepts",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OntologyPropertyRange_PropertyUri",
                table: "OntologyPropertyRange",
                column: "PropertyUri");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OntologyConceptProperties");

            migrationBuilder.DropTable(
                name: "OntologyPropertyRange");

            migrationBuilder.DropTable(
                name: "OntologyConcepts");

            migrationBuilder.DropTable(
                name: "OntologyProperties");
        }
    }
}
