﻿// <auto-generated />
using System;
using Fyley.Components.Dossiers.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fyley.Components.Dossiers.Infrastructure.Migrations
{
    [DbContext(typeof(DossiersContext))]
    partial class DossiersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fyley.Components.Dossiers.Domain.DossierState", b =>
                {
                    b.Property<Guid>("DossierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Version")
                        .HasColumnType("bigint");

                    b.HasKey("DossierId");

                    b.ToTable("Dossiers","Dossiers");
                });
#pragma warning restore 612, 618
        }
    }
}
