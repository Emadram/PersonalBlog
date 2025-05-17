using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBlog.Migrations
{
    /// <inheritdoc />
    public partial class SeedStaticDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedDate",
                value: new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishedDate",
                value: new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedDate",
                value: new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedDate",
                value: new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PodcastEpisodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PodcastEpisodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PodcastEpisodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedDate",
                value: new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2025, 5, 12, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2025, 5, 7, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedDate",
                value: new DateTime(2025, 5, 2, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishedDate",
                value: new DateTime(2025, 4, 27, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedDate",
                value: new DateTime(2025, 4, 19, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2025, 5, 15, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2025, 5, 12, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedDate",
                value: new DateTime(2025, 5, 9, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "PodcastEpisodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2025, 5, 10, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "PodcastEpisodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2025, 5, 3, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "PodcastEpisodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedDate",
                value: new DateTime(2025, 4, 26, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(6600));
        }
    }
}
