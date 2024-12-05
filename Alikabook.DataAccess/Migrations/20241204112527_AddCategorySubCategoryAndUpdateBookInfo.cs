using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alikabook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorySubCategoryAndUpdateBookInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 178);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "BookInfos");

            migrationBuilder.DropColumn(
                name: "Subcategory",
                table: "BookInfos");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "BookInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubcategoryId",
                table: "BookInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 1,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 19.7m, "9781444727364", 12.9m, 102, "Hodder & Stoughton", 20, 0.7m, 1981 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 2,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.4m, "9780596517748", 17.8m, 172, "Yahoo Press", 20, 1m, 2008 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 3,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.5m, "9780596009205", 20.3m, 688, "O'Reilly Media", 20, 3.76m, 2005 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 4,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.2m, "9780138049843", 18m, 896, "Addison-Wesley Professional", 22, 4.5m, 2023 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 5,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.5m, "9780321884916", 18.4m, 320, "Addison-Wesley Professional", 20, 1.9m, 2013 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 6,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.5m, "9781593279509", 17.8m, 472, "No Starch Press", 20, 2.7m, 2018 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 7,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.4m, "9781118008188", 18.5m, 490, "John Wiley & Sons", 22, 2.8m, 2011 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 8,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 22.9m, "9780132350884", 17.3m, 464, "Pearson", 24, 2.3m, 2008 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 9,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.7m, "9780201633610", 19.4m, 416, "Addison-Wesley Professional", 24, 2.7m, 1994 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 10,
                columns: new[] { "CategoryId", "ISBN", "Publisher", "SubcategoryId", "Year" },
                values: new object[] { 4, "9780135957059", "Addison-Wesley Professional", 24, 2019 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 11,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.1m, "9780262033848", 20.8m, 1292, "MIT Press", 21, 5.2m, 2009 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 12,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 22.9m, "978013468599", 18.8m, 416, "Addison-Wesley Professional", 24, 2.3m, 2017 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 13,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.5m, "9780201485677", 19.1m, 431, "Addison-Wesley Professional", 24, 2.5m, 1999 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 14,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 4, 23.4m, "9780321349606", 17.8m, 432, "Addison-Wesley Professional", 21, "Java Concurrency in Practice", 3.1m, 2006 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 15,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.2m, "9780735619678", 19.1m, 960, "Microsoft Press", 24, 4.1m, 2004 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 16,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23m, "9780201835953", 15.5m, 336, "Addison-Wesley Professional", 24, 1.9m, 1995 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 17,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 24.3m, "9780321125217", 18.5m, 560, "Addison-Wesley Professional", 24, 3.6m, 2003 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 18,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 21.6m, "9780804139298", 14.3m, 224, "Crown Currency", 14, 2.3m, 2014 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 19,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 23.6m, "9780374275631", 16.4m, 512, "Farrar, Straus and Giroux", 16, 3.8m, 2011 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 20,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 23.1m, "9780470920107", 15.7m, 272, "Wiley", 17, 3m, 2011 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 21,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 3, 23.5m, "9781625274496", 15.6m, 320, "Harvard Business Review Press", 14, "Blue Ocean Strategy: How to Create Uncontested Market Space and Make the Competition Irrelevant", 2.1m, 2015 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 22,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 21.3m, "9781501121746", 14.0m, 288, "Simon & Schuster", 14, 2.5m, 2016 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 23,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 22.9m, "9780062273208", 15.2m, 304, "Harper Business", 14, 2.6m, 2014 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 24,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 23.5m, "9780063046061", 15.6m, 416, "Harper Business", 14, 3m, 2022 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 25,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 20.3m, "9780812981605", 13.2m, 416, "Random House Trade Paperbacks", 19, 2.2m, 2014 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 26,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 22.9m, "9781735617480", 15.2m, 238, "Armin Lear Press", 19, 1.3m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 27,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 22.9m, "9781982154806", 15.2m, 320, "Gallery Books", 19, 3.3m, 2020 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 28,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 21.3m, "9780525543022", 14.0m, 496, "Portfolio", 15, 14.0m, 2020 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 29,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 22.4m, "9780857199096", 14.9m, 256, "Harriman House", 16, 2.2m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 30,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 23.1m, "9780140280197", 16.3m, 452, "Penguin Books", 19, 3.3m, 2000 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 31,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 23.6m, "9781936661848", 15.6m, 246, "BenBella Books", 15, 2.4m, 2012 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 32,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 22.9m, "9781989025017", 15.2m, 232, "Page Two", 17, 1.3m, 2018 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 33,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 23.5m, "9781647820381", 15.6m, 304, "Harvard Business Review Press", 19, 2m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 34,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 19.7m, "9781585424337", 12.9m, 320, "TarcherPerigee", 14, 1.1m, 2007 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 35,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 23.5m, "9781119868569", 18.7m, 656, 14, 3.8m, 2022 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 36,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 23.6m, "9781948836951", 15.9m, 240, "BenBella Books", 14, 2.2m, 2020 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 37,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 25.4m, "9781623155360", 17.8m, 124, "Callisto", 16, 0.7m, 2015 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 38,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 22.9m, "9781916962132", 15.2m, 209, 14, 1.2m, 2024 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 39,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 23.6m, "9780593715833", 16m, 368, "Portfolio", 19, 3m, 2023 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 40,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 21.7m, "9780593539774", 14.5m, 240, "Portfolio", 14, 2.3m, 2024 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 41,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 24.3m, "9781250179944", 16.5m, 304, "St. Martin's Essentials", 19, 2.4m, 2019 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 42,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 3, 20.3m, "9780060555665", 13.5m, 640, "Harper Business", 18, 4.1m, 2006 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 43,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.5m, "9781593279660", 17.9m, 384, "No Starch Press", 20, 2.3m, 2020 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 44,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 27.9m, "9780997326437", 21.6m, 102, "Jack Stanley", 20, 0.6m, 2017 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 45,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 22.9m, "9781978104471", 15.2m, 115, "CreateSpace Independent Publishing Platform", 20, 0.7m, 2017 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 46,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.2m, "9780672337451", 17.8m, 1265, "Sams Publishing", 20, 3.5m, 2015 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 47,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.3m, "9780596003869", 17.8m, 320, "O'Reilly Media", 20, 2m, 2002 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 48,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 22.9m, "9781518662584", 15.2m, 238, "CreateSpace Independent Publishing Platform", 20, 1.4m, 2015 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 49,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 22.6m, "9781942270843", 18.3m, 900, "Mercury Learning and Information", 23, 5.6m, 2016 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 50,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 17.8m, "9780596004286", 11.9m, 150, "O'Reilly Media", 24, 1.2m, 2003 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 51,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 4, 27.9m, "9798322098645", 21.6m, 113, "Independently published", 20, "Python Programming for Beginners: A Complete Step-by-Step Guide with Practical Exercises, Coding Tips, and Career-Boosting Strategies — Master Python in 7 Days", 0.7m, 2023 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 52,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 27.9m, "9781951077105", 22.9m, 906, "Kidware Software", 20, 4.6m, 2019 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 53,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 22.9m, "9781698927831", 15.2m, 148, "Independently published", 20, 1.7m, 2019 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 54,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 22.9m, "9781590592755", 22.6m, 392, "Apress", 24, 2.3m, 2003 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 55,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 27.9m, "9781951077129", 19.1m, 940, "Kidware Software", 24, 2.4m, 2019 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 56,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 25.1m, "9780135225486", 21.6m, 496, "Pearson", 22, 2.2m, 2019 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 57,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 27.9m, "9781337102117", 25.4m, 752, "Cengage Learning", 22, 2.5m, 2017 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 58,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 30.5m, "9780134542782", 27.4m, 720, "Pearson", 20, 3m, 2016 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 59,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 22.9m, "9781719439558", 11.7m, 201, "CreateSpace Independent Publishing Platform", 20, 1.2m, 2018 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 60,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 22.9m, "9781974581214", 15.2m, 151, 20, 0.9m, 2017 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 61,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.5m, "9780321525949", 19.1m, 927, "Addison-Wesley Professional", 21, 6.4m, 2005 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 62,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.5m, "9780130340740", 19.7m, 978, "Prentice Hall", 21, 3.8m, 2002 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 63,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 24.7m, "9780521607650", 18.9m, 556, "Cambridge University Press", 21, 3.2m, 2008 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 64,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.5m, "9780262162289", 21.0m, 588, "The MIT Press", 21, 3.4m, 2004 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 65,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 24.5m, "9780201896831", 16.9m, 672, "Addison-Wesley Professional", 21, 3.6m, 1997 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 66,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.5m, "9780134843469", 17.1m, 433, "Prentice Hall", 21, 1.9m, 1998 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 67,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 25.4m, "9789353068967", 20.3m, 288, "Pearson India", 21, 4.7m, 2018 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 68,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.9m, "9780072465631", 19.8m, 1104, "McGraw-Hill", 21, 4.6m, 2002 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 69,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 22.9m, "9780132316811", 18.5m, 600, "Pearson", 21, 3m, 2011 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 70,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.2m, "9780133390094", 17.8m, 772, "Pearson", 21, 4.4m, 2013 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 71,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.5m, "9780521880374", 15.9m, 474, "Cambridge University Press", 21, 2.5m, 2008 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 72,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.1m, "9780131774292", 19.2m, 353, "Pearson", 21, 3m, 1994 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 73,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.9m, "9781138627000", 19.6m, 1178, "A K Peters/CRC Press", 21, 4.8m, 2018 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 74,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 23.4m, "9780470474242", 18.5m, 384, "Wiley", 23, 2.5m, 2010 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 75,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 4, 27.9m, "9781365185830", 21.6m, 282, "Lulu.com", 24, 1.6m, 2016 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 76,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 19m, "9780316286398", 11m, 976, "Little", 1, 4m, 2014 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 77,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 20.3m, "9780804172707", 13.2m, 832, "Anchor Books", 1, 3.5m, 2016 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 78,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Year" },
                values: new object[] { 1, 18m, "9780307386458", 11m, 304, "Vintage", 1, 2007 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 79,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 19.7m, "9780141199795", 14.1m, 944, "Penguin Books Ltd", 1, 4.3m, 2012 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 80,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 21m, "9781949846393", 14m, 216, "Clydesdale", 1, 2m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 81,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 24m, "9780593447796", 16m, 368, "Hogarth Press", 1, 3m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 82,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 20m, "9780375703867", 13m, 464, "Vintage", 1, 3m, 2001 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 83,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 20m, "9780307744432", 13m, 528, "Anchor", 1, 3m, 2012 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 84,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 21m, "9780679731726", 13m, 256, "Vintage", 1, 2m, 1990 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 85,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 19m, "9780307949486", 11m, 644, "Vintage Crime/Black Lizard", 2, 4m, 2011 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 86,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 17m, "9780385347778", 11m, 576, "Crown", 2, 3m, 2012 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 87,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 21m, "9780425274866", 14m, 512, "Berkley Books", 2, 3m, 2015 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 88,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 20.9m, "9781250301703", 13.4m, 368, "Celadon Books", 2, 2.4m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 89,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 20m, "9780062905086", 13m, 464, "William Morrow & Company", 2, 3m, 2020 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 90,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 20m, "9780307277671", 15m, 480, "Random House Inc. (US)", 2, 3m, 2018 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 91,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 1, 20.8m, "9781250805676", 17.1m, 176, 1499.00m, "Tor Books", 3, "Sands of Dune: Novellas from the Worlds of Dune: Dune, Book 11 (Hardcover)", 2.1m, 2022 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 92,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 22.8m, "9780063347533", 15m, 432, "William Morrow", 3, 3.7m, 2023 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 93,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 1, 24m, "9780756404079", 16m, 672, "DAW", 3, "The Name of the Wind: Kingkiller Chronicles, Book 1 (Hardcover)", 5m, 2007 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 94,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 21m, "9780441007318", 13m, 336, "Ace", 3, 2m, 2000 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 95,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 1, 21m, "9780316229296", 14m, 512, "Orbit", 3, "The Fifth Season: The Broken Earth, Book 1", 3.4m, 2015 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 96,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 17.3m, "9780441569595", 10.6m, 336, "Ace", 3, 2.3m, 1986 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 97,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 19.1m, "9781645176237", 12.7m, 320, "Canterbury Classics", 4, 2.1m, 2024 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 98,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 20m, "9780062439598", 13m, 384, "William Morrow Paperbacks", 4, 3m, 2016 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 99,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 22m, "9780143124542", 14m, 369, "Penguin Putnam Inc.", 4, 2m, 2013 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 100,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 21m, "9781250316776", 15m, 432, "St. Martin's Griffin", 4, 3m, 2019 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 101,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 1, 23.3m, "9780385319959", 15.4m, 672, "Dell", 4, "Outlander: A Novel", 3.6m, 1998 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 102,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 1, 21m, "9781643756288", 13.8m, 416, "\r\nAlgonquin Books", 5, "The Nightingale Affair", 2.2m, 2024 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 103,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 20.3m, "9781501173219", 13.3m, 544, "Scribner", 5, 3m, 2017 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 104,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 20.3m, "9780375842207", 12.2m, 608, "Knopf Books for Young Readers", 5, 3.2m, 2007 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 105,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 20m, "9780062797155", 13m, 288, "Harper Paperbacks", 5, 2m, 2018 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 106,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 19.8m, "9781407132099", 12.8m, 472, "Scholastic", 6, 3m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 107,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 1, 20m, "9780063040519", 14m, 544, "Katherine Tegen Books", 6, 3m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 108,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 1, 21m, "9780385737951", 14m, 375, "Delacorte Press", 6, "The Maze Runner: The Maze Runner, Book 1", 3m, 2010 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 109,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 1, 19.8m, "9781407196930", 12.8m, 272, "Scholastic Inc.", 6, "Tunnel of Bones: City of Ghosts, Book 2", 1.8m, 2019 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 110,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 2, 24m, "9781524763138", 17m, 448, "Crown Publishing Group (NY)", 7, 3m, 2018 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 111,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 2, 20m, "9780399590528", 13m, 368, "Random House Trade Paperbacks", 7, "Educated: A Memoir", 2m, 2022 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 112,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 2, 23.4m, "9781982176860", 15.6m, 672, "Simon & Schuster", 7, "Steve Jobs, 10th Anniversary Edition", 4.1m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 113,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 2, 23.6m, "9780735211292", 15.8m, 320, "Avery", 8, "Atomic Habits: An Easy & Proven Way to Build Good Habits & Break Bad Ones", 2.6m, 2018 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 114,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 2, 22m, "9781577314806", 15m, 224, "New World Library", 8, "The Power of Now: A Guide to Spiritual Enlightenment", 1m, 2004 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 115,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 2, 21m, "9780735223134", 14m, 288, "Penguin Putnam Inc.", 8, "You Are a Badass at Making Money: Master the Mindset of Wealth", 2m, 2018 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 116,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 2, 21m, "9781501144325", 14m, 368, "Scribner", 9, "Why We Sleep: Unlocking the Power of Sleep and Dreams", 3m, 2018 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 117,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 2, 21.3m, "9780143127741", 13.7m, 464, "Penguin Books", 9, "The Body Keeps the Score: Brain, Mind, and Body in the Healing of Trauma", 2.8m, 2015 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 118,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 2, 24m, "9781250127761", 20m, 272, "Flatiron Books", 9, "How Not To Die Cookbook: 100+ Recipes To Help Prevent And Reverse Disease", 2m, 2017 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 119,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 2, 24m, "9781476753836", 19m, 480, "Simon & Schuster", 11, "Salt, Fat, Acid, Heat: Mastering the Elements of Good Cooking", 3.5m, 2017 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 120,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Width", "Year" },
                values: new object[] { 2, 23.7m, "9780593537473", 18.7m, 496, "Knopf", 11, 3.7m, 2023 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 121,
                columns: new[] { "CategoryId", "Height", "ISBN", "Length", "Pages", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { 2, 21m, "9781250887313", 13.7m, 352, "Holt Paperbacks", 13, "The Sixth Extinction: An Unnatural History", 2.2m, 2024 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 122,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Yuval Noah Harari", 2, new DateTime(2024, 9, 29, 15, 28, 41, 0, DateTimeKind.Unspecified), "In Sapiens, Yuval Noah Harari explores the history of humankind, weaving together anthropology, history, and economics to understand how Homo sapiens became the dominant species on the planet. Through this lens, he examines how our collective narratives and beliefs have shaped societies and influenced our behavior over time, making it an essential read for anyone interested in understanding the complex web of human existence.", 23m, "9780062316110", "f79d3d3c-ece5-494c-9145-7d558fefb57d.webp", 15m, 464, 840.00m, "Harper Collins Publishers", 13, "Sapiens: A Brief History of Humankind", 3m, 2018 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 123,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Eric Carle", 6, new DateTime(2024, 9, 29, 18, 35, 26, 0, DateTimeKind.Unspecified), "The all-time classic picture book, from generation to generation, sold somewhere in the world every 30 seconds! A sturdy and beautiful book to give as a gift for new babies, baby showers, birthdays, and other new beginnings!\n\nFeaturing interactive die-cut pages, this board book edition is the perfect size for little hands and great for teaching counting and days of the week.", 12.7m, "9780399226908", "15df3bfc-2a25-4c2b-b21a-359dd8ba41a5.webp", 18.1m, 26, 620.00m, "World of Eric Carle", 29, "The Very Hungry Caterpillar", 1.6m, 1994 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 124,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Bill Martin, Jr., Eric Carle", 5, new DateTime(2024, 9, 29, 18, 36, 19, 0, DateTimeKind.Unspecified), "Handpicked by Amazon kids' books editor, Seira Wilson, for Prime Book Box a children's subscription that inspires a love of reading.\n\nA big happy frog, a plump purple cat, a handsome blue horse, and a soft yellow duck all parade across the pages of this delightful book. Children will immediately respond to Eric Carle's flat, boldly colored collages. Combined with Bill Martin's singsong text, they create unforgettable images of these endearing animals.", 18m, "9780805047905", "7af68300-bf82-4ca7-a145-00bb969b362c.webp", 13m, 24, 500.00m, "Henry Holt & Company Inc", 27, "Brown Bear, Brown Bear, What Do You See?", 2m, 1996 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 125,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Dr. Seuss", 5, new DateTime(2024, 9, 29, 18, 37, 27, 0, DateTimeKind.Unspecified), "The Cat is back—along with some surprise friends—in this beloved Beginner Book by Dr. Seuss. Dick and Sally have no time to play. It’s winter and they have mountains of snow to shovel. So when the Cat comes to visit, he decides to go inside and to take a bath. No problem, right? Wrong! The pink ring he leaves in the tub creates is a very BIG pink problem when he transfers the stubborn stain from the bath onto Mother’s white dress, Dad’s shoes, the floors, the walls, and ultimately, over the entire yard full of snow! Will the kids EVER clean up the mess? You bet they will, with some help from the Cat and his helpers: 26 miniature cats (AKA Little Cats A-Z) who live inside the Cat’s hat! This classic Dr. Seuss story is the perfect choice for beginning readers and read-alouds, especially on snow days! And with a peel-off 60th Anniversary sticker on the front cover, it makes a perfect gift for all ages.", 24m, "9780394800028", "361a53c9-b994-499f-a23c-eda3f22b79bd.webp", 18m, 72, 560.00m, "Random House Inc. (US)", 27, "The Cat in the Hat Comes Back", 1m, 1958 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 126,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "The Princeton Review", 5, new DateTime(2024, 9, 29, 18, 39, 1, 0, DateTimeKind.Unspecified), "SUCCEED ON THE SAT WITH THE PRINCETON REVIEW! With 6 full-length practice tests (4 in the book and 2 online), in-depth reviews for all exam content, and strategies for scoring success, SAT Prep, 2023 covers every facet of this challenging and important test.\n\nTechniques That Actually Work\n· Powerful tactics to help you avoid traps and beat the SAT\n· Pacing tips to help you maximize your time\n· Detailed examples showing how to employ each strategy to your advantage.", 27.3m, "9780593450598", "d6382628-112f-47bb-a95e-220f1404f5db.webp", 21.1m, 832, 1320.00m, "Princeton Review", 28, "Princeton Review SAT Prep, 2023: 6 Practice Tests + Review & Techniques + Online Tools", 4.5m, 2022 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 127,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "The College Board", 5, new DateTime(2024, 9, 29, 18, 40, 38, 0, DateTimeKind.Unspecified), "The Official Digital SAT Study Guide™ provides a comprehensive resource for understanding updates to the SAT® in the digital format. It includes four official practice tests―all created by the test maker. As part of College Board’s commitment to access, practice tests are also available in the digital testing platform, Bluebook™, at no charge. However, the guide is the only place to find practice tests in print accompanied by over 300 pages of additional instruction, guidance, and test information.\n\nThe Official Digital SAT Study Guide will help students get ready for the digital SAT with:\n• four official digital SAT practice tests, created from the same process used for the actual test.\n• detailed descriptions of the Reading and Writing and Math sections of the digital SAT.\n• targeted sample questions for each question type.\n• question drills by topic.\n• test-taking approaches and suggestions.\n• detailed explanations of right and wrong answers.\n• information on preparing for the digital PSAT/NMSQT® or PSAT™ 10.", 27.6m, "9781457316708", "6e70daea-d85a-447b-8453-9f3e05c7b86d.webp", 21m, 630, 2000.00m, "College Board", 28, "The Official Digital SAT Study Guide", 2.7m, 2023 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 128,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Mo Willems", 6, new DateTime(2024, 9, 29, 18, 42, 30, 0, DateTimeKind.Unspecified), "Gerald is careful. Piggie is not.\nPiggie cannot help smiling. Gerald can.\nGerald worries so that Piggie does not have to. Gerald and Piggie are best friends. In Elephants Cannot Dance! Piggie tries to teach Gerald some new moves. But will Gerald teach Piggie something even more important?", 24m, "9781423114109", "63274981-5f7f-4323-af7b-27f9ece5dd9c.webp", 17m, 57, 620.00m, "Hyperion Books for Children", 30, "Elephants Cannot Dance!, An Elephant and Piggie Book", 1m, 2009 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 129,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Alyssa Satin Capucilli", 6, new DateTime(2024, 9, 29, 18, 43, 11, 0, DateTimeKind.Unspecified), "Woof, woof! What could be more fun than making new friends with Biscuit, the little yellow puppy?\n\nMeet Biscuit’s friends, including Puddles, Nibbles the rabbit, the little girl, and many more, in this tabbed board book. Featuring eight colorful tabs and simple text, this sturdy, easy to grip board book is perfect for the littlest fans of Biscuit, everyone’s favorite little yellow puppy.", 18m, "9780063067011", "5c47c35d-f7cb-4f2c-9b2a-f85a7aaa422b.webp", 18m, 18, 400.00m, "HarperFestival", 30, "Hello, Biscuit! Hello, Friends!, Biscuit Series", 3m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 130,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Mary Pope Osborne", 6, new DateTime(2024, 9, 29, 18, 44, 41, 0, DateTimeKind.Unspecified), "Jack and Annie head to 18th-century Austria, where they must find and help a musician by the name of Mozart. Decked out in the craziest outfits they’ve ever worn—including a wig for Jack and a giant hoopskirt for Annie!—the two siblings search an entire palace to no avail. Their hunt is further hampered by the appearance of a mischievous little boy who is determined to follow them everywhere. But when they finally find Mozart, he needs help getting back to the palace to perform. Will they make it in time? Or will the little boy’s antics ruin everything? Full of excitement, danger, and a touch of magic, this adventure is sure to entertain young readers!", 20m, "9780375856471", "fd178e86-3d8d-4818-9aa3-8ac0fd8b63f9.webp", 14m, 144, 300.00m, "Random House Books for Young Readers", 31, "Moonlight on the Magic Flute: Magic Tree House, Book 13", 1m, 2010 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 131,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Barbara Park", 6, new DateTime(2024, 9, 29, 18, 44, 46, 0, DateTimeKind.Unspecified), "Meet the World's Funniest Kindergartner--Junie B. Jones! That meanie Jim has invited everyone in Room Nine to his birthday party on Saturday--except Junie B.! Should she have her own birthday party six months early and not invite Jim? Or should she move to It's a Small World After All in Disneyland?", 20m, "9780679866954", "8f8c33ef-7927-4223-885f-0fa6828f2037.webp", 14m, 96, 130.00m, "Random House Books for Young Readers", 31, "Junie B. Jones and That Meanie Jim's Birthday: Junie B. Jones, Book 6", 1m, 1996 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 132,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Madeleine L'Engle", 6, new DateTime(2024, 9, 29, 18, 46, 15, 0, DateTimeKind.Unspecified), "It was a dark and stormy night; Meg Murry, her small brother Charles Wallace, and her mother had come down to the kitchen for a midnight snack when they were upset by the arrival of a most disturbing stranger.\n\n\"Wild nights are my glory,\" the unearthly stranger told them. \"I just got caught in a downdraft and blown off course. Let me sit down for a moment, and then I'll be on my way. Speaking of ways, by the way, there is such a thing as a tesseract.\"", 19m, "9780312367541", "00437f61-f4bb-4c53-948e-9d48fba958c0.webp", 13m, 256, 500.00m, "Square Fish", 32, "A Wrinkle in Time", 2m, 2007 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 133,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Lois Lowry", 6, new DateTime(2024, 9, 29, 18, 47, 15, 0, DateTimeKind.Unspecified), "For the first time, the Giver Quartet, four critically acclaimed modern classics, in one paperback boxed set. From two-time Newbery Medal winner and New York Times bestselling author Lois Lowry.\n\nFollow Jonas on his journey to discover the dark implications of his seemingly ideal community; witness Kira’s fight for survival and pursuit of an unmatched talent in a society blinded by prejudice; join Matty’s desperate mission to save Village and the practice of openness and honesty fostered there; and complete the story with Claire’s utter devotion to a child that was stolen from her, no matter what it takes to find him again.", 22m, "9780544340626", "26c83209-99bd-4c77-845b-d192fac33446.webp", 16m, 864, 2300.00m, "Houghton Mifflin Harcourt Publishing Company", 32, "The Giver, Quartet Boxed Set", 8m, 2014 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 134,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Masashi Kishimoto", 7, new DateTime(2024, 9, 29, 18, 50, 34, 0, DateTimeKind.Unspecified), "Naruto is a young shinobi with an incorrigible knack for mischief. He’s got a wild sense of humor, but Naruto is completely serious about his mission to be the world’s greatest ninja!\n\nNaruto and his team engage in an intense battle with the Akatsuki organization as both sides seek the power to determine the future of their land. Internecine fighting weakens the Akatsuki, but will their dark forces sideline Naruto?!", 19m, "9781421541020", "b6f9c49c-0e9b-4bce-af5c-d649d1245472.webp", 13m, 192, 560.00m, "VIZ Media", 33, "Naruto, Vol. 54", 2m, 2012 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 135,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Eiichiro Oda", 7, new DateTime(2024, 9, 29, 18, 51, 21, 0, DateTimeKind.Unspecified), "Join Monkey D. Luffy and his swashbuckling crew in their search for the ultimate treasure, One Piece! As a child, Monkey D. Luffy dreamed of becoming King of the Pirates. But his life changed when he accidentally gained the power to stretch like rubber...at the cost of never being able to swim again!\n\nYears later, Luffy sets off in search of the One Piece, said to be the greatest treasure in the world... As the battle of Onigashima heats up, Kaido's daughter Yamato actually wants to join Luffy's side. Meanwhile, Kaido reveals his grand plans and together with Big Mom, prepare to plunge the entire world in fear!", 19m, "9781974725199", "278c534e-0654-4e8a-bcda-0ed87bc61b2f.webp", 13m, 200, 680.00m, "Viz Media LLC", 33, "One Piece, Vol. 98", 1m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 136,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Hajime Isayama", 7, new DateTime(2024, 9, 29, 18, 52, 4, 0, DateTimeKind.Unspecified), "HUMANITY PUSHES BACK!\n\nThe Survey Corps develop a risky gambit—have Eren in Titan form attempt to repair Wall Rose, reclaiming human territory from the monsters for the first time in a century. But Titan-Eren’s self-control is far from perfect, and when he goes on a rampage, not even Armin can stop him! With the survival of humanity on his massive shoulders, will Eren be able to return to his senses, or will he lose himself forever?", 19.1m, "9781612622538", "84420467-d643-494e-be09-66e4078a7a31.webp", 12.6m, 192, 600.00m, "Kodansha Comics", 33, "Attack on Titan, Vol. 4", 1.4m, 2013 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 137,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Tsugumi Ohba", 7, new DateTime(2024, 9, 29, 18, 52, 47, 0, DateTimeKind.Unspecified), "Light Yagami is an ace student with great prospects--and he's bored out of his mind. But all that changes when he finds the Death Note, a notebook dropped by a rogue Shinigami death god. Any human whose name is written in the notebook dies, and now Light has vowed to use the power of the Death Note to rid the world of evil. But when criminals begin dropping dead, the authorities send the legendary detective L to track down the killer. With L hot on his heels, will Light lose sight of his noble goal...or his life?\n\nAlthough they've collected plenty of evidence tying the seven Yotsuba members to the newest Kira, Light, L and the rest of the task force are no closer to discovering which one actually possesses the Death Note. Desperate for some headway, L recruits Misa to infiltrate the group and feed them information calculated to bring Kira into the open. But the Shinigami Rem reveals to Misa who the Kiras really are, and, armed with this knowledge, Misa will do anything to help Light. But what will that mean for L...?", 19.1m, "9781421506272", "6198e70d-74a7-4b1e-9bbf-160323235b6b.webp", 12.7m, 224, 570.00m, "VIZ Media LLC", 33, "Death Note, Vol. 6", 1.8m, 2006 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 138,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Kohei Horikoshi", 7, new DateTime(2024, 9, 29, 18, 53, 45, 0, DateTimeKind.Unspecified), "What would the world be like if 80 percent of the population manifested superpowers called \"Quirks\"? Heroes and villains would be battling it out everywhere! Being a hero would mean learning to use your power, but where would you go to study? The Hero Academy of course! But what would you do if you were one of the 20 percent who were born Quirkless?\n\nThe final stages of the U.A. High sports festival promise to be explosive, as Uraraka takes on Bakugo in a head-to-head match! Bakugo never gives anyone a break, and the crowd holds its breath as the battle begins. The finals will push the students of Class 1-A to their limits and beyond!", 19m, "9781421587028", "f5b77b03-fd1c-4910-be83-4e7ceb6d0c3e.webp", 13m, 192, 560.00m, "Viz Media", 33, "My Hero Academia, Vol. 5", 2m, 2016 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 139,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Alan Moore", 7, new DateTime(2024, 9, 29, 19, 3, 21, 0, DateTimeKind.Unspecified), "Batman: The Killing Joke is Alan Moore's unforgettable meditation on the razor-thin line between sanity and insanity, heroism and villainy, comedy and tragedy.\n\nOne bad day is all it takes according to the grinning engine of madness and mayhem known as the Joker, that's all that separates the sane from the psychotic. Freed once again from the confines of Arkham Asylum, he's out to prove his deranged point. And he's going to use Gotham City's top cop, Commissioner Jim Gordon, and the Commissioner's brilliant and beautiful daughter Barbara to do it.", 28m, "9781401294052", "b8d98594-008f-48f1-8108-248919bf2d30.webp", 19m, 96, 1020.56m, "DC Comics", 34, "Batman: The Killing Joke Deluxe, New Edition", 2m, 2019 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 140,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Alan Moore, Dave Gibbons (Illustrator)", 7, new DateTime(2024, 9, 29, 19, 4, 54, 0, DateTimeKind.Unspecified), "In an alternate world where the mere presence of American superheroes changed history, the US won the Vietnam War, Nixon is still president, and the cold war is in full effect!\n\nWatchmen begins as a murder-mystery, but soon unfolds into a planet-altering conspiracy. As the resolution comes to a head, the unlikely group of reunited heroes--Rorschach, Nite Owl, Silk Spectre, Dr. Manhattan and Ozymandias--have to test the limits of their convictions and ask themselves where the true line is between good and evil.\n\nIn the mid-eighties, Alan Moore and Dave Gibbons created Watchmen, changing the course of comics' history and essentially remaking how popular culture perceived the genre. Popularly cited as the point where comics came of age, Watchmen's sophisticated take on superheroes has been universally acclaimed for its psychological depth and realism.", 28.4m, "9781401238964", "ee32f552-c5f3-4743-b179-7a161abe2556.webp", 18.5m, 448, 2300.00m, "DC Comics", 34, "Watchmen, Deluxe Edition", 2.6m, 2013 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 141,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Chris Claremont, John Byrne", 7, new DateTime(2024, 9, 29, 19, 5, 50, 0, DateTimeKind.Unspecified), "The X-Men have fought many battles, been on galaxy-spanning adventures and defeated enemies of limitless might ― but none of it prepared them for the most shocking struggle they would ever face. One of their own, Jean Grey, has gained cosmic power beyond all comprehension ― and that power has corrupted her absolutely! Now, the X-Men must decide whether the life of the friend they cherish is worth the possible destruction of the entire universe!\n\nThis touching tale of ultimate power and the triumph of the human spirit has been a cornerstone of the X-Men mythos for decades. Relive the saga that changed everything!", 25.8m, "9781302950033", "7e8a29ef-c94b-47d9-b134-f2f28d451539.webp", 16.9m, 200, 1685.00m, "Marvel Universe", 34, "X-Men: Dark Phoenix Saga", 0.8m, 2023 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 142,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Stan Lee", 7, new DateTime(2024, 9, 29, 19, 6, 34, 0, DateTimeKind.Unspecified), "The Penguin Classics Marvel Collection presents the origin stories, seminal tales, and characters of the Marvel Universe to explore Marvel's transformative and timeless influence on an entire genre of fantasy. A Penguin Classics Marvel Collection Edition Collects Spider-Man!” from Amazing Fantasy #15 (1962); The Amazing Spider-Man #1-4, #9, #10, #13, #14, #17-19 (1963-1964); Goodbye to Linda Brown” from Strange Tales #97 (1962); How Stan Lee and Steve Ditko Create Spider-Man!” from The Amazing Spider-Man Annual #1 (1964).\n\nIt is impossible to imagine American popular culture without Marvel Comics. For decades, Marvel has published groundbreaking visual narratives that sustain attention on multiple levels: as metaphors for the experience of difference and otherness; as meditations on the fluid nature of identity; and as high-water marks in the artistic tradition of American cartooning, to name a few. This anthology contains twelve key stories from the first two years of Spider-Man's publication history (from 1962 to 1964).", 25m, "9780143135739", "7045bac4-8073-44c4-9264-1ba144637aa7.webp", 17m, 384, 1575.00m, "Random House Inc.", 34, "The Amazing Spider-Man, Penguin Classics Marvel Collection", 4m, 2022 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 143,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Stock", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Brian K. Vaughan", 7, new DateTime(2024, 9, 29, 19, 8, 1, 0, DateTimeKind.Unspecified), "BRIAN K. VAUGHAN and FIONA STAPLES have been hard at work on the second half of Hazels epic journey. Exciting news is coming, and anyone looking for a cool new way to catch up on the Eisner Award-winning series can look no further than this gorgeous box set, collecting all nine of the bestselling trade paperback collections in one affordable package. This is the perfect way for any mature readers” who havent yet tried SAGA to dip their toes into this weirdly wonderful universe. Collects SAGA VOL. 1-9 trade paperback with a set of 6 x 9 cover prints exclusive to the box set!", 27m, "9781534321403", "95d68321-bd28-4411-b67b-c507f989e7c9.webp", 17m, 1524, 7500.00m, "Image Comics", 20, 35, "Saga Boxed Set: Vol. 1-9", 7.2m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 144,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Marjane Satrapi", 7, new DateTime(2024, 9, 29, 19, 8, 52, 0, DateTimeKind.Unspecified), "In powerful black-and-white comic strip images, Satrapi tells the coming-of-age story of her life in Tehran from ages six to fourteen, years that saw the overthrow of the Shah’s regime, the triumph of the Islamic Revolution, and the devastating effects of war with Iraq. The intelligent and outspoken only child of committed Marxists and the great-granddaughter of one of Iran’s last emperors, Marjane bears witness to a childhood uniquely entwined with the history of her country.", 22.4m, "9780375714573", "bbd46ca2-4329-4996-a56f-7e035fcd60c7.webp", 15.1m, 57, 686.00m, "Pantheon", 35, "Persepolis: The Story of a Childhood", 1.3m, 2024 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 145,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Stock", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Alison Bechdel", 7, new DateTime(2024, 9, 29, 19, 9, 42, 0, DateTimeKind.Unspecified), "Alison Bechdel’s groundbreaking, bestselling graphic memoir that charts her fraught relationship with her late father. Distant and exacting, Bruce Bechdel was an English teacher and director of the town funeral home, which Alison and her family referred to as the \"Fun Home.\" It was not until college that Alison, who had recently come out as a lesbian, discovered that her father was also gay. A few weeks after this revelation, he was dead, leaving a legacy of mystery for his daughter to resolve. In her hands, personal history becomes a work of amazing subtlety and power, written with controlled force and enlivened with humor, rich literary allusion, and heartbreaking detail.", 23m, "9780618871711", "aa683c1e-1cb7-46ea-8bc6-7bfdd275ca2d.webp", 15.2m, 240, 1085.00m, "INGRAM INTERNATIONAL INC", 99, 35, "Fun Home: A Family Tragicomic", 1.4m, 2007 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 146,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Rupi Kaur", 8, new DateTime(2024, 9, 29, 19, 10, 50, 0, DateTimeKind.Unspecified), "From rupi kaur, the #1 New York Times bestselling author of milk and honey, comes her long-awaited second collection of poetry. A vibrant and transcendent journey about growth and healing. Ancestry and honoring one's roots. Expatriation and rising up to find a home within yourself. Divided into five chapters and illustrated by kaur, the sun and her flowers is a journey of wilting, falling, rooting, rising, and blooming. A celebration of love in all its forms. this is the recipe of life said my mother as she held me in her arms as i wept think of those flowers you plant in the garden each year they will teach you that people too must wilt fall root rise in order to bloom.", 19.7m, "9781449486792", "9bda16c0-734e-4297-9997-4b1713e35e8f.webp", 12.7m, 256, 700.00m, "Andrews McMeel Publishing", 36, "The Sun and Her Flowers", 1.8m, 2017 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 147,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Rupi Kaur", 8, new DateTime(2024, 9, 29, 19, 11, 32, 0, DateTimeKind.Unspecified), "#1 New York Times bestseller milk and honey is a collection of poetry and prose about survival. About the experience of violence, abuse, love, loss, and femininity. The book is divided into four chapters, and each chapter serves a different purpose. Deals with a different pain. Heals a different heartache. milk and honey takes readers through a journey of the most bitter moments in life and finds sweetness in them because there is sweetness everywhere if you are just willing to look.", 19.6m, "9781449474256", "3edf039b-df6b-4228-b7de-47a67cb2260d.webp", 12.7m, 208, 845.00m, "Andrews McMeel Publishing", 36, "Milk and Honey", 1.3m, 2015 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 148,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Sylvia Plath", 8, new DateTime(2024, 9, 29, 19, 12, 44, 0, DateTimeKind.Unspecified), "When Sylvia Plath died, she not only left behind a prolific life but also her unpublished literary masterpiece, Ariel. When her husband, Ted Hughes, first brought this collection to life, it garnered worldwide acclaim, though it wasn't the draft Sylvia had wanted her readers to see. This facsimile edition restores, for the first time, Plath's original manuscript - including handwritten notes - and her own selection and arrangement of poems. This edition also includes in facsimile the complete working drafts of her poem \"Ariel,\" which provide a rare glimpse into the creative process of a beloved writer. This publication introduces a truer version of Plath's works, and will no doubt alter her legacy forever. This P.S. edition features an extra 16 pages of insights into the book, including author interviews, recommended reading, and more.", 23m, "9780060732608", "41308f5a-94bd-4cba-823f-80b22228d378.webp", 15m, 256, 1073.00m, "Harper Perennial Modern Classics", 36, "Ariel: A Facsimile of Plath's Manuscript, Reinstating Her Original Selection and Arrangement, The Restored Edition", 2m, 2005 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 149,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "William Shakespeare", 8, new DateTime(2024, 9, 29, 19, 13, 21, 0, DateTimeKind.Unspecified), "Considered one of Shakespeare’s most rich and enduring plays, the depiction of its hero Hamlet as he vows to avenge the murder of his father by his brother Claudius is both powerful and complex. As Hamlet tries to find out the truth of the situation, his troubled relationship with his mother comes to the fore, as do the paradoxes in his personality. A play of carefully crafted conflict and tragedy, Shakespeare’s intricate dialogue continues to fascinate audiences to this day.", 18m, "9780007902347", "1bc3eebf-fff2-4afa-9ac0-d68b9d46d8eb.webp", 11m, 208, 183.00m, "William Collins", 37, "Hamlet, Collins Classics", 11m, 2011 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 150,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Rebecca Skloot", 9, new DateTime(2024, 9, 29, 19, 16, 0, 0, DateTimeKind.Unspecified), "Her name was Henrietta Lacks, but scientists know her as HeLa. She was a poor Southern tobacco farmer who worked the same land as her slave ancestors, yet her cells—taken without her knowledge—became one of the most important tools in medicine: The first “immortal” human cells grown in culture, which are still alive today, though she has been dead for more than sixty years. HeLa cells were vital for developing the polio vaccine; uncovered secrets of cancer, viruses, and the atom bomb’s effects; helped lead to important advances like in vitro fertilization, cloning, and gene mapping; and have been bought and sold by the billions. Yet Henrietta Lacks remains virtually unknown, buried in an unmarked grave.", 20.3m, "9781400052189", "06a9d080-8986-449f-bb32-faa550759626.webp", 13.1m, 400, 700.00m, "Crown", 38, "The Immortal Life of Henrietta Lacks", 2.6m, 2011 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 151,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Stephen Hawking", 9, new DateTime(2024, 9, 29, 19, 18, 23, 0, DateTimeKind.Unspecified), "A landmark volume in science writing by one of the great minds of our time, Stephen Hawking's book explores such profound questions as: How did the universe begin--and what made its start possible? Does time always flow forward? Is the universe unending--or are there boundaries? Are there other dimensions in space? What will happen when it all ends? Told in language we all can understand, A Brief History of Time plunges into the exotic realms of black holes and quarks, of antimatter and \"arrows of time,\" of the big bang and a bigger God--where the possibilities are wondrous and unexpected. With exciting images and profound imagination, Stephen Hawking brings us closer to the ultimate secrets at the very heart of creation.", 23m, "9780553380163", "e110da54-cbd3-4d27-b021-b77a552ceb25.webp", 15m, 240, 999.00m, "Bantam Books", 39, "A Brief History of Time", 2m, 1998 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 152,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "DK", 9, new DateTime(2024, 9, 29, 19, 20, 23, 0, DateTimeKind.Unspecified), "Are you short of time but hungry for knowledge? This beginner's quantum physics book proves that sometimes less is more. Bold graphics and easy-to-understand explanations make it the most accessible guide to quantum physics on the market. This smart but powerful guide cuts through the jargon and gives you the facts in a clear, visual way. Step inside the strange and fascinating world of subatomic physics that at times seems to conflict with common sense. Unlock the mysteries of more than 100 key ideas, from quantum mechanics basics to the uncertainty principle and quantum tunneling.", 22m, "9780241471227", "0afd4b9c-5b8a-4b8e-bcf8-c57652e23e12.webp", 16m, 160, 779.00m, "DK", 39, "Simply Quantum Physics", 2m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 153,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "North Parade Publishing", 9, new DateTime(2024, 9, 29, 19, 21, 9, 0, DateTimeKind.Unspecified), "The Wonders of Learning series helps your child to learn about the incredible world around them. With captivating illustrations and detailed analyses of key facts and fascinating information, these books are fun and fact-packed!", 25m, "9781786905185", "dec8cf3d-4667-4dca-a28c-ae2fbc047f9e.webp", 20m, 48, 280.00m, "North Parade Publishing", 39, "Wonders of Learning: Discover Physics", 1m, 2019 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 154,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Naomi Klein", 9, new DateTime(2024, 9, 29, 19, 23, 59, 0, DateTimeKind.Unspecified), "In This Changes Everything Naomi Klein argues that climate change isn't just another issue to be neatly filed between taxes and health care. It's an alarm that calls us to fix an economic system that is already failing us in many ways. Klein meticulously builds the case for how massively reducing our greenhouse emissions is our best chance to simultaneously reduce gaping inequalities, re-imagine our broken democracies, and rebuild our gutted local economies. She exposes the ideological desperation of the climate-change deniers, the messianic delusions of the would-be geoengineers, and the tragic defeatism of too many mainstream green initiatives. And she demonstrates precisely why the market has not--and cannot--fix the climate crisis but will instead make things worse, with ever more extreme and ecologically damaging extraction methods, accompanied by rampant disaster capitalism.", 22m, "9781451697391", "b0d4afe9-f227-4f5d-9c8c-822f6409e8c0.webp", 15m, 576, 1120.00m, "Simon & Schuster, Inc.", 40, "This Changes Everything: Capitalism vs. the Climate", 3m, 2015 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 155,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Carl Sagan", 9, new DateTime(2024, 9, 29, 19, 24, 58, 0, DateTimeKind.Unspecified), "Cosmos is one of the bestselling science books of all time. In clear-eyed prose, Sagan reveals a jewel-like blue world inhabited by a life form that is just beginning to discover its own identity and to venture into the vast ocean of space. Featuring a new Introduction by Sagan’s collaborator, Ann Druyan, full color illustrations, and a new Foreword by astrophysicist Neil deGrasse Tyson, Cosmos retraces the fourteen billion years of cosmic evolution that have transformed matter into consciousness, exploring such topics as the origin of life, the human brain, Egyptian hieroglyphics, spacecraft missions, the death of the Sun, the evolution of galaxies, and the forces and individuals who helped to shape modern science.", 20.2m, "9780345539434", "2d796ff2-a9da-4a90-8d3b-43928f7713ab.webp", 13.1m, 432, 1063.00m, "Ballantine Books", 41, "Cosmos", 2.3m, 2013 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 156,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Neil deGrasse Tyson", 9, new DateTime(2024, 9, 29, 19, 25, 46, 0, DateTimeKind.Unspecified), "The #1 New York Times Bestseller: The essential universe, from our most celebrated and beloved astrophysicist. What is the nature of space and time? How do we fit within the universe? How does the universe fit within us? There's no better guide through these mind-expanding questions than acclaimed astrophysicist and best-selling author Neil deGrasse Tyson. But today, few of us have time to contemplate the cosmos. So Tyson brings the universe down to Earth succinctly and clearly, with sparkling wit, in tasty chapters consumable anytime and anywhere in your busy day. While you wait for your morning coffee to brew, for the bus, the train, or a plane to arrive, Astrophysics for People in a Hurry will reveal just what you need to be fluent and ready for the next cosmic headlines: from the Big Bang to black holes, from quarks to quantum mechanics, and from the search for planets to the search for life in the universe.", 19m, "9780393609394", "93eb8ed4-b51a-4565-8dbb-0e4bd9dc2140.webp", 12m, 224, 1270.00m, "W. W. Norton & Company", 41, "Astrophysics for People in a Hurry", 2m, 2017 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 157,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "B. Greene", 9, new DateTime(2024, 9, 29, 19, 26, 57, 0, DateTimeKind.Unspecified), "From Brian Greene, one of the world's leading physicists and author the Pulitzer Prize finalist 'The Elegant Universe,' comes a grand tour of the universe that makes us look at reality in a completely different way. Space and time form the very fabric of the cosmos. Yet they remain among the most mysterious of concepts. Is space an entity? Why does time have a direction? Could the universe exist without space and time? Can we travel to the past? Greene has set himself a daunting task: to explain non-intuitive, mathematical concepts like String Theory, the Heisenberg Uncertainty Principle, and Inflationary Cosmology with analogies drawn from common experience. From Newton's unchanging realm in which space and time are absolute, to Einstein's fluid conception of spacetime, to quantum mechanics' entangled arena where vastly distant objects can instantaneously coordinate their behavior, Greene takes us all, regardless of our scientific backgrounds, on an irresistible and revelatory journey to the new layers of reality that modern physics has discovered lying just beneath the surface of our everyday world.", 20m, "9780375727207", "fb5b3c90-fc4f-4476-b3d2-48bb405d2374.webp", 14m, 592, 1125.00m, "Vintage Books", 41, "Fabric of The Cosmos", 4m, 2005 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 158,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "E.H. Gombrich", 10, new DateTime(2024, 9, 29, 19, 28, 14, 0, DateTimeKind.Unspecified), "The Story of Art has been a global bestseller for over half a century – the finest and most popular introduction ever written, published globally in more than 30 languages. Attracted by the simplicity and clarity of his writing, readers of all ages and backgrounds have found in Professor Gombrich a true master, who combines knowledge and wisdom with a unique gift for communicating his deep love of the subject.", 19m, "9781838666583", "63a5b7b9-63d6-41ad-a309-1bda2005838e.webp", 11.8m, 1064, 1996.00m, "Phaidon Press", 42, "The Story of Art", 3.8m, 2023 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 159,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "John Berger", 10, new DateTime(2024, 9, 29, 19, 29, 3, 0, DateTimeKind.Unspecified), "John Berger's seminal text on how to look at art. John Berger's Ways of Seeing is one of the most stimulating and the most influential books on art in any language. First published in 1972, it was based on the BBC television series about which the Sunday Times critic commented: 'This is an eye-opener in more ways than one: by concentrating on how we look at paintings . . . he will almost certainly change the way you look at pictures.' By now he has.", 20m, "9780140135152", "ae384aa9-ba14-4043-b8f7-0e1057cd8c6d.webp", 15m, 176, 955.00m, "Penguin Books", 42, "Ways of Seeing", 2m, 1990 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 160,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Martha Stewart", 10, new DateTime(2024, 9, 29, 19, 33, 17, 0, DateTimeKind.Unspecified), "Swirled and sprinkled, dipped and glazed, or otherwise fancifully decorated, cupcakes are the treats that make everyone smile. They are the star attraction for special days, such as birthdays, showers, and holidays, as well as perfect everyday goodies. In Martha Stewart’s Cupcakes, the editors of Martha Stewart Living share 175 ideas for simple to spectacular creations–with cakes, frostings, fillings, toppings, and embellishments that can be mixed and matched to produce just the right cupcake for any occasion.", 24m, "9780307460448", "ed969f43-24c2-4949-9209-087952fe88c7.webp", 19m, 352, 1042.00m, "Clarkson Potter", 44, "Martha Stewart's Cupcakes: 175 Inspired Ideas for Everyone's Favorite Treat", 3m, 2009 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 161,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Year" },
                values: new object[] { "Jared Diamond", 11, new DateTime(2024, 9, 29, 19, 34, 10, 0, DateTimeKind.Unspecified), "Why did Eurasians conquer, displace, or decimate Native Americans, Australians, and Africans, instead of the reverse? In this 'artful, informative, and delightful' (William H. McNeill, New York Review of Books) book, a classic of our time, evolutionary biologist Jared Diamond dismantles racist theories of human history by revealing the environmental factors actually responsible for its broadest patterns.", 24m, "9780393354324", "b50bc979-3828-47ae-be23-04dd2f089c77.webp", 16m, 528, 1440.00m, "W. W. Norton & Company", 45, "Guns, Germs, and Steel: The Fates of Human Societies", 2017 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 162,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Herodotus", 11, new DateTime(2024, 9, 29, 19, 34, 59, 0, DateTimeKind.Unspecified), "In Tom Holland's vibrant translation, one of the great masterpieces of Western history springs to life. Herodotus of Halicarnassus--hailed by Cicero as the 'Father of History'--composed his histories around 440 BC. The earliest surviving work of nonfiction, The Histories works its way from the Trojan War through an epic account of the war between the Persian empire and the Greek city-states in the fifth century BC, recording landmark events that ensured the development of Western culture and still capture our modern imagination.", 21m, "9780143107545", "79e71137-f332-4a24-a9b3-cba2efdf483c.webp", 14m, 880, 1400.00m, "Penguin Classics", 45, "The Histories, Penguin Classics Deluxe Edition-- Deckle Edge", 4m, 2015 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 163,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Anne Frank", 11, new DateTime(2024, 9, 29, 19, 36, 38, 0, DateTimeKind.Unspecified), "In a modern translation, this definitive edition contains entries about Anne’s burgeoning sexuality and confrontations with her mother that were cut from previous editions. Anne Frank’s The Diary of a Young Girl is among the most enduring documents of the twentieth century. Since its publication in 1947, it has been a beloved and deeply admired monument to the indestructible nature of the human spirit, read by millions of people and translated into more than fifty-five languages.", 22m, "9780385473781", "109b10ec-5290-4185-86a1-4e8a008738d9.webp", 15m, 352, 1830.00m, "Doubleday Publishing", 46, "The Diary of a Young Girl: The Definitive Edition", 3m, 1995 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 164,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Carl Von Clausewitz", 11, new DateTime(2024, 9, 29, 19, 38, 7, 0, DateTimeKind.Unspecified), "Writing at the time of Napoleon's greatest campaigns, Prussian soldier and writer Carl von Clausewitz created this landmark treatise on the art of warfare, which presented war as part of a coherent system of political thought. In line with Napoleon's own military actions, Clausewitz illustrated the need to annihilate the enemy and to make a strong display of one's power in an 'absolute war' without compromise.", 19.7m, "9780140444278", "38cfda27-e474-4b60-af39-66d6b6f7028f.webp", 13m, 464, 640.00m, "Penguin Classics", 47, "On War, Penguin Classics", 2m, 1982 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 165,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Sun Tzu", 11, new DateTime(2024, 9, 29, 19, 39, 6, 0, DateTimeKind.Unspecified), "\"The Art of War\" is an ancient Chinese military treatise attributed to Sun Tzu, a military strategist and philosopher, dating back to the 5th century BC. The book is composed of 13 chapters, each addressing different aspects of warfare and military strategy. It emphasizes the importance of strategy, deception, and flexibility in combat and offers timeless insights that apply not only to military conflicts but also to various aspects of life, including business and leadership.", 19.7m, "9781444727364", "0f8082b3-8146-4d1b-9bfe-afbd70da3e4f.webp", 12.9m, 102, 340.00m, "Hodder & Stoughton", 47, "The Art of War", 0.7m, 1981 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 166,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Catholic Bible Press", 12, new DateTime(2024, 9, 29, 19, 39, 6, 0, DateTimeKind.Unspecified), "This Precious Moments Catholic Bible is the perfect choice for celebrating the special milestones in the life of your child. This beautiful gift can become a usable keepsake for Baptism or First Communion, and it can be the Bible your child carries to Mass. This contains the full Catholic canon, along with helps such as prayers, reading plans, and helpful verses. And the beautiful full-color Precious Moments artwork will invite your child into the pages of Scripture.", 23m, "9780785239338", "f8775f8f-60a8-4257-818a-0076b12b0582.webp", 15m, 1344, 1120.00m, "Catholic Bible Press", 50, "NRSVCE Precious Moments Bible - Pink", 3m, 2021 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 167,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "hich Nhat Hanh", 12, new DateTime(2024, 9, 29, 19, 39, 6, 0, DateTimeKind.Unspecified), "The 20th anniversary edition of the classic text, updated, revised, and featuring a Mindful Living Journal. Buddha and Christ, perhaps the two most pivotal figures in the history of humankind, each left behind a legacy of teachings and practices that have shaped the lives of billions of people over two millennia. If they were to meet on the road today, what would each think of the other's spiritual views and practices?", 21m, "9781594482397", "fb471cbb-c7dd-4116-a952-af88c87af98e.webp", 13m, 256, 1000.00m, "Riverhead Books", 50, "Living Buddha, Living Christ: 20th Anniversary Edition", 2m, 2007 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 168,
                columns: new[] { "Author", "CategoryId", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Paulo Coelho", 12, new DateTime(2024, 9, 29, 19, 39, 6, 0, DateTimeKind.Unspecified), "The Alchemist by Paulo Coelho continues to change the lives of its readers forever. With more than two million copies sold around the world, The Alchemist has established itself as a modern classic, universally admired. Paulo Coelho's masterpiece tells the magical story of Santiago, an Andalusian shepherd boy who yearns to travel in search of a worldly treasure as extravagant as any ever found. The story of the treasures Santiago finds along the way teaches us, as only a few stories can, about the essential wisdom of listening to our hearts, learning to read the omens strewn along life's path, and, above all, following our dreams.", 21m, "9780060887964", "91891ef1-b04c-4fd8-afe9-b945ca4ebcae.webp", 14m, 192, 1690.00m, "HarperOne", 49, "The Alchemist, Gift Edition", 2m, 2005 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 169,
                columns: new[] { "Author", "CategoryId", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Viktor Frankl", 12, "We needed to stop asking about the meaning of life, and instead to think of ourselves as those who were being questioned by life-daily and hourly. Our answer must consist not in talk and meditation, but in right action and in right conduct. Life ultimately means taking the responsibility to find the right answer to its problems and to fulfill the tasks which it constantly sets for each individual. When Man's Search for Meaning was first published in 1959, it was hailed by Carl Rogers as 'one of the outstanding contributions to psychological thought in the last fifty years.' Now, more than forty years and 4 million copies later, this tribute to hope in the face of unimaginable loss has emerged as a true classic. Man's Search for Meaning--at once a memoir, a self-help book, and a psychology manual-is the story of psychiatrist Viktor Frankl's struggle for survival during his three years in Auschwitz and other Nazi concentration camps. Yet rather than 'a tale concerned with the great horrors,' Frankl focuses in on the 'hard fight for existence' waged by 'the great army of unknown and unrecorded.'", 17m, "9780807092156", "12b2c75e-76ae-4796-ab31-54d6ac066fc9.webp", 11m, 192, 535.00m, "Beacon Press", 51, "Man's Search for Meaning, Export Edition", 1m, 2019 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 170,
                columns: new[] { "Author", "CategoryId", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Brené Brown", 12, "For over a decade, Brene Brown has found a special place in our hearts as a gifted mapmaker and a fellow traveler. She is both a social scientist and a kitchen-table friend whom you can always count on to tell the truth, make you laugh, and, on occasion, cry with you. And what's now become a movement all started with The Gifts of Imperfection, which has sold more than two million copies in thirty-five different languages across the globe. What transforms this book from words on a page to effective daily practices are the ten guideposts to wholehearted living. The guideposts not only help us understand the practices that will allow us to change our lives and families, they also walk us through the unattainable and sabotaging expectations that get in the way.", 21.2m, "9781616499600", "fa3835fd-6184-49d7-9f06-9e58c8b1fadd.webp", 13.6m, 208, 950.00m, "Hazelden Publishing", 51, "The Gifts of Imperfection, 10th Anniversary Edition", 2m, 2022 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 171,
                columns: new[] { "Author", "CategoryId", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Marie Kondo", 13, "Marie Kondo presents the fictional story of Chiaki, a young woman in Tokyo who struggles with a cluttered apartment, messy love life, and lack of direction. After receiving a complaint from her attractive next-door neighbor about the sad state of her balcony, Chiaki gets Kondo to take her on as a client. Through a series of entertaining and insightful lessons, Kondo helps Chiaki get her home--and life--in order. This insightful, illustrated case study is perfect for people looking for a fun introduction to the KonMari Method of tidying up, as well as tried-and-true fans of Marie Kondo eager for a new way to think about what sparks joy. Featuring illustrations by award-winning manga artist Yuko Uramoto, this book also makes a great read for manga and graphic novel lovers of all ages.", 18m, "9780399580536", "1d7766d8-0632-442f-9918-2aa520f7b65c.webp", 13m, 192, 850.25m, "Random House Inc.", 52, "The Life-Changing Manga of Tidying Up: A Magical Story", 2m, 2017 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 172,
                columns: new[] { "Author", "CategoryId", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Vogue", 13, "Apo Whang-Od is the face of Vogue Philippines’ Beauty issue, which also highlights the female gaze with creative couple Kim Jones and Jericho Rosales, photographer-stylist Melissa Levy, and Joey Samson's new romantic collection.", 28.1m, "9773339000010", "3dd993c9-dbb0-4cf5-ae9f-ab835e10f426.webp", 20.9m, 160, 585.00m, "Vogue Philippines", 54, "Apo Whang-Od: Next of Skin: The Beauty Issue: Vogue Philippines, April 2023", 1m, 2023 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 173,
                columns: new[] { "Author", "CategoryId", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Collins Dictionaries", 14, "The most up-to-date and information-packed dictionary of its size available. With spelling, grammar and pronunciation help, plus a practical writing guide, the Pocket Dictionary gives you all the everyday words you need – at your fingertips.\n\nUp-to-date language coverage along with practical guidance on effective English for everyday use.", 15m, "9780008141806", "eb0ad0d8-cb6e-4723-bab2-c70bc2498de4.webp", 10.8m, 740, 540.00m, "Collins", 55, "Collins English Dictionary: Pocket edition", 3.6m, 2016 });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 174,
                columns: new[] { "Author", "CategoryId", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "SubcategoryId", "Title", "Width", "Year" },
                values: new object[] { "Douglas Adams", 14, "Seconds before Earth is demolished to make way for a galactic freeway, Arthur Dent is plucked off the planet by his friend Ford Prefect, a researcher for the revised edition of The Hitchhiker’s Guide to the Galaxy who, for the last fifteen years, has been posing as an out-of-work actor.\n\nTogether, this dynamic pair began a journey through space aided by a galaxyful of fellow travelers: Zaphod Beeblebrox—the two-headed, three-armed ex-hippie and out-to-lunch president of the galaxy; Trillian (formerly Tricia McMillan), Zaphod’s girlfriend, whom Arthur tried to pick up at a cocktail party once upon a time zone; Marvin, a paranoid, brilliant, and chronically depressed robot; and Veet Voojagig, a graduate student obsessed with the disappearance of all the ballpoint pens he’s bought over the years.", 17m, "9780345391803", "4a6119d2-acd4-4706-ba37-c3ba832c6884.webp", 10m, 224, 499.00m, "Del Rey", 56, "The Hitchhiker's Guide to the Galaxy", 2m, 2007 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fiction" },
                    { 2, "Non-Fiction" },
                    { 3, "Business & Economics" },
                    { 4, "Programming & Technology" },
                    { 5, "Education & Teaching" },
                    { 6, "Children’s Books" },
                    { 7, "Graphic Novels & Comics" },
                    { 8, "Poetry & Drama" },
                    { 9, "Science & Nature" },
                    { 10, "Arts & Photography" },
                    { 11, "History" },
                    { 12, "Spirituality & Religion" },
                    { 13, "Lifestyle" },
                    { 14, "Miscellaneous" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Literary Fiction" },
                    { 2, 1, "Mystery & Thriller" },
                    { 3, 1, "Science Fiction & Fantasy" },
                    { 4, 1, "Romance" },
                    { 5, 1, "Historical Fiction" },
                    { 6, 1, "Young Adult Fiction" },
                    { 7, 2, "Biography & Memoir" },
                    { 8, 2, "Self-Help" },
                    { 9, 2, "Health & Wellness" },
                    { 10, 2, "Travel" },
                    { 11, 2, "Cooking & Food" },
                    { 12, 2, "True Crime" },
                    { 13, 2, "Politics & Current Events" },
                    { 14, 3, "Entrepreneurship" },
                    { 15, 3, "Management" },
                    { 16, 3, "Personal Finance" },
                    { 17, 3, "Marketing" },
                    { 18, 3, "Investing" },
                    { 19, 3, "Leadership" },
                    { 20, 4, "Basic Programming" },
                    { 21, 4, "Advanced Programming" },
                    { 22, 4, "Web Development" },
                    { 23, 4, "Data Science & AI" },
                    { 24, 4, "Software Engineering" },
                    { 25, 5, "Educational Materials" },
                    { 26, 5, "Teaching Strategies" },
                    { 27, 5, "Early Childhood Education" },
                    { 28, 5, "Study Guides & Test Prep" },
                    { 29, 6, "Picture Books" },
                    { 30, 6, "Early Readers" },
                    { 31, 6, "Chapter Books" },
                    { 32, 6, "Middle Grade Fiction" },
                    { 33, 7, "Manga" },
                    { 34, 7, "Superhero Comics" },
                    { 35, 7, "Independent Comics" },
                    { 36, 8, "Poetry Collections" },
                    { 37, 8, "Plays & Screenplays" },
                    { 38, 9, "Biology" },
                    { 39, 9, "Physics" },
                    { 40, 9, "Environmental Science" },
                    { 41, 9, "Astronomy" },
                    { 42, 10, "Art History" },
                    { 43, 10, "Photography Techniques" },
                    { 44, 10, "Crafts & Hobbies" },
                    { 45, 11, "Ancient History" },
                    { 46, 11, "Modern History" },
                    { 47, 11, "Military History" },
                    { 48, 11, "World History" },
                    { 49, 12, "Spiritual Growth" },
                    { 50, 12, "World Religions" },
                    { 51, 12, "Inspirational" },
                    { 52, 13, "Home & Garden" },
                    { 53, 13, "Hobbies & Crafts" },
                    { 54, 13, "Fashion & Beauty" },
                    { 55, 14, "Reference Books" },
                    { 56, 14, "Language Learning" },
                    { 57, 14, "Humor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookInfos_CategoryId",
                table: "BookInfos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInfos_SubcategoryId",
                table: "BookInfos",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookInfos_Categories_CategoryId",
                table: "BookInfos",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInfos_Subcategories_SubcategoryId",
                table: "BookInfos",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInfos_Categories_CategoryId",
                table: "BookInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInfos_Subcategories_SubcategoryId",
                table: "BookInfos");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_BookInfos_CategoryId",
                table: "BookInfos");

            migrationBuilder.DropIndex(
                name: "IX_BookInfos_SubcategoryId",
                table: "BookInfos");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "BookInfos");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "BookInfos");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "BookInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subcategory",
                table: "BookInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 1,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 2,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 3,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 4,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 5,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 6,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 7,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 8,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 9,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 10,
                columns: new[] { "Category", "ISBN", "Publisher", "Subcategory", "Year" },
                values: new object[] { "Programming & Technology", null, null, "Advanced Programming", null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 11,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 12,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 13,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 14,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", "Concurrency in Practice", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 15,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 16,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 17,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 18,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 19,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 20,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 21,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", "Blue Ocean Strategy: How to Create Uncontested Market Space and Make C", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 22,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 23,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 24,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 25,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 26,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 27,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 28,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 29,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 30,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 31,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 32,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 33,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 34,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 35,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 36,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 37,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 38,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 39,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 40,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 41,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 42,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 43,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 44,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 45,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 46,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 47,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 48,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 49,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 50,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 51,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", "Python Programming for Beginners: A Complete Step-by-Step Guide with Practical Exercises, Coding Tips, and Career-Boosting Strategies — Master Python ", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 52,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 53,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 54,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 55,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 56,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 57,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 58,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 59,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 60,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, "Basic Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 61,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 62,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 63,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 64,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 65,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 66,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 67,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 68,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 69,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 70,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 71,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 72,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 73,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 74,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Programming & Technology", null, null, null, null, null, "Advanced Programming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 75,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Business & Economics", null, null, null, null, null, "Business", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 76,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Literary Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 77,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Literary Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 78,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Literary Fiction", null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 79,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Literary Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 80,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Literary Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 81,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Literary Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 82,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Literary Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 83,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Literary Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 84,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Literary Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 85,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Mystery & Thriller", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 86,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Mystery & Thriller", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 87,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Mystery & Thriller", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 88,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Mystery & Thriller", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 89,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Mystery & Thriller", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 90,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Mystery & Thriller", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 91,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, 615.00m, null, "Science Fiction & Fantasy", "Dune", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 92,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Science Fiction & Fantasy", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 93,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Science Fiction & Fantasy", "The Name of the Wind", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 94,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Science Fiction & Fantasy", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 95,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Science Fiction & Fantasy", "The Fifth Season", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 96,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Science Fiction & Fantasy", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 97,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Romance", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 98,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Romance", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 99,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Romance", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 100,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Romance", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 101,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Romance", "Outlander", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 102,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Historical Fiction", "The Nightingale", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 103,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Historical Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 104,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Historical Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 105,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Historical Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 106,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Young Adult Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 107,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Young Adult Fiction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 108,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Young Adult Fiction", "The Maze Runner", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 109,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Fiction", null, null, null, null, null, "Young Adult Fiction", "City of Bones", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 110,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Non-Fiction", null, null, null, null, null, "Biography & Memoir", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 111,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Non-Fiction", null, null, null, null, null, "Biography & Memoir", "Educated", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 112,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Non-Fiction", null, null, null, null, null, "Biography & Memoir", "Steve Jobs", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 113,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Non-Fiction", null, null, null, null, null, "Self-Help", "Atomic Habits", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 114,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Non-Fiction", null, null, null, null, null, "Self-Help", "The Power of Now", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 115,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Non-Fiction", null, null, null, null, null, "Self-Help", "You Are a Badass", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 116,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Non-Fiction", null, null, null, null, null, "Health & Wellness", "Why We Sleep", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 117,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Non-Fiction", null, null, null, null, null, "Health & Wellness", "The Body Keeps the Score", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 118,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Non-Fiction", null, null, null, null, null, "Health & Wellness", "How Not to Die", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 119,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Non-Fiction", null, null, null, null, null, "Cooking & Food", "Salt, Fat, Acid, Heat", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 120,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Width", "Year" },
                values: new object[] { "Non-Fiction", null, null, null, null, null, "Cooking & Food", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 121,
                columns: new[] { "Category", "Height", "ISBN", "Length", "Pages", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Non-Fiction", null, null, null, null, null, "Politics & Current Events", "The Sixth Extinction", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 122,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Tara Westover", "Non-Fiction", new DateTime(2024, 9, 29, 15, 26, 15, 0, DateTimeKind.Unspecified), "Tara Westover grew up preparing for the End of Days, her survivalist family didn't believe in public education. Educated is an account of her struggle to reconcile her desire for education and her family’s rigid belief system, ultimately leading her to leave her home and family behind.\n\nIn this memoir, she chronicles her journey from her isolated upbringing in rural Idaho to her time at Harvard and Cambridge University, providing an unforgettable story of the transformative power of education and a testament to the resilience of the human spirit.", null, null, "0d7f78c5-9fa0-4827-93d7-9445b787635f.webp", null, null, 599.00m, null, "Biography & Memoir", "Educated", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 123,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Yuval Noah Harari", "Non-Fiction", new DateTime(2024, 9, 29, 15, 28, 41, 0, DateTimeKind.Unspecified), "In Sapiens, Yuval Noah Harari explores the history of humankind, weaving together anthropology, history, and economics to understand how Homo sapiens became the dominant species on the planet. Through this lens, he examines how our collective narratives and beliefs have shaped societies and influenced our behavior over time, making it an essential read for anyone interested in understanding the complex web of human existence.", null, null, "f79d3d3c-ece5-494c-9145-7d558fefb57d.webp", null, null, 840.00m, null, "Politics & Current Events", "Sapiens", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 124,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Michelle Obama", "Non-Fiction", new DateTime(2024, 9, 29, 15, 30, 58, 0, DateTimeKind.Unspecified), "In her memoir, Becoming, former First Lady Michelle Obama invites readers into her world, chronicling the experiences that have shaped her into the woman she is today. From her childhood in the South Side of Chicago to her role as an advocate for education and health, she shares personal stories that illuminate the values that guide her and the challenges she faced on her journey to the White House and beyond.", null, null, "1b40f0e8-0424-4e84-aaf0-33789938cc9d.webp", null, null, 899.00m, null, "Biography & Memoir", "Becoming", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 125,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Eric Carle", "Children’s Books", new DateTime(2024, 9, 29, 18, 35, 26, 0, DateTimeKind.Unspecified), "The all-time classic picture book, from generation to generation, sold somewhere in the world every 30 seconds! A sturdy and beautiful book to give as a gift for new babies, baby showers, birthdays, and other new beginnings!\n\nFeaturing interactive die-cut pages, this board book edition is the perfect size for little hands and great for teaching counting and days of the week.", null, null, "15df3bfc-2a25-4c2b-b21a-359dd8ba41a5.webp", null, null, 620.00m, null, "Picture Books", "The Very Hungry Caterpillar", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 126,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Bill Martin, Jr., Eric Carle", "Education & Teaching", new DateTime(2024, 9, 29, 18, 36, 19, 0, DateTimeKind.Unspecified), "Handpicked by Amazon kids' books editor, Seira Wilson, for Prime Book Box a children's subscription that inspires a love of reading.\n\nA big happy frog, a plump purple cat, a handsome blue horse, and a soft yellow duck all parade across the pages of this delightful book. Children will immediately respond to Eric Carle's flat, boldly colored collages. Combined with Bill Martin's singsong text, they create unforgettable images of these endearing animals.", null, null, "7af68300-bf82-4ca7-a145-00bb969b362c.webp", null, null, 500.00m, null, "Early Childhood Education", "Brown Bear, Brown Bear, What Do You See?", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 127,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Dr. Seuss", "Education & Teaching", new DateTime(2024, 9, 29, 18, 37, 27, 0, DateTimeKind.Unspecified), "The Cat is back—along with some surprise friends—in this beloved Beginner Book by Dr. Seuss. Dick and Sally have no time to play. It’s winter and they have mountains of snow to shovel. So when the Cat comes to visit, he decides to go inside and to take a bath. No problem, right? Wrong! The pink ring he leaves in the tub creates is a very BIG pink problem when he transfers the stubborn stain from the bath onto Mother’s white dress, Dad’s shoes, the floors, the walls, and ultimately, over the entire yard full of snow! Will the kids EVER clean up the mess? You bet they will, with some help from the Cat and his helpers: 26 miniature cats (AKA Little Cats A-Z) who live inside the Cat’s hat! This classic Dr. Seuss story is the perfect choice for beginning readers and read-alouds, especially on snow days! And with a peel-off 60th Anniversary sticker on the front cover, it makes a perfect gift for all ages.", null, null, "361a53c9-b994-499f-a23c-eda3f22b79bd.webp", null, null, 560.00m, null, "Early Childhood Education", "The Cat in the Hat Comes Back", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 128,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "The Princeton Review", "Education & Teaching", new DateTime(2024, 9, 29, 18, 39, 1, 0, DateTimeKind.Unspecified), "SUCCEED ON THE SAT WITH THE PRINCETON REVIEW! With 6 full-length practice tests (4 in the book and 2 online), in-depth reviews for all exam content, and strategies for scoring success, SAT Prep, 2023 covers every facet of this challenging and important test.\n\nTechniques That Actually Work\n· Powerful tactics to help you avoid traps and beat the SAT\n· Pacing tips to help you maximize your time\n· Detailed examples showing how to employ each strategy to your advantage.", null, null, "d6382628-112f-47bb-a95e-220f1404f5db.webp", null, null, 1320.00m, null, "Study Guides & Test Prep", "Princeton Review SAT Prep, 2023: 6 Practice Tests + Review & Techniques + Online Tools", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 129,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "The College Board", "Education & Teaching", new DateTime(2024, 9, 29, 18, 40, 38, 0, DateTimeKind.Unspecified), "The Official Digital SAT Study Guide™ provides a comprehensive resource for understanding updates to the SAT® in the digital format. It includes four official practice tests―all created by the test maker. As part of College Board’s commitment to access, practice tests are also available in the digital testing platform, Bluebook™, at no charge. However, the guide is the only place to find practice tests in print accompanied by over 300 pages of additional instruction, guidance, and test information.\n\nThe Official Digital SAT Study Guide will help students get ready for the digital SAT with:\n• four official digital SAT practice tests, created from the same process used for the actual test.\n• detailed descriptions of the Reading and Writing and Math sections of the digital SAT.\n• targeted sample questions for each question type.\n• question drills by topic.\n• test-taking approaches and suggestions.\n• detailed explanations of right and wrong answers.\n• information on preparing for the digital PSAT/NMSQT® or PSAT™ 10.", null, null, "6e70daea-d85a-447b-8453-9f3e05c7b86d.webp", null, null, 2000.00m, null, "Study Guides & Test Prep", "The Official Digital SAT Study Guide", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 130,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Mo Willems", "Children’s Books", new DateTime(2024, 9, 29, 18, 42, 30, 0, DateTimeKind.Unspecified), "Gerald is careful. Piggie is not.\nPiggie cannot help smiling. Gerald can.\nGerald worries so that Piggie does not have to. Gerald and Piggie are best friends. In Elephants Cannot Dance! Piggie tries to teach Gerald some new moves. But will Gerald teach Piggie something even more important?", null, null, "63274981-5f7f-4323-af7b-27f9ece5dd9c.webp", null, null, 620.00m, null, "Early Readers", "Elephants Cannot Dance!, An Elephant and Piggie Book", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 131,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Alyssa Satin Capucilli", "Children’s Books", new DateTime(2024, 9, 29, 18, 43, 11, 0, DateTimeKind.Unspecified), "Woof, woof! What could be more fun than making new friends with Biscuit, the little yellow puppy?\n\nMeet Biscuit’s friends, including Puddles, Nibbles the rabbit, the little girl, and many more, in this tabbed board book. Featuring eight colorful tabs and simple text, this sturdy, easy to grip board book is perfect for the littlest fans of Biscuit, everyone’s favorite little yellow puppy.", null, null, "5c47c35d-f7cb-4f2c-9b2a-f85a7aaa422b.webp", null, null, 400.00m, null, "Early Readers", "Hello, Biscuit! Hello, Friends!, Biscuit Series", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 132,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Mary Pope Osborne", "Children’s Books", new DateTime(2024, 9, 29, 18, 44, 41, 0, DateTimeKind.Unspecified), "Jack and Annie head to 18th-century Austria, where they must find and help a musician by the name of Mozart. Decked out in the craziest outfits they’ve ever worn—including a wig for Jack and a giant hoopskirt for Annie!—the two siblings search an entire palace to no avail. Their hunt is further hampered by the appearance of a mischievous little boy who is determined to follow them everywhere. But when they finally find Mozart, he needs help getting back to the palace to perform. Will they make it in time? Or will the little boy’s antics ruin everything? Full of excitement, danger, and a touch of magic, this adventure is sure to entertain young readers!", null, null, "fd178e86-3d8d-4818-9aa3-8ac0fd8b63f9.webp", null, null, 300.00m, null, "Chapter Books", "Moonlight on the Magic Flute: Magic Tree House, Book 13", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 133,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Barbara Park", "Children’s Books", new DateTime(2024, 9, 29, 18, 44, 46, 0, DateTimeKind.Unspecified), "Meet the World's Funniest Kindergartner--Junie B. Jones! That meanie Jim has invited everyone in Room Nine to his birthday party on Saturday--except Junie B.! Should she have her own birthday party six months early and not invite Jim? Or should she move to It's a Small World After All in Disneyland?", null, null, "8f8c33ef-7927-4223-885f-0fa6828f2037.webp", null, null, 130.00m, null, "Chapter Books", "Junie B. Jones and That Meanie Jim's Birthday: Junie B. Jones, Book 6", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 134,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Madeleine L'Engle", "Children’s Books", new DateTime(2024, 9, 29, 18, 46, 15, 0, DateTimeKind.Unspecified), "It was a dark and stormy night; Meg Murry, her small brother Charles Wallace, and her mother had come down to the kitchen for a midnight snack when they were upset by the arrival of a most disturbing stranger.\n\n\"Wild nights are my glory,\" the unearthly stranger told them. \"I just got caught in a downdraft and blown off course. Let me sit down for a moment, and then I'll be on my way. Speaking of ways, by the way, there is such a thing as a tesseract.\"", null, null, "00437f61-f4bb-4c53-948e-9d48fba958c0.webp", null, null, 500.00m, null, "Middle Grade Fiction", "A Wrinkle in Time", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 135,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Lois Lowry", "Children’s Books", new DateTime(2024, 9, 29, 18, 47, 15, 0, DateTimeKind.Unspecified), "For the first time, the Giver Quartet, four critically acclaimed modern classics, in one paperback boxed set. From two-time Newbery Medal winner and New York Times bestselling author Lois Lowry.\n\nFollow Jonas on his journey to discover the dark implications of his seemingly ideal community; witness Kira’s fight for survival and pursuit of an unmatched talent in a society blinded by prejudice; join Matty’s desperate mission to save Village and the practice of openness and honesty fostered there; and complete the story with Claire’s utter devotion to a child that was stolen from her, no matter what it takes to find him again.", null, null, "26c83209-99bd-4c77-845b-d192fac33446.webp", null, null, 2300.00m, null, "Middle Grade Fiction", "The Giver Quartet Box Set", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 136,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Masashi Kishimoto", "Graphic Novels & Comics", new DateTime(2024, 9, 29, 18, 50, 34, 0, DateTimeKind.Unspecified), "Naruto is a young shinobi with an incorrigible knack for mischief. He’s got a wild sense of humor, but Naruto is completely serious about his mission to be the world’s greatest ninja!\n\nNaruto and his team engage in an intense battle with the Akatsuki organization as both sides seek the power to determine the future of their land. Internecine fighting weakens the Akatsuki, but will their dark forces sideline Naruto?!", null, null, "b6f9c49c-0e9b-4bce-af5c-d649d1245472.webp", null, null, 560.00m, null, "Manga", "Naruto, Vol. 54", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 137,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Eiichiro Oda", "Graphic Novels & Comics", new DateTime(2024, 9, 29, 18, 51, 21, 0, DateTimeKind.Unspecified), "Join Monkey D. Luffy and his swashbuckling crew in their search for the ultimate treasure, One Piece! As a child, Monkey D. Luffy dreamed of becoming King of the Pirates. But his life changed when he accidentally gained the power to stretch like rubber...at the cost of never being able to swim again!\n\nYears later, Luffy sets off in search of the One Piece, said to be the greatest treasure in the world... As the battle of Onigashima heats up, Kaido's daughter Yamato actually wants to join Luffy's side. Meanwhile, Kaido reveals his grand plans and together with Big Mom, prepare to plunge the entire world in fear!", null, null, "278c534e-0654-4e8a-bcda-0ed87bc61b2f.webp", null, null, 680.00m, null, "Manga", "One Piece, Vol. 98", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 138,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Hajime Isayama", "Graphic Novels & Comics", new DateTime(2024, 9, 29, 18, 52, 4, 0, DateTimeKind.Unspecified), "HUMANITY PUSHES BACK!\n\nThe Survey Corps develop a risky gambit—have Eren in Titan form attempt to repair Wall Rose, reclaiming human territory from the monsters for the first time in a century. But Titan-Eren’s self-control is far from perfect, and when he goes on a rampage, not even Armin can stop him! With the survival of humanity on his massive shoulders, will Eren be able to return to his senses, or will he lose himself forever?", null, null, "84420467-d643-494e-be09-66e4078a7a31.webp", null, null, 600.00m, null, "Manga", "Attack on Titan, Vol. 4", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 139,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Tsugumi Ohba", "Graphic Novels & Comics", new DateTime(2024, 9, 29, 18, 52, 47, 0, DateTimeKind.Unspecified), "Light Yagami is an ace student with great prospects--and he's bored out of his mind. But all that changes when he finds the Death Note, a notebook dropped by a rogue Shinigami death god. Any human whose name is written in the notebook dies, and now Light has vowed to use the power of the Death Note to rid the world of evil. But when criminals begin dropping dead, the authorities send the legendary detective L to track down the killer. With L hot on his heels, will Light lose sight of his noble goal...or his life?\n\nAlthough they've collected plenty of evidence tying the seven Yotsuba members to the newest Kira, Light, L and the rest of the task force are no closer to discovering which one actually possesses the Death Note. Desperate for some headway, L recruits Misa to infiltrate the group and feed them information calculated to bring Kira into the open. But the Shinigami Rem reveals to Misa who the Kiras really are, and, armed with this knowledge, Misa will do anything to help Light. But what will that mean for L...?", null, null, "6198e70d-74a7-4b1e-9bbf-160323235b6b.webp", null, null, 570.00m, null, "Manga", "Death Note, Vol. 6", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 140,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Kohei Horikoshi", "Graphic Novels & Comics", new DateTime(2024, 9, 29, 18, 53, 45, 0, DateTimeKind.Unspecified), "What would the world be like if 80 percent of the population manifested superpowers called \"Quirks\"? Heroes and villains would be battling it out everywhere! Being a hero would mean learning to use your power, but where would you go to study? The Hero Academy of course! But what would you do if you were one of the 20 percent who were born Quirkless?\n\nThe final stages of the U.A. High sports festival promise to be explosive, as Uraraka takes on Bakugo in a head-to-head match! Bakugo never gives anyone a break, and the crowd holds its breath as the battle begins. The finals will push the students of Class 1-A to their limits and beyond!", null, null, "f5b77b03-fd1c-4910-be83-4e7ceb6d0c3e.webp", null, null, 560.00m, null, "Manga", "My Hero Academia, Vol. 5", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 141,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Alan Moore", "Graphic Novels & Comics", new DateTime(2024, 9, 29, 19, 3, 21, 0, DateTimeKind.Unspecified), "Batman: The Killing Joke is Alan Moore's unforgettable meditation on the razor-thin line between sanity and insanity, heroism and villainy, comedy and tragedy.\n\nOne bad day is all it takes according to the grinning engine of madness and mayhem known as the Joker, that's all that separates the sane from the psychotic. Freed once again from the confines of Arkham Asylum, he's out to prove his deranged point. And he's going to use Gotham City's top cop, Commissioner Jim Gordon, and the Commissioner's brilliant and beautiful daughter Barbara to do it.", null, null, "b8d98594-008f-48f1-8108-248919bf2d30.webp", null, null, 1020.56m, null, "Superhero Comics", "Batman: The Killing Joke Deluxe, New Edition", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 142,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Alan Moore, Dave Gibbons (Illustrator)", "Graphic Novels & Comics", new DateTime(2024, 9, 29, 19, 4, 54, 0, DateTimeKind.Unspecified), "In an alternate world where the mere presence of American superheroes changed history, the US won the Vietnam War, Nixon is still president, and the cold war is in full effect!\n\nWatchmen begins as a murder-mystery, but soon unfolds into a planet-altering conspiracy. As the resolution comes to a head, the unlikely group of reunited heroes--Rorschach, Nite Owl, Silk Spectre, Dr. Manhattan and Ozymandias--have to test the limits of their convictions and ask themselves where the true line is between good and evil.\n\nIn the mid-eighties, Alan Moore and Dave Gibbons created Watchmen, changing the course of comics' history and essentially remaking how popular culture perceived the genre. Popularly cited as the point where comics came of age, Watchmen's sophisticated take on superheroes has been universally acclaimed for its psychological depth and realism.", null, null, "ee32f552-c5f3-4743-b179-7a161abe2556.webp", null, null, 2300.00m, null, "Superhero Comics", "Watchmen, Deluxe Edition", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 143,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Stock", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Chris Claremont, John Byrne", "Graphic Novels & Comics", new DateTime(2024, 9, 29, 19, 5, 50, 0, DateTimeKind.Unspecified), "The X-Men have fought many battles, been on galaxy-spanning adventures and defeated enemies of limitless might ― but none of it prepared them for the most shocking struggle they would ever face. One of their own, Jean Grey, has gained cosmic power beyond all comprehension ― and that power has corrupted her absolutely! Now, the X-Men must decide whether the life of the friend they cherish is worth the possible destruction of the entire universe!\n\nThis touching tale of ultimate power and the triumph of the human spirit has been a cornerstone of the X-Men mythos for decades. Relive the saga that changed everything!", null, null, "7e8a29ef-c94b-47d9-b134-f2f28d451539.webp", null, null, 1685.00m, null, 99, "Superhero Comics", "X-Men: Dark Phoenix Saga", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 144,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Stan Lee", "Graphic Novels & Comics", new DateTime(2024, 9, 29, 19, 6, 34, 0, DateTimeKind.Unspecified), "The Penguin Classics Marvel Collection presents the origin stories, seminal tales, and characters of the Marvel Universe to explore Marvel's transformative and timeless influence on an entire genre of fantasy. A Penguin Classics Marvel Collection Edition Collects Spider-Man!” from Amazing Fantasy #15 (1962); The Amazing Spider-Man #1-4, #9, #10, #13, #14, #17-19 (1963-1964); Goodbye to Linda Brown” from Strange Tales #97 (1962); How Stan Lee and Steve Ditko Create Spider-Man!” from The Amazing Spider-Man Annual #1 (1964).\n\nIt is impossible to imagine American popular culture without Marvel Comics. For decades, Marvel has published groundbreaking visual narratives that sustain attention on multiple levels: as metaphors for the experience of difference and otherness; as meditations on the fluid nature of identity; and as high-water marks in the artistic tradition of American cartooning, to name a few. This anthology contains twelve key stories from the first two years of Spider-Man's publication history (from 1962 to 1964).", null, null, "7045bac4-8073-44c4-9264-1ba144637aa7.webp", null, null, 1575.00m, null, "Superhero Comics", "The Amazing Spider-Man, Penguin Classics Marvel Collection", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 145,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Stock", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Brian K. Vaughan", "Graphic Novels & Comics", new DateTime(2024, 9, 29, 19, 8, 1, 0, DateTimeKind.Unspecified), "BRIAN K. VAUGHAN and FIONA STAPLES have been hard at work on the second half of Hazels epic journey. Exciting news is coming, and anyone looking for a cool new way to catch up on the Eisner Award-winning series can look no further than this gorgeous box set, collecting all nine of the bestselling trade paperback collections in one affordable package. This is the perfect way for any mature readers” who havent yet tried SAGA to dip their toes into this weirdly wonderful universe. Collects SAGA VOL. 1-9 trade paperback with a set of 6 x 9 cover prints exclusive to the box set!", null, null, "95d68321-bd28-4411-b67b-c507f989e7c9.webp", null, null, 7500.00m, null, 20, "Independent Comics", "Saga Boxed Set: Vol. 1-9", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 146,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Marjane Satrapi", "Graphic Novels & Comics", new DateTime(2024, 9, 29, 19, 8, 52, 0, DateTimeKind.Unspecified), "In powerful black-and-white comic strip images, Satrapi tells the coming-of-age story of her life in Tehran from ages six to fourteen, years that saw the overthrow of the Shah’s regime, the triumph of the Islamic Revolution, and the devastating effects of war with Iraq. The intelligent and outspoken only child of committed Marxists and the great-granddaughter of one of Iran’s last emperors, Marjane bears witness to a childhood uniquely entwined with the history of her country.", null, null, "bbd46ca2-4329-4996-a56f-7e035fcd60c7.webp", null, null, 686.00m, null, "Independent Comics", "Persepolis: The Story of a Childhood", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 147,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Alison Bechdel", "Graphic Novels & Comics", new DateTime(2024, 9, 29, 19, 9, 42, 0, DateTimeKind.Unspecified), "Alison Bechdel’s groundbreaking, bestselling graphic memoir that charts her fraught relationship with her late father. Distant and exacting, Bruce Bechdel was an English teacher and director of the town funeral home, which Alison and her family referred to as the \"Fun Home.\" It was not until college that Alison, who had recently come out as a lesbian, discovered that her father was also gay. A few weeks after this revelation, he was dead, leaving a legacy of mystery for his daughter to resolve. In her hands, personal history becomes a work of amazing subtlety and power, written with controlled force and enlivened with humor, rich literary allusion, and heartbreaking detail.", null, null, "aa683c1e-1cb7-46ea-8bc6-7bfdd275ca2d.webp", null, null, 1085.00m, null, "Independent Comics", "Fun Home: A Family Tragicomic", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 148,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Rupi Kaur", "Poetry & Drama", new DateTime(2024, 9, 29, 19, 10, 50, 0, DateTimeKind.Unspecified), "From rupi kaur, the #1 New York Times bestselling author of milk and honey, comes her long-awaited second collection of poetry. A vibrant and transcendent journey about growth and healing. Ancestry and honoring one's roots. Expatriation and rising up to find a home within yourself. Divided into five chapters and illustrated by kaur, the sun and her flowers is a journey of wilting, falling, rooting, rising, and blooming. A celebration of love in all its forms. this is the recipe of life said my mother as she held me in her arms as i wept think of those flowers you plant in the garden each year they will teach you that people too must wilt fall root rise in order to bloom.", null, null, "9bda16c0-734e-4297-9997-4b1713e35e8f.webp", null, null, 700.00m, null, "Poetry Collections", "The Sun and Her Flowers", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 149,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Rupi Kaur", "Poetry & Drama", new DateTime(2024, 9, 29, 19, 11, 32, 0, DateTimeKind.Unspecified), "#1 New York Times bestseller milk and honey is a collection of poetry and prose about survival. About the experience of violence, abuse, love, loss, and femininity. The book is divided into four chapters, and each chapter serves a different purpose. Deals with a different pain. Heals a different heartache. milk and honey takes readers through a journey of the most bitter moments in life and finds sweetness in them because there is sweetness everywhere if you are just willing to look.", null, null, "3edf039b-df6b-4228-b7de-47a67cb2260d.webp", null, null, 845.00m, null, "Poetry Collections", "Milk and Honey", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 150,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Sylvia Plath", "Poetry & Drama", new DateTime(2024, 9, 29, 19, 12, 44, 0, DateTimeKind.Unspecified), "When Sylvia Plath died, she not only left behind a prolific life but also her unpublished literary masterpiece, Ariel. When her husband, Ted Hughes, first brought this collection to life, it garnered worldwide acclaim, though it wasn't the draft Sylvia had wanted her readers to see. This facsimile edition restores, for the first time, Plath's original manuscript - including handwritten notes - and her own selection and arrangement of poems. This edition also includes in facsimile the complete working drafts of her poem \"Ariel,\" which provide a rare glimpse into the creative process of a beloved writer. This publication introduces a truer version of Plath's works, and will no doubt alter her legacy forever. This P.S. edition features an extra 16 pages of insights into the book, including author interviews, recommended reading, and more.", null, null, "41308f5a-94bd-4cba-823f-80b22228d378.webp", null, null, 1073.00m, null, "Poetry Collections", "Ariel: A Facsimile of Plath's Manuscript, Reinstating Her Original Selection and Arrangement, The Restored Edition", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 151,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "William Shakespeare", "Poetry & Drama", new DateTime(2024, 9, 29, 19, 13, 21, 0, DateTimeKind.Unspecified), "Considered one of Shakespeare’s most rich and enduring plays, the depiction of its hero Hamlet as he vows to avenge the murder of his father by his brother Claudius is both powerful and complex. As Hamlet tries to find out the truth of the situation, his troubled relationship with his mother comes to the fore, as do the paradoxes in his personality. A play of carefully crafted conflict and tragedy, Shakespeare’s intricate dialogue continues to fascinate audiences to this day.", null, null, "1bc3eebf-fff2-4afa-9ac0-d68b9d46d8eb.webp", null, null, 183.00m, null, "Plays & Screenplays", "Hamlet, Collins Classics", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 152,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Rebecca Skloot", "Science & Nature", new DateTime(2024, 9, 29, 19, 16, 0, 0, DateTimeKind.Unspecified), "Her name was Henrietta Lacks, but scientists know her as HeLa. She was a poor Southern tobacco farmer who worked the same land as her slave ancestors, yet her cells—taken without her knowledge—became one of the most important tools in medicine: The first “immortal” human cells grown in culture, which are still alive today, though she has been dead for more than sixty years. HeLa cells were vital for developing the polio vaccine; uncovered secrets of cancer, viruses, and the atom bomb’s effects; helped lead to important advances like in vitro fertilization, cloning, and gene mapping; and have been bought and sold by the billions. Yet Henrietta Lacks remains virtually unknown, buried in an unmarked grave.", null, null, "06a9d080-8986-449f-bb32-faa550759626.webp", null, null, 700.00m, null, "Biology", "The Immortal Life of Henrietta Lacks", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 153,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Yuval Noah Harari", "Science & Nature", new DateTime(2024, 9, 29, 19, 17, 8, 0, DateTimeKind.Unspecified), "From a renowned historian comes a groundbreaking narrative of humanity's creation and evolution--a #1 international bestseller--that explores the ways in which biology and history have defined us and enhanced our understanding of what it means to be \"human.\" One hundred thousand years ago, at least six different species of humans inhabited Earth. Yet today there is only one--homo sapiens. What happened to the others? And what may happen to us? Most books about the history of humanity pursue either a historical or a biological approach, but Dr. Yuval Noah Harari breaks the mold with this highly original book that begins about 70,000 years ago with the appearance of modern cognition. From examining the role evolving humans have played in the global ecosystem to charting the rise of empires, Sapiens integrates history and science to reconsider accepted narratives, connect past developments with contemporary concerns, and examine specific events within the context of larger ideas.", null, null, "071123e1-c964-469d-af46-29f6e390c18f.webp", null, null, 700.00m, null, "Biology", "Sapiens: A Brief History of Humankind", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 154,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Stephen Hawking", "Science & Nature", new DateTime(2024, 9, 29, 19, 18, 23, 0, DateTimeKind.Unspecified), "A landmark volume in science writing by one of the great minds of our time, Stephen Hawking's book explores such profound questions as: How did the universe begin--and what made its start possible? Does time always flow forward? Is the universe unending--or are there boundaries? Are there other dimensions in space? What will happen when it all ends? Told in language we all can understand, A Brief History of Time plunges into the exotic realms of black holes and quarks, of antimatter and \"arrows of time,\" of the big bang and a bigger God--where the possibilities are wondrous and unexpected. With exciting images and profound imagination, Stephen Hawking brings us closer to the ultimate secrets at the very heart of creation.", null, null, "e110da54-cbd3-4d27-b021-b77a552ceb25.webp", null, null, 999.00m, null, "Physics", "A Brief History of Time", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 155,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "DK", "Science & Nature", new DateTime(2024, 9, 29, 19, 20, 23, 0, DateTimeKind.Unspecified), "Are you short of time but hungry for knowledge? This beginner's quantum physics book proves that sometimes less is more. Bold graphics and easy-to-understand explanations make it the most accessible guide to quantum physics on the market. This smart but powerful guide cuts through the jargon and gives you the facts in a clear, visual way. Step inside the strange and fascinating world of subatomic physics that at times seems to conflict with common sense. Unlock the mysteries of more than 100 key ideas, from quantum mechanics basics to the uncertainty principle and quantum tunneling.", null, null, "0afd4b9c-5b8a-4b8e-bcf8-c57652e23e12.webp", null, null, 779.00m, null, "Physics", "Simply Quantum Physics", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 156,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "North Parade Publishing", "Science & Nature", new DateTime(2024, 9, 29, 19, 21, 9, 0, DateTimeKind.Unspecified), "The Wonders of Learning series helps your child to learn about the incredible world around them. With captivating illustrations and detailed analyses of key facts and fascinating information, these books are fun and fact-packed!", null, null, "dec8cf3d-4667-4dca-a28c-ae2fbc047f9e.webp", null, null, 280.00m, null, "Physics", "Wonders of Learning: Discover Physics", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 157,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Elizabeth Kolbert", "Science & Nature", new DateTime(2024, 9, 29, 19, 22, 51, 0, DateTimeKind.Unspecified), "In The Sixth Extinction, two-time winner of the National Magazine Award and New Yorker writer Elizabeth Kolbert draws on the work of scores of researchers in half a dozen disciplines, accompanying many of them into the field: geologists who study deep ocean cores, botanists who follow the tree line as it climbs up the Andes, marine biologists who dive off the Great Barrier Reef. She introduces us to a dozen species, some already gone, others facing extinction, including the Panamian golden frog, staghorn coral, the great auk, and the Sumatran rhino. Through these stories, Kolbert provides a moving account of the disappearances occurring all around us and traces the evolution of extinction as concept, from its first articulation by Georges Cuvier in revolutionary Paris up through the present day. In the ten years since the book was originally published, evidence of the Sixth Extinction has continued to mount, making its message more urgent than ever.", null, null, "0dd68ac0-a461-4969-95c0-94ad2b1fdac4.webp", null, null, 1120.00m, null, "Environmental Science", "The Sixth Extinction: An Unnatural History", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 158,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Naomi Klein", "Science & Nature", new DateTime(2024, 9, 29, 19, 23, 59, 0, DateTimeKind.Unspecified), "In This Changes Everything Naomi Klein argues that climate change isn't just another issue to be neatly filed between taxes and health care. It's an alarm that calls us to fix an economic system that is already failing us in many ways. Klein meticulously builds the case for how massively reducing our greenhouse emissions is our best chance to simultaneously reduce gaping inequalities, re-imagine our broken democracies, and rebuild our gutted local economies. She exposes the ideological desperation of the climate-change deniers, the messianic delusions of the would-be geoengineers, and the tragic defeatism of too many mainstream green initiatives. And she demonstrates precisely why the market has not--and cannot--fix the climate crisis but will instead make things worse, with ever more extreme and ecologically damaging extraction methods, accompanied by rampant disaster capitalism.", null, null, "b0d4afe9-f227-4f5d-9c8c-822f6409e8c0.webp", null, null, 1120.00m, null, "Environmental Science", "This Changes Everything: Capitalism vs. the Climate", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 159,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Carl Sagan", "Science & Nature", new DateTime(2024, 9, 29, 19, 24, 58, 0, DateTimeKind.Unspecified), "Cosmos is one of the bestselling science books of all time. In clear-eyed prose, Sagan reveals a jewel-like blue world inhabited by a life form that is just beginning to discover its own identity and to venture into the vast ocean of space. Featuring a new Introduction by Sagan’s collaborator, Ann Druyan, full color illustrations, and a new Foreword by astrophysicist Neil deGrasse Tyson, Cosmos retraces the fourteen billion years of cosmic evolution that have transformed matter into consciousness, exploring such topics as the origin of life, the human brain, Egyptian hieroglyphics, spacecraft missions, the death of the Sun, the evolution of galaxies, and the forces and individuals who helped to shape modern science.", null, null, "2d796ff2-a9da-4a90-8d3b-43928f7713ab.webp", null, null, 1063.00m, null, "Astronomy", "Cosmos", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 160,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Neil deGrasse Tyson", "Science & Nature", new DateTime(2024, 9, 29, 19, 25, 46, 0, DateTimeKind.Unspecified), "The #1 New York Times Bestseller: The essential universe, from our most celebrated and beloved astrophysicist. What is the nature of space and time? How do we fit within the universe? How does the universe fit within us? There's no better guide through these mind-expanding questions than acclaimed astrophysicist and best-selling author Neil deGrasse Tyson. But today, few of us have time to contemplate the cosmos. So Tyson brings the universe down to Earth succinctly and clearly, with sparkling wit, in tasty chapters consumable anytime and anywhere in your busy day. While you wait for your morning coffee to brew, for the bus, the train, or a plane to arrive, Astrophysics for People in a Hurry will reveal just what you need to be fluent and ready for the next cosmic headlines: from the Big Bang to black holes, from quarks to quantum mechanics, and from the search for planets to the search for life in the universe.", null, null, "93eb8ed4-b51a-4565-8dbb-0e4bd9dc2140.webp", null, null, 1270.00m, null, "Astronomy", "Astrophysics for People in a Hurry", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 161,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Year" },
                values: new object[] { "B. Greene", "Science & Nature", new DateTime(2024, 9, 29, 19, 26, 57, 0, DateTimeKind.Unspecified), "From Brian Greene, one of the world's leading physicists and author the Pulitzer Prize finalist 'The Elegant Universe,' comes a grand tour of the universe that makes us look at reality in a completely different way. Space and time form the very fabric of the cosmos. Yet they remain among the most mysterious of concepts. Is space an entity? Why does time have a direction? Could the universe exist without space and time? Can we travel to the past? Greene has set himself a daunting task: to explain non-intuitive, mathematical concepts like String Theory, the Heisenberg Uncertainty Principle, and Inflationary Cosmology with analogies drawn from common experience. From Newton's unchanging realm in which space and time are absolute, to Einstein's fluid conception of spacetime, to quantum mechanics' entangled arena where vastly distant objects can instantaneously coordinate their behavior, Greene takes us all, regardless of our scientific backgrounds, on an irresistible and revelatory journey to the new layers of reality that modern physics has discovered lying just beneath the surface of our everyday world.", null, null, "fb5b3c90-fc4f-4476-b3d2-48bb405d2374.webp", null, null, 1125.00m, null, "Astronomy", "Fabric of The Cosmos", null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 162,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "E.H. Gombrich", "Arts & Photography", new DateTime(2024, 9, 29, 19, 28, 14, 0, DateTimeKind.Unspecified), "The Story of Art has been a global bestseller for over half a century – the finest and most popular introduction ever written, published globally in more than 30 languages. Attracted by the simplicity and clarity of his writing, readers of all ages and backgrounds have found in Professor Gombrich a true master, who combines knowledge and wisdom with a unique gift for communicating his deep love of the subject.", null, null, "63a5b7b9-63d6-41ad-a309-1bda2005838e.webp", null, null, 1996.00m, null, "Art History", "The Story of Art", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 163,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "John Berger", "Arts & Photography", new DateTime(2024, 9, 29, 19, 29, 3, 0, DateTimeKind.Unspecified), "John Berger's seminal text on how to look at art. John Berger's Ways of Seeing is one of the most stimulating and the most influential books on art in any language. First published in 1972, it was based on the BBC television series about which the Sunday Times critic commented: 'This is an eye-opener in more ways than one: by concentrating on how we look at paintings . . . he will almost certainly change the way you look at pictures.' By now he has.", null, null, "ae384aa9-ba14-4043-b8f7-0e1057cd8c6d.webp", null, null, 955.00m, null, "Art History", "Ways of Seeing", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 164,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Martha Stewart", "Arts & Photography", new DateTime(2024, 9, 29, 19, 33, 17, 0, DateTimeKind.Unspecified), "Swirled and sprinkled, dipped and glazed, or otherwise fancifully decorated, cupcakes are the treats that make everyone smile. They are the star attraction for special days, such as birthdays, showers, and holidays, as well as perfect everyday goodies. In Martha Stewart’s Cupcakes, the editors of Martha Stewart Living share 175 ideas for simple to spectacular creations–with cakes, frostings, fillings, toppings, and embellishments that can be mixed and matched to produce just the right cupcake for any occasion.", null, null, "ed969f43-24c2-4949-9209-087952fe88c7.webp", null, null, 1042.00m, null, "Crafts & Hobbies", "Martha Stewart's Cupcakes: 175 Inspired Ideas for Everyone's Favorite Treat", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 165,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Jared Diamond", "History", new DateTime(2024, 9, 29, 19, 34, 10, 0, DateTimeKind.Unspecified), "Why did Eurasians conquer, displace, or decimate Native Americans, Australians, and Africans, instead of the reverse? In this 'artful, informative, and delightful' (William H. McNeill, New York Review of Books) book, a classic of our time, evolutionary biologist Jared Diamond dismantles racist theories of human history by revealing the environmental factors actually responsible for its broadest patterns.", null, null, "b50bc979-3828-47ae-be23-04dd2f089c77.webp", null, null, 1440.00m, null, "Ancient History", "Guns, Germs, and Steel: The Fates of Human Societies", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 166,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Herodotus", "History", new DateTime(2024, 9, 29, 19, 34, 59, 0, DateTimeKind.Unspecified), "In Tom Holland's vibrant translation, one of the great masterpieces of Western history springs to life. Herodotus of Halicarnassus--hailed by Cicero as the 'Father of History'--composed his histories around 440 BC. The earliest surviving work of nonfiction, The Histories works its way from the Trojan War through an epic account of the war between the Persian empire and the Greek city-states in the fifth century BC, recording landmark events that ensured the development of Western culture and still capture our modern imagination.", null, null, "79e71137-f332-4a24-a9b3-cba2efdf483c.webp", null, null, 1400.00m, null, "Ancient History", "The Histories, Penguin Classics Deluxe Edition-- Deckle Edge", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 167,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Anne Frank", "History", new DateTime(2024, 9, 29, 19, 36, 38, 0, DateTimeKind.Unspecified), "In a modern translation, this definitive edition contains entries about Anne’s burgeoning sexuality and confrontations with her mother that were cut from previous editions. Anne Frank’s The Diary of a Young Girl is among the most enduring documents of the twentieth century. Since its publication in 1947, it has been a beloved and deeply admired monument to the indestructible nature of the human spirit, read by millions of people and translated into more than fifty-five languages.", null, null, "109b10ec-5290-4185-86a1-4e8a008738d9.webp", null, null, 1830.00m, null, "Modern History", "The Diary of a Young Girl: The Definitive Edition", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 168,
                columns: new[] { "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Carl Von Clausewitz", "History", new DateTime(2024, 9, 29, 19, 38, 7, 0, DateTimeKind.Unspecified), "Writing at the time of Napoleon's greatest campaigns, Prussian soldier and writer Carl von Clausewitz created this landmark treatise on the art of warfare, which presented war as part of a coherent system of political thought. In line with Napoleon's own military actions, Clausewitz illustrated the need to annihilate the enemy and to make a strong display of one's power in an 'absolute war' without compromise.", null, null, "38cfda27-e474-4b60-af39-66d6b6f7028f.webp", null, null, 640.00m, null, "Military History", "On War, Penguin Classics", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 169,
                columns: new[] { "Author", "Category", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Sun Tzu", "History", "\"The Art of War\" is an ancient Chinese military treatise attributed to Sun Tzu, a military strategist and philosopher, dating back to the 5th century BC. The book is composed of 13 chapters, each addressing different aspects of warfare and military strategy. It emphasizes the importance of strategy, deception, and flexibility in combat and offers timeless insights that apply not only to military conflicts but also to various aspects of life, including business and leadership.", null, null, "0f8082b3-8146-4d1b-9bfe-afbd70da3e4f.webp", null, null, 340.00m, null, "Military History", "The Art of War", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 170,
                columns: new[] { "Author", "Category", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Catholic Bible Press", "Spirituality & Religion", "This Precious Moments Catholic Bible is the perfect choice for celebrating the special milestones in the life of your child. This beautiful gift can become a usable keepsake for Baptism or First Communion, and it can be the Bible your child carries to Mass. This contains the full Catholic canon, along with helps such as prayers, reading plans, and helpful verses. And the beautiful full-color Precious Moments artwork will invite your child into the pages of Scripture.", null, null, "f8775f8f-60a8-4257-818a-0076b12b0582.webp", null, null, 1120.00m, null, "World Religions", "NRSVCE Precious Moments Bible - Pink", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 171,
                columns: new[] { "Author", "Category", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "hich Nhat Hanh", "Spirituality & Religion", "The 20th anniversary edition of the classic text, updated, revised, and featuring a Mindful Living Journal. Buddha and Christ, perhaps the two most pivotal figures in the history of humankind, each left behind a legacy of teachings and practices that have shaped the lives of billions of people over two millennia. If they were to meet on the road today, what would each think of the other's spiritual views and practices?", null, null, "fb471cbb-c7dd-4116-a952-af88c87af98e.webp", null, null, 1000.00m, null, "World Religions", "Living Buddha, Living Christ: 20th Anniversary Edition", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 172,
                columns: new[] { "Author", "Category", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Paulo Coelho", "Spirituality & Religion", "The Alchemist by Paulo Coelho continues to change the lives of its readers forever. With more than two million copies sold around the world, The Alchemist has established itself as a modern classic, universally admired. Paulo Coelho's masterpiece tells the magical story of Santiago, an Andalusian shepherd boy who yearns to travel in search of a worldly treasure as extravagant as any ever found. The story of the treasures Santiago finds along the way teaches us, as only a few stories can, about the essential wisdom of listening to our hearts, learning to read the omens strewn along life's path, and, above all, following our dreams.", null, null, "91891ef1-b04c-4fd8-afe9-b945ca4ebcae.webp", null, null, 1690.00m, null, "Spiritual Growth", "The Alchemist, Gift Edition", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 173,
                columns: new[] { "Author", "Category", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Viktor Frankl", "Spirituality & Religion", "We needed to stop asking about the meaning of life, and instead to think of ourselves as those who were being questioned by life-daily and hourly. Our answer must consist not in talk and meditation, but in right action and in right conduct. Life ultimately means taking the responsibility to find the right answer to its problems and to fulfill the tasks which it constantly sets for each individual. When Man's Search for Meaning was first published in 1959, it was hailed by Carl Rogers as 'one of the outstanding contributions to psychological thought in the last fifty years.' Now, more than forty years and 4 million copies later, this tribute to hope in the face of unimaginable loss has emerged as a true classic. Man's Search for Meaning--at once a memoir, a self-help book, and a psychology manual-is the story of psychiatrist Viktor Frankl's struggle for survival during his three years in Auschwitz and other Nazi concentration camps. Yet rather than 'a tale concerned with the great horrors,' Frankl focuses in on the 'hard fight for existence' waged by 'the great army of unknown and unrecorded.'", null, null, "12b2c75e-76ae-4796-ab31-54d6ac066fc9.webp", null, null, 535.00m, null, "Inspirational", "Man's Search for Meaning, Export Edition", null, null });

            migrationBuilder.UpdateData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 174,
                columns: new[] { "Author", "Category", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Subcategory", "Title", "Width", "Year" },
                values: new object[] { "Brené Brown", "Spirituality & Religion", "For over a decade, Brene Brown has found a special place in our hearts as a gifted mapmaker and a fellow traveler. She is both a social scientist and a kitchen-table friend whom you can always count on to tell the truth, make you laugh, and, on occasion, cry with you. And what's now become a movement all started with The Gifts of Imperfection, which has sold more than two million copies in thirty-five different languages across the globe. What transforms this book from words on a page to effective daily practices are the ten guideposts to wholehearted living. The guideposts not only help us understand the practices that will allow us to change our lives and families, they also walk us through the unattainable and sabotaging expectations that get in the way.", null, null, "fa3835fd-6184-49d7-9f06-9e58c8b1fadd.webp", null, null, 950.00m, null, "Inspirational", "The Gifts of Imperfection, 10th Anniversary Edition", null, null });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "BookId", "Author", "Category", "Date", "Description", "Height", "ISBN", "Image", "Length", "Pages", "Price", "Publisher", "Rating", "RatingCount", "Stock", "Subcategory", "Title", "Width", "Year" },
                values: new object[,]
                {
                    { 175, "Marie Kondo", "Lifestyle", new DateTime(2024, 9, 29, 19, 39, 6, 0, DateTimeKind.Unspecified), "Marie Kondo presents the fictional story of Chiaki, a young woman in Tokyo who struggles with a cluttered apartment, messy love life, and lack of direction. After receiving a complaint from her attractive next-door neighbor about the sad state of her balcony, Chiaki gets Kondo to take her on as a client. Through a series of entertaining and insightful lessons, Kondo helps Chiaki get her home--and life--in order. This insightful, illustrated case study is perfect for people looking for a fun introduction to the KonMari Method of tidying up, as well as tried-and-true fans of Marie Kondo eager for a new way to think about what sparks joy. Featuring illustrations by award-winning manga artist Yuko Uramoto, this book also makes a great read for manga and graphic novel lovers of all ages.", null, null, "1d7766d8-0632-442f-9918-2aa520f7b65c.webp", null, null, 850.25m, null, null, 0, 99, "Home & Garden", "The Life-Changing Manga of Tidying Up: A Magical Story", null, null },
                    { 176, "Vogue", "Lifestyle", new DateTime(2024, 9, 29, 19, 39, 6, 0, DateTimeKind.Unspecified), "Apo Whang-Od is the face of Vogue Philippines’ Beauty issue, which also highlights the female gaze with creative couple Kim Jones and Jericho Rosales, photographer-stylist Melissa Levy, and Joey Samson's new romantic collection.", null, null, "3dd993c9-dbb0-4cf5-ae9f-ab835e10f426.webp", null, null, 585.00m, null, null, 0, 99, "Fashion & Beauty", "Apo Whang-Od: Next of Skin: The Beauty Issue: Vogue Philippines, April 2023", null, null },
                    { 177, "Collins Dictionaries", "Miscellaneous", new DateTime(2024, 9, 29, 19, 39, 6, 0, DateTimeKind.Unspecified), "The most up-to-date and information-packed dictionary of its size available. With spelling, grammar and pronunciation help, plus a practical writing guide, the Pocket Dictionary gives you all the everyday words you need – at your fingertips.\n\nUp-to-date language coverage along with practical guidance on effective English for everyday use.", null, null, "eb0ad0d8-cb6e-4723-bab2-c70bc2498de4.webp", null, null, 540.00m, null, null, 0, 99, "Reference Books", "Collins English Dictionary: Pocket edition", null, null },
                    { 178, "Douglas Adams", "Miscellaneous", new DateTime(2024, 9, 29, 19, 39, 6, 0, DateTimeKind.Unspecified), "Seconds before Earth is demolished to make way for a galactic freeway, Arthur Dent is plucked off the planet by his friend Ford Prefect, a researcher for the revised edition of The Hitchhiker’s Guide to the Galaxy who, for the last fifteen years, has been posing as an out-of-work actor.\n\nTogether, this dynamic pair began a journey through space aided by a galaxyful of fellow travelers: Zaphod Beeblebrox—the two-headed, three-armed ex-hippie and out-to-lunch president of the galaxy; Trillian (formerly Tricia McMillan), Zaphod’s girlfriend, whom Arthur tried to pick up at a cocktail party once upon a time zone; Marvin, a paranoid, brilliant, and chronically depressed robot; and Veet Voojagig, a graduate student obsessed with the disappearance of all the ballpoint pens he’s bought over the years.", null, null, "4a6119d2-acd4-4706-ba37-c3ba832c6884.webp", null, null, 499.00m, null, null, 0, 99, "Language Learning", "The Hitchhiker's Guide to the Galaxy", null, null }
                });
        }
    }
}
