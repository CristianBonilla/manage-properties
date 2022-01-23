using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Properties.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Owner",
                schema: "dbo",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                schema: "dbo",
                columns: table => new
                {
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    CodeInternal = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Property_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dbo",
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImage",
                schema: "dbo",
                columns: table => new
                {
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImage", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_PropertyImage_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalSchema: "dbo",
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTrace",
                schema: "dbo",
                columns: table => new
                {
                    PropertyTraceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTrace", x => x.PropertyTraceId);
                    table.ForeignKey(
                        name: "FK_PropertyTrace_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalSchema: "dbo",
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Owner",
                columns: new[] { "OwnerId", "Address", "Birthday", "Name", "Photo" },
                values: new object[] { new Guid("5691eab3-50ce-4280-8659-ce208326fd97"), "Cl. 20A Sur # 10-31", new DateTime(1995, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Bonilla", null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Owner",
                columns: new[] { "OwnerId", "Address", "Birthday", "Name", "Photo" },
                values: new object[] { new Guid("dcbe29f5-aa35-40c3-adc8-5e3b718a6000"), "Cl. 138 # 20-57", new DateTime(1987, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natalia Guzman", null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Property",
                columns: new[] { "PropertyId", "Address", "CodeInternal", "Name", "OwnerId", "Price", "Year" },
                values: new object[,]
                {
                    { new Guid("488148ae-7bbc-4186-8e36-c3bd1c0bfe34"), "6677 Schroeder Avenue", 34432111, "Headland Waters Mount Martha", new Guid("5691eab3-50ce-4280-8659-ce208326fd97"), 1358000000m, 2018 },
                    { new Guid("12ba0df8-cf55-4ccb-a109-c582906e6b12"), "Moussaouidreef 8", 98801123, "Luyary Jeddo", new Guid("5691eab3-50ce-4280-8659-ce208326fd97"), 1297566000m, 2021 },
                    { new Guid("39cd6b37-9f59-4e34-bbff-34d3963ba558"), "8098 Yundt Mission", 11983367, "Runneymede", new Guid("5691eab3-50ce-4280-8659-ce208326fd97"), 1188954000m, 2020 },
                    { new Guid("0ca10f96-364a-4d8e-b870-baddb7a9acbf"), "701, avenue de Guilbert", 87711809, "Zuburnano Up", new Guid("dcbe29f5-aa35-40c3-adc8-5e3b718a6000"), 1877544000m, 2021 },
                    { new Guid("cb9ec42f-3c07-4ca1-8ba8-59e09c504860"), "193 Kshlerin Spring", 43309922, "The Kingfisher", new Guid("dcbe29f5-aa35-40c3-adc8-5e3b718a6000"), 1988411000m, 2020 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PropertyTrace",
                columns: new[] { "PropertyTraceId", "DateSale", "Name", "PropertyId", "Tax", "Value" },
                values: new object[,]
                {
                    { new Guid("c4c42999-a4fc-40fb-b10b-6a14fc588fab"), new DateTime(2018, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Headland Waters Mount Martha Trace", new Guid("488148ae-7bbc-4186-8e36-c3bd1c0bfe34"), 5430000m, 1058000000m },
                    { new Guid("529bbf7d-880a-4bb8-80fc-f605b3df0344"), new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luyary Jeddo Trace", new Guid("12ba0df8-cf55-4ccb-a109-c582906e6b12"), 6132000m, 1117566000m },
                    { new Guid("ae699884-d68a-486d-877d-55bd62046d66"), new DateTime(2020, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Runneymede Trace", new Guid("39cd6b37-9f59-4e34-bbff-34d3963ba558"), 5011000m, 1008954000m },
                    { new Guid("774c3477-c8d5-49c5-9281-addb60d175b0"), new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zuburnano Up Trace", new Guid("0ca10f96-364a-4d8e-b870-baddb7a9acbf"), 6234000m, 1417844000m },
                    { new Guid("c82d1ac6-215f-4c21-aa2f-2140fe532a6b"), new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Kingfisher Trace", new Guid("cb9ec42f-3c07-4ca1-8ba8-59e09c504860"), 8950000m, 1122910000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Property_OwnerId",
                schema: "dbo",
                table: "Property",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTrace_PropertyId",
                schema: "dbo",
                table: "PropertyTrace",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyImage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PropertyTrace",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Property",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Owner",
                schema: "dbo");
        }
    }
}
