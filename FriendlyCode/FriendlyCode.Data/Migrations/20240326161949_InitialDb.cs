using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FriendlyCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Properties = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTrainers",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrainerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTrainers", x => new { x.CategoryId, x.TrainerId });
                    table.ForeignKey(
                        name: "FK_CategoryTrainers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTrainers_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDelete", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(6170), "Birebir kategori", true, false, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(6184), "Birebir", "birebir" },
                    { 2, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(6186), "Grup kategorisi", true, false, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(6186), "Grup", "grup" }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "CreatedDate", "ImageUrl", "IsActive", "IsDelete", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7517), "1.png", true, false, true, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7519), "Engin Niyazi Ergül", "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz", "Çıktığınız bu yolda yanlız olmadığınızı hissetiren bir kişi.", "engin-niyazi" },
                    { 2, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7522), "2.png", true, false, true, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7522), "Aylin Gezer", "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz", "Mantığınızla duygularınız arasında karar vermenize yardımcı olacak bir kişi.", "aylin" },
                    { 3, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7524), "3.png", true, false, true, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7525), "Mert Güneş", "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz", "İş seçiminde ve iş hayatınızda size yardımcı olacak bir kişi.", "mert" },
                    { 4, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7526), "4.png", true, false, false, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7527), "Asya Gümüş", "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz", "Aile hayatınızda çıkmazlara geldiğinizi hissettiğinizde yardımcı olacak bir kişi.", "asya" },
                    { 5, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7528), "5.png", true, false, true, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7529), "Erkan Kocakaya", "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz", "Sağlıklı şekilde spor ve hayat çizgisinde kalmanızı sağlayacak bir kişi.", "erkan" },
                    { 6, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7530), "6.png", true, false, true, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7531), "Merve Karadağlı", "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz", "Üniversiteye hazırlık döneminde ki gençlerimize sağlıklı yön verecek bir kişi.", "merve" },
                    { 7, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7532), "7.png", true, false, true, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7533), "Elif Buse Meriç", "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz", "Çift terapisti olarak sizi dinleyen ve çözüm bulacak bir kişi.", "elif-buse" },
                    { 8, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7534), "8.png", true, false, true, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7535), "Ahmet Toprak", "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz", "Felsefik ya da farklı açıdan kendi çıkmazlarınız da yanınızda olacak bir kişi.", "ahmet" },
                    { 9, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7536), "9.png", true, false, false, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7537), "Kemal Sevim", "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz", "Aile içe huzursuzluklarda ve anlaşmazlıklarda sizi yanlız bırakmayacak bir kişi.", "kemal" },
                    { 10, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7538), "10.png", true, false, true, new DateTime(2024, 3, 26, 19, 19, 49, 280, DateTimeKind.Local).AddTicks(7539), "Emine Hakyemez", "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz", "Evlatlarınızla daha iyi bir iletişim sağlamada size yardımcı olacak bir kişi.", "emine" }
                });

            migrationBuilder.InsertData(
                table: "CategoryTrainers",
                columns: new[] { "CategoryId", "TrainerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTrainers_TrainerId",
                table: "CategoryTrainers",
                column: "TrainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTrainers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
