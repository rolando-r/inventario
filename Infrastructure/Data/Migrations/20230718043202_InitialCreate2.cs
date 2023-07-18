using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Paises_PaisCodPais",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Regiones_Estados_EstadocodEstado",
                table: "Regiones");

            migrationBuilder.DropIndex(
                name: "IX_Regiones_EstadocodEstado",
                table: "Regiones");

            migrationBuilder.DropIndex(
                name: "IX_Estados_PaisCodPais",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "EstadocodEstado",
                table: "Regiones");

            migrationBuilder.DropColumn(
                name: "PaisCodPais",
                table: "Estados");

            migrationBuilder.UpdateData(
                table: "Regiones",
                keyColumn: "nombreRegion",
                keyValue: null,
                column: "nombreRegion",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "nombreRegion",
                table: "Regiones",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "NombrePais",
                keyValue: null,
                column: "NombrePais",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "NombrePais",
                table: "Paises",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "nombreEstado",
                keyValue: null,
                column: "nombreEstado",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "nombreEstado",
                table: "Estados",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CodPais",
                table: "Estados",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreProducto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<double>(type: "double", nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: false),
                    StockMaximo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposPersonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPersonas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    IdPersona = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombrePersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApellidosPersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailPersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoPersona = table.Column<int>(type: "int", nullable: false),
                    IdRegion = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdPersona);
                    table.ForeignKey(
                        name: "FK_Personas_Regiones_IdRegion",
                        column: x => x.IdRegion,
                        principalTable: "Regiones",
                        principalColumn: "codRegion");
                    table.ForeignKey(
                        name: "FK_Personas_TiposPersonas_IdTipoPersona",
                        column: x => x.IdTipoPersona,
                        principalTable: "TiposPersonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonaProductos",
                columns: table => new
                {
                    IdPersona = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdProducto = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonaIdPersona = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductoIdProducto = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaProductos", x => new { x.IdPersona, x.IdProducto });
                    table.ForeignKey(
                        name: "FK_PersonaProductos_Personas_PersonaIdPersona",
                        column: x => x.PersonaIdPersona,
                        principalTable: "Personas",
                        principalColumn: "IdPersona");
                    table.ForeignKey(
                        name: "FK_PersonaProductos_Productos_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_CodPais",
                table: "Estados",
                column: "CodPais");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaProductos_PersonaIdPersona",
                table: "PersonaProductos",
                column: "PersonaIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaProductos_ProductoIdProducto",
                table: "PersonaProductos",
                column: "ProductoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EmailPersona",
                table: "Personas",
                column: "EmailPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdRegion",
                table: "Personas",
                column: "IdRegion");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdTipoPersona",
                table: "Personas",
                column: "IdTipoPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Paises_CodPais",
                table: "Estados",
                column: "CodPais",
                principalTable: "Paises",
                principalColumn: "CodPais");

            migrationBuilder.AddForeignKey(
                name: "FK_Regiones_Estados_codRegion",
                table: "Regiones",
                column: "codRegion",
                principalTable: "Estados",
                principalColumn: "codEstado",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Paises_CodPais",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Regiones_Estados_codRegion",
                table: "Regiones");

            migrationBuilder.DropTable(
                name: "PersonaProductos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "TiposPersonas");

            migrationBuilder.DropIndex(
                name: "IX_Estados_CodPais",
                table: "Estados");

            migrationBuilder.AlterColumn<string>(
                name: "nombreRegion",
                table: "Regiones",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EstadocodEstado",
                table: "Regiones",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "NombrePais",
                table: "Paises",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "nombreEstado",
                table: "Estados",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CodPais",
                table: "Estados",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PaisCodPais",
                table: "Estados",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Regiones_EstadocodEstado",
                table: "Regiones",
                column: "EstadocodEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_PaisCodPais",
                table: "Estados",
                column: "PaisCodPais");

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Paises_PaisCodPais",
                table: "Estados",
                column: "PaisCodPais",
                principalTable: "Paises",
                principalColumn: "CodPais");

            migrationBuilder.AddForeignKey(
                name: "FK_Regiones_Estados_EstadocodEstado",
                table: "Regiones",
                column: "EstadocodEstado",
                principalTable: "Estados",
                principalColumn: "codEstado");
        }
    }
}
