﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAgendaMedica.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TodasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBMedico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(50)", nullable: false),
                    Crm = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBMedico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBPaciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPaciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBCirurgia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Paciente_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<long>(type: "bigint", nullable: false),
                    HoraTermino = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCirurgia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCirurgia_TBPaciente_Paciente_id",
                        column: x => x.Paciente_id,
                        principalTable: "TBPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBConsulta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Paciente_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<long>(type: "bigint", nullable: false),
                    HoraTermino = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBConsulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBConsulta_TBMedico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "TBMedico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBConsulta_TBPaciente_Paciente_id",
                        column: x => x.Paciente_id,
                        principalTable: "TBPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBMedico_Cirurgia",
                columns: table => new
                {
                    CirurgiasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBMedico_Cirurgia", x => new { x.CirurgiasId, x.MedicosId });
                    table.ForeignKey(
                        name: "FK_TBMedico_Cirurgia_TBCirurgia_CirurgiasId",
                        column: x => x.CirurgiasId,
                        principalTable: "TBCirurgia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBMedico_Cirurgia_TBMedico_MedicosId",
                        column: x => x.MedicosId,
                        principalTable: "TBMedico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCirurgia_Paciente_id",
                table: "TBCirurgia",
                column: "Paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBConsulta_MedicoId",
                table: "TBConsulta",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBConsulta_Paciente_id",
                table: "TBConsulta",
                column: "Paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBMedico_Cirurgia_MedicosId",
                table: "TBMedico_Cirurgia",
                column: "MedicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBConsulta");

            migrationBuilder.DropTable(
                name: "TBMedico_Cirurgia");

            migrationBuilder.DropTable(
                name: "TBCirurgia");

            migrationBuilder.DropTable(
                name: "TBMedico");

            migrationBuilder.DropTable(
                name: "TBPaciente");
        }
    }
}
