using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InveonTodoList.Migrations
{
    public partial class AddCloumnCreatDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDateTime",
                table: "ToDoList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatDateTime",
                table: "ToDoList");
        }
    }
}
