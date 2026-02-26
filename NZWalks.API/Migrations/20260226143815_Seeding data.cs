using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0657e12b-df8c-4585-bc9b-3e73bd87641c"), "Medium" },
                    { new Guid("81c0af7a-71a0-4465-b3b8-f5c594d527e9"), "Hard" },
                    { new Guid("b709c0ce-14d1-4cfd-a395-939870baa4b7"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0ba74158-9b74-425d-aa08-6697129820d2"), "NSN", "Nelson", "https://picsum.photos/200/200" },
                    { new Guid("13f6df00-5176-4f16-84c6-16bb68a64732"), "BOP", "Bay of Plenty", "https://picsum.photos/200/200" },
                    { new Guid("39b78159-3b00-4605-bd72-37cdd5b40a1f"), "MBH", "Marlborough", "https://picsum.photos/200/200" },
                    { new Guid("4ce06d01-c392-46c7-b73e-9d677659cfa2"), "OTA", "Otago", "https://picsum.photos/200/200" },
                    { new Guid("4d864403-cd39-41ea-9de0-2722be1d2889"), "TKI", "Taranaki", "https://picsum.photos/200/200" },
                    { new Guid("65abc285-2e72-45ac-8aa7-1166b069ed34"), "CAN", "Canterbury", "https://picsum.photos/200/200" },
                    { new Guid("6e9663ef-18ec-4e35-afda-2402ee6475aa"), "WGN", "Wellington", "https://picsum.photos/200/200" },
                    { new Guid("7e57aa5e-0e80-4bb7-8b68-8c2717bc1ea7"), "MWT", "Manawatū-Whanganui", "https://picsum.photos/200/200" },
                    { new Guid("890db9d2-d136-44fc-9d8a-0cbfbdf837f5"), "NTL", "Northland", "https://picsum.photos/200/200" },
                    { new Guid("a826c3b6-73e3-42ec-953b-89d846390445"), "AKL", "Auckland", "https://picsum.photos/200/200" },
                    { new Guid("ba555ee1-d31b-4561-abb7-de08b74985ea"), "WTC", "West Coast", "https://picsum.photos/200/200" },
                    { new Guid("cf803131-4c4e-4611-aebc-2969786ca2fe"), "TSM", "Tasman", "https://picsum.photos/200/200" },
                    { new Guid("e5727df3-dd72-48ce-a1e3-43a8d0fb78d6"), "HKB", "Hawke's Bay", "https://picsum.photos/200/200" },
                    { new Guid("e7975595-fe45-4cd4-843b-fd955bbe5503"), "STL", "Southland", "https://picsum.photos/200/200" },
                    { new Guid("ebef9e55-bab4-4cb7-8830-c1163cc1fda1"), "GIS", "Gisborne", "https://picsum.photos/200/200" },
                    { new Guid("ed11cec3-239a-46ca-a3f7-d7ed254eb93e"), "WKO", "Waikato", "https://picsum.photos/200/200" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0657e12b-df8c-4585-bc9b-3e73bd87641c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("81c0af7a-71a0-4465-b3b8-f5c594d527e9"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b709c0ce-14d1-4cfd-a395-939870baa4b7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0ba74158-9b74-425d-aa08-6697129820d2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("13f6df00-5176-4f16-84c6-16bb68a64732"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("39b78159-3b00-4605-bd72-37cdd5b40a1f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4ce06d01-c392-46c7-b73e-9d677659cfa2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4d864403-cd39-41ea-9de0-2722be1d2889"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("65abc285-2e72-45ac-8aa7-1166b069ed34"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6e9663ef-18ec-4e35-afda-2402ee6475aa"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7e57aa5e-0e80-4bb7-8b68-8c2717bc1ea7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("890db9d2-d136-44fc-9d8a-0cbfbdf837f5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a826c3b6-73e3-42ec-953b-89d846390445"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ba555ee1-d31b-4561-abb7-de08b74985ea"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cf803131-4c4e-4611-aebc-2969786ca2fe"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e5727df3-dd72-48ce-a1e3-43a8d0fb78d6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e7975595-fe45-4cd4-843b-fd955bbe5503"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ebef9e55-bab4-4cb7-8830-c1163cc1fda1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ed11cec3-239a-46ca-a3f7-d7ed254eb93e"));
        }
    }
}
