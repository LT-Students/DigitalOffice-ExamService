using ExamService.Models.Db;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LT.DigitalOffice.ExamService.Data.Provider.MsSql.Ef.Migrations
{
  [DbContext(typeof(ExamServiceDbContext))]
  [Migration("20220608232300_InitialTables")]
  class InitialTables : Migration
  {
    protected override void Up(MigrationBuilder builder)
    {
      builder.CreateTable(
        name: DbAnswer.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          QuestionId = table.Column<Guid>(nullable: false),
          Option = table.Column<string>(nullable: false),
          IsCorrect = table.Column<bool>(nullable: false),
          CreatedBy = table.Column<Guid>(nullable: false),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          ModifiedBy = table.Column<Guid>(nullable: true),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table => table.PrimaryKey($"PK_{DbAnswer.TableName}", t => t.Id));

      builder.CreateTable(
        name: DbExam.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          ParentId = table.Column<Guid>(nullable: true),
          Name = table.Column<string>(nullable: false),
          Description = table.Column<string>(nullable: true),
          DeadLineUtc = table.Column<DateTime>(nullable: true),
          CreatedBy = table.Column<Guid>(nullable: false),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          ModifiedBy = table.Column<Guid>(nullable: true),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table => table.PrimaryKey($"PK_{DbExam.TableName}", t => t.Id));

      builder.CreateTable(
        name: DbQuestion.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          ExamId = table.Column<Guid>(nullable: false),
          Subject = table.Column<string>(nullable: false),
          Score = table.Column<int>(nullable: false),
          CreatedBy = table.Column<Guid>(nullable: false),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          ModifiedBy = table.Column<Guid>(nullable: true),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table => table.PrimaryKey($"PK_{DbQuestion.TableName}", t => t.Id));

      builder.CreateTable(
        name: DbUserAnswer.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          UserId = table.Column<Guid>(nullable: false),
          QuestionId = table.Column<Guid>(nullable: false),
          AnswerId = table.Column<Guid>(nullable: true),
          Custom = table.Column<string>(nullable: true),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table => table.PrimaryKey($"PK_{DbUserAnswer.TableName}", t => t.Id));
    }
  }
}
