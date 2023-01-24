﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Relacionamento_NxN.Models;

namespace Relacionamento_NxN.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Relacionamento_NxN.Models.Empregado", b =>
                {
                    b.Property<int>("EmpregadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF");

                    b.Property<int>("Idade");

                    b.Property<string>("Nome");

                    b.HasKey("EmpregadoId");

                    b.ToTable("Empregados");
                });

            modelBuilder.Entity("Relacionamento_NxN.Models.EmpregadoTrabalho", b =>
                {
                    b.Property<int>("EmpregadoId");

                    b.Property<int>("TrabalhoId");

                    b.Property<int>("CargaHoraria");

                    b.HasKey("EmpregadoId", "TrabalhoId");

                    b.HasIndex("TrabalhoId");

                    b.ToTable("EmpregadoTrabalhos");
                });

            modelBuilder.Entity("Relacionamento_NxN.Models.Trabalho", b =>
                {
                    b.Property<int>("TrabalhoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("TrabalhoId");

                    b.ToTable("Trabalhos");
                });

            modelBuilder.Entity("Relacionamento_NxN.Models.EmpregadoTrabalho", b =>
                {
                    b.HasOne("Relacionamento_NxN.Models.Empregado", "Empregado")
                        .WithMany("EmpregadoTrabalhos")
                        .HasForeignKey("EmpregadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Relacionamento_NxN.Models.Trabalho", "Trabalho")
                        .WithMany("EmpregadoTrabalhos")
                        .HasForeignKey("TrabalhoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
