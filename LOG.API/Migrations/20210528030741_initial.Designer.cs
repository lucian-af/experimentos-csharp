﻿// <auto-generated />
using System;
using LOG.API.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LOG.API.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210528030741_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LOG.API.Model.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("DadosJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DADOSJSON");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime")
                        .HasColumnName("DATAHORA");

                    b.HasKey("Id")
                        .HasName("PK_LOG");

                    b.ToTable("LOG");
                });
#pragma warning restore 612, 618
        }
    }
}
