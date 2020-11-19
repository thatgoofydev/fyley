﻿// <auto-generated />
using System;
using Fyley.Components.Financial.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fyley.Components.Financial.Migrations.Migrations
{
    [DbContext(typeof(FinancialContext))]
    [Migration("20201113215839_Added_OccuredOnAndLoggedOnFieldsToTransactions")]
    partial class Added_OccuredOnAndLoggedOnFieldsToTransactions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Financial")
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

            modelBuilder.Entity("Fyley.Components.Financial.Domain.Transactions.TransactionState", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LoggedOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OccuredOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionalReference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Version")
                        .HasColumnType("bigint");

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Fyley.Components.Financial.Domain.Transactions.TransactionState", b =>
                {
                    b.OwnsOne("Fyley.Components.Financial.Domain.Shared.AccountNumber", "Payee", b1 =>
                        {
                            b1.Property<Guid>("TransactionStateTransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int?>("Type")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TransactionStateTransactionId");

                            b1.ToTable("Transactions");

                            b1.WithOwner()
                                .HasForeignKey("TransactionStateTransactionId");
                        });

                    b.OwnsOne("Fyley.Components.Financial.Domain.Shared.AccountNumber", "Payor", b1 =>
                        {
                            b1.Property<Guid>("TransactionStateTransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int?>("Type")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TransactionStateTransactionId");

                            b1.ToTable("Transactions");

                            b1.WithOwner()
                                .HasForeignKey("TransactionStateTransactionId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}