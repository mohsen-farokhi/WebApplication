using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Infrastructures.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cms");

            migrationBuilder.CreateTable(
                name: "Cultures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    ActivatorUserId = table.Column<int>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RemoverUserId = table.Column<int>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    EditorUserId = table.Column<int>(nullable: true),
                    Lcid = table.Column<int>(nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    NativeName = table.Column<string>(maxLength: 50, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    ActivatorUserId = table.Column<int>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RemoverUserId = table.Column<int>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    EditorUserId = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    AccessType = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    IsVisibleJustForProgrammer = table.Column<bool>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operation_Operation_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    ActivatorUserId = table.Column<int>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RemoverUserId = table.Column<int>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    EditorUserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Url = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    ActivatorUserId = table.Column<int>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RemoverUserId = table.Column<int>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    EditorUserId = table.Column<int>(nullable: true),
                    EmailAddress = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    UserType = table.Column<byte>(nullable: false),
                    CellPhoneNumber = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    NationalCode = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Username = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    CultureLcid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    ActivatorUserId = table.Column<int>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RemoverUserId = table.Column<int>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    EditorUserId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationsOfGroups",
                columns: table => new
                {
                    OperationId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationsOfGroups", x => new { x.OperationId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_OperationsOfGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OperationsOfGroups_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersOfGroups",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersOfGroups", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UsersOfGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersOfGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    ActivatorUserId = table.Column<int>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RemoverUserId = table.Column<int>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    EditorUserId = table.Column<int>(nullable: true),
                    PostCategoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Author = table.Column<string>(maxLength: 100, nullable: true),
                    HasAttachment = table.Column<bool>(nullable: false),
                    Body = table.Column<string>(nullable: false),
                    IsDraft = table.Column<bool>(nullable: false),
                    IsCommentingEnabled = table.Column<bool>(nullable: false),
                    StartPublishingDateTime = table.Column<DateTime>(nullable: true),
                    FinishPublishingDateTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_PostCategories_PostCategoryId",
                        column: x => x.PostCategoryId,
                        principalSchema: "Cms",
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    ActivatorUserId = table.Column<int>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RemoverUserId = table.Column<int>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    EditorUserId = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false),
                    UserIP = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    UserFullName = table.Column<string>(maxLength: 100, nullable: false),
                    UserEmailAddress = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Subject = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComments_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "Cms",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagsOfPosts",
                schema: "Cms",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsOfPosts", x => new { x.TagId, x.PostId });
                    table.ForeignKey(
                        name: "FK_TagsOfPosts_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "Cms",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagsOfPosts_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cultures",
                columns: new[] { "Id", "ActivatorUserId", "DisplayName", "EditorUserId", "InsertDateTime", "IsActive", "IsDeleted", "IsSystem", "Lcid", "Name", "NativeName", "RemoverUserId", "UpdateDateTime" },
                values: new object[] { 1, null, "فارسی", null, new DateTime(2020, 8, 21, 18, 46, 26, 979, DateTimeKind.Local).AddTicks(4950), true, false, false, 1065, "fa-IR", "فارسی (ایران)", null, new DateTime(2020, 8, 21, 18, 46, 26, 982, DateTimeKind.Local).AddTicks(9500) });

            migrationBuilder.InsertData(
                table: "Cultures",
                columns: new[] { "Id", "ActivatorUserId", "DisplayName", "EditorUserId", "InsertDateTime", "IsActive", "IsDeleted", "IsSystem", "Lcid", "Name", "NativeName", "RemoverUserId", "UpdateDateTime" },
                values: new object[] { 2, null, "English", null, new DateTime(2020, 8, 21, 18, 46, 26, 983, DateTimeKind.Local).AddTicks(8203), true, false, false, 1033, "en-US", "English (United States)", null, new DateTime(2020, 8, 21, 18, 46, 26, 983, DateTimeKind.Local).AddTicks(8239) });

            migrationBuilder.CreateIndex(
                name: "IX_Operation_ParentId",
                table: "Operation",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationsOfGroups_GroupId",
                table: "OperationsOfGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Url",
                table: "Tags",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersOfGroups_GroupId",
                table: "UsersOfGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_PostId",
                schema: "Cms",
                table: "PostComments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostCategoryId",
                schema: "Cms",
                table: "Posts",
                column: "PostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Url",
                schema: "Cms",
                table: "Posts",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagsOfPosts_PostId",
                schema: "Cms",
                table: "TagsOfPosts",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cultures");

            migrationBuilder.DropTable(
                name: "OperationsOfGroups");

            migrationBuilder.DropTable(
                name: "UsersOfGroups");

            migrationBuilder.DropTable(
                name: "PostComments",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "TagsOfPosts",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Posts",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "PostCategories",
                schema: "Cms");
        }
    }
}
