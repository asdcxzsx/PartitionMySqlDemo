//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//namespace ConsoleApp.Migrations
//{
//    public partial class InitialCreate : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "Blog",
//                columns: table => new
//                {
//                    Id = table.Column<Guid>(nullable: false),
//                    CreateTime = table.Column<DateTime>(nullable: false),
//                    Url = table.Column<string>(maxLength: 50, nullable: true),
//                    Rating = table.Column<uint>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Blog", x => new { x.Id, x.CreateTime });
//                    table.UniqueConstraint("AK_Blog_Id", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "Post",
//                columns: table => new
//                {
//                    Id = table.Column<Guid>(nullable: false),
//                    Title = table.Column<string>(maxLength: 50, nullable: true),
//                    Content = table.Column<string>(maxLength: 50, nullable: true),
//                    BlogId = table.Column<Guid>(nullable: false),
//                    CreateTime = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Post", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Post_Blog_BlogId",
//                        column: x => x.BlogId,
//                        principalTable: "Blog",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_Blog_CreateTime",
//                table: "Blog",
//                column: "CreateTime");

//            migrationBuilder.CreateIndex(
//                name: "IX_Post_BlogId",
//                table: "Post",
//                column: "BlogId");
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Post");

//            migrationBuilder.DropTable(
//                name: "Blog");
//        }
//    }
//}
