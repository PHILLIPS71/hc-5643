﻿// <auto-generated />
using System;
using HC_5643.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HC_5643.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230216104645_AddEntities")]
    partial class AddEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HC_5643.Persistence.Entities.FileSystemNode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("HC_5643.Persistence.Entities.FileSystemDirectory", b =>
                {
                    b.HasBaseType("HC_5643.Persistence.Entities.FileSystemNode");

                    b.HasIndex("Path")
                        .IsUnique();

                    b.ToTable("FileSystemDirectories");
                });

            modelBuilder.Entity("HC_5643.Persistence.Entities.FileSystemFile", b =>
                {
                    b.HasBaseType("HC_5643.Persistence.Entities.FileSystemNode");

                    b.Property<DateTime?>("ProbedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.HasIndex("Path")
                        .IsUnique();

                    b.ToTable("FileSystemFiles");
                });

            modelBuilder.Entity("HC_5643.Persistence.Entities.FileSystemNode", b =>
                {
                    b.HasOne("HC_5643.Persistence.Entities.FileSystemDirectory", "Parent")
                        .WithMany("Nodes")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("HC_5643.Persistence.Entities.FileSystemDirectory", b =>
                {
                    b.Navigation("Nodes");
                });
#pragma warning restore 612, 618
        }
    }
}