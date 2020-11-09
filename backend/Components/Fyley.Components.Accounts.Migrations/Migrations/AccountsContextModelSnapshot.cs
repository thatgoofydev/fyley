﻿// <auto-generated />
using System;
using Fyley.Components.Accounts.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fyley.Components.Accounts.Migrations.Migrations
{
    [DbContext(typeof(AccountsContext))]
    partial class AccountsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Accounts")
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DDDCore.Infrastructure.DataAccess.EventStore.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AggregateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("AggregateVersion")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Fyley.Components.Accounts.Domain.AccountState", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Version")
                        .HasColumnType("bigint");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Fyley.Components.Accounts.Domain.AccountState", b =>
                {
                    b.OwnsOne("Fyley.Components.Accounts.Domain.AccountNumber", "AccountNumber", b1 =>
                        {
                            b1.Property<Guid>("AccountStateAccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int?>("Type")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AccountStateAccountId");

                            b1.ToTable("Accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountStateAccountId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
