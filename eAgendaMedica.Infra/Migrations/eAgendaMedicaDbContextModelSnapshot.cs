﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eAgendaMedica.Infra.Compartilhado;

#nullable disable

namespace eAgendaMedica.Infra.Migrations
{
    [DbContext(typeof(eAgendaMedicaDbContext))]
    partial class eAgendaMedicaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CirurgiaMedico", b =>
                {
                    b.Property<Guid>("CirurgiasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CirurgiasId", "MedicosId");

                    b.HasIndex("MedicosId");

                    b.ToTable("TBMedico_Cirurgia", (string)null);
                });

            modelBuilder.Entity("eAgendaMedica.Dominio.ModuloCirurgia.Cirurgia", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<long>("HoraInicio")
                        .HasColumnType("bigint");

                    b.Property<long>("HoraTermino")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Paciente_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Paciente_id");

                    b.ToTable("TBCirurgia", (string)null);
                });

            modelBuilder.Entity("eAgendaMedica.Dominio.ModuloConsulta.Consulta", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<long>("HoraInicio")
                        .HasColumnType("bigint");

                    b.Property<long>("HoraTermino")
                        .HasColumnType("bigint");

                    b.Property<Guid>("MedicoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Paciente_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("Paciente_id");

                    b.ToTable("TBConsulta", (string)null);
                });

            modelBuilder.Entity("eAgendaMedica.Dominio.ModuloMedico.Medico", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TBMedico", (string)null);
                });

            modelBuilder.Entity("eAgendaMedica.Dominio.ModuloPaciente.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TBPaciente", (string)null);
                });

            modelBuilder.Entity("CirurgiaMedico", b =>
                {
                    b.HasOne("eAgendaMedica.Dominio.ModuloCirurgia.Cirurgia", null)
                        .WithMany()
                        .HasForeignKey("CirurgiasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eAgendaMedica.Dominio.ModuloMedico.Medico", null)
                        .WithMany()
                        .HasForeignKey("MedicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eAgendaMedica.Dominio.ModuloCirurgia.Cirurgia", b =>
                {
                    b.HasOne("eAgendaMedica.Dominio.ModuloPaciente.Paciente", "PacienteAtributo")
                        .WithMany("Cirurgias")
                        .HasForeignKey("Paciente_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PacienteAtributo");
                });

            modelBuilder.Entity("eAgendaMedica.Dominio.ModuloConsulta.Consulta", b =>
                {
                    b.HasOne("eAgendaMedica.Dominio.ModuloMedico.Medico", "Medico")
                        .WithMany("Consultas")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("eAgendaMedica.Dominio.ModuloPaciente.Paciente", "PacienteAtributo")
                        .WithMany("Consultas")
                        .HasForeignKey("Paciente_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("PacienteAtributo");
                });

            modelBuilder.Entity("eAgendaMedica.Dominio.ModuloMedico.Medico", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("eAgendaMedica.Dominio.ModuloPaciente.Paciente", b =>
                {
                    b.Navigation("Cirurgias");

                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
