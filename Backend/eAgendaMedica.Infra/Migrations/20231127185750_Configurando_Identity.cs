using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAgendaMedica.Infra.Migrations
{
    public partial class Configurando_Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCirurgia_AspNetUsers_UsuarioId",
                table: "TBCirurgia");

            migrationBuilder.DropForeignKey(
                name: "FK_TBConsulta_AspNetUsers_UsuarioId",
                table: "TBConsulta");

            migrationBuilder.DropForeignKey(
                name: "FK_TBMedico_AspNetUsers_UsuarioId",
                table: "TBMedico");

            migrationBuilder.DropForeignKey(
                name: "FK_TBPaciente_AspNetUsers_UsuarioId",
                table: "TBPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCirurgia_AspNetUsers_UsuarioId",
                table: "TBCirurgia",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBConsulta_AspNetUsers_UsuarioId",
                table: "TBConsulta",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBMedico_AspNetUsers_UsuarioId",
                table: "TBMedico",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPaciente_AspNetUsers_UsuarioId",
                table: "TBPaciente",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCirurgia_AspNetUsers_UsuarioId",
                table: "TBCirurgia");

            migrationBuilder.DropForeignKey(
                name: "FK_TBConsulta_AspNetUsers_UsuarioId",
                table: "TBConsulta");

            migrationBuilder.DropForeignKey(
                name: "FK_TBMedico_AspNetUsers_UsuarioId",
                table: "TBMedico");

            migrationBuilder.DropForeignKey(
                name: "FK_TBPaciente_AspNetUsers_UsuarioId",
                table: "TBPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCirurgia_AspNetUsers_UsuarioId",
                table: "TBCirurgia",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBConsulta_AspNetUsers_UsuarioId",
                table: "TBConsulta",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBMedico_AspNetUsers_UsuarioId",
                table: "TBMedico",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBPaciente_AspNetUsers_UsuarioId",
                table: "TBPaciente",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
