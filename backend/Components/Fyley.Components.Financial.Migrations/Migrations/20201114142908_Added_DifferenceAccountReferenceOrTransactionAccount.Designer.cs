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
    [Migration("20201114142908_Added_DifferenceAccountReferenceOrTransactionAccount")]
    partial class Added_DifferenceAccountReferenceOrTransactionAccount
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
                    b.OwnsOne("Fyley.Components.Financial.Domain.Transactions.AccountReferenceOrTransactionAccount", "Payee", b1 =>
                        {
                            b1.Property<Guid>("TransactionStateTransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("AccountReference")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TransactionStateTransactionId");

                            b1.ToTable("Transactions");

                            b1.WithOwner()
                                .HasForeignKey("TransactionStateTransactionId");

                            b1.OwnsOne("Fyley.Components.Financial.Domain.Transactions.TransactionAccount", "TransactionAccount", b2 =>
                                {
                                    b2.Property<Guid>("AccountReferenceOrTransactionAccountTransactionStateTransactionId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Name")
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("AccountReferenceOrTransactionAccountTransactionStateTransactionId");

                                    b2.ToTable("Transactions");

                                    b2.WithOwner()
                                        .HasForeignKey("AccountReferenceOrTransactionAccountTransactionStateTransactionId");

                                    b2.OwnsOne("Fyley.Components.Financial.Domain.Shared.AccountNumber", "Number", b3 =>
                                        {
                                            b3.Property<Guid>("TransactionAccountAccountReferenceOrTransactionAccountTransactionStateTransactionId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<int?>("Type")
                                                .HasColumnType("int");

                                            b3.Property<string>("Value")
                                                .HasColumnType("nvarchar(max)");

                                            b3.HasKey("TransactionAccountAccountReferenceOrTransactionAccountTransactionStateTransactionId");

                                            b3.ToTable("Transactions");

                                            b3.WithOwner()
                                                .HasForeignKey("TransactionAccountAccountReferenceOrTransactionAccountTransactionStateTransactionId");
                                        });
                                });
                        });

                    b.OwnsOne("Fyley.Components.Financial.Domain.Transactions.AccountReferenceOrTransactionAccount", "Payor", b1 =>
                        {
                            b1.Property<Guid>("TransactionStateTransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("AccountReference")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TransactionStateTransactionId");

                            b1.ToTable("Transactions");

                            b1.WithOwner()
                                .HasForeignKey("TransactionStateTransactionId");

                            b1.OwnsOne("Fyley.Components.Financial.Domain.Transactions.TransactionAccount", "TransactionAccount", b2 =>
                                {
                                    b2.Property<Guid>("AccountReferenceOrTransactionAccountTransactionStateTransactionId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Name")
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("AccountReferenceOrTransactionAccountTransactionStateTransactionId");

                                    b2.ToTable("Transactions");

                                    b2.WithOwner()
                                        .HasForeignKey("AccountReferenceOrTransactionAccountTransactionStateTransactionId");

                                    b2.OwnsOne("Fyley.Components.Financial.Domain.Shared.AccountNumber", "Number", b3 =>
                                        {
                                            b3.Property<Guid>("TransactionAccountAccountReferenceOrTransactionAccountTransactionStateTransactionId")
                                                .HasColumnType("uniqueidentifier");

                                            b3.Property<int?>("Type")
                                                .HasColumnType("int");

                                            b3.Property<string>("Value")
                                                .HasColumnType("nvarchar(max)");

                                            b3.HasKey("TransactionAccountAccountReferenceOrTransactionAccountTransactionStateTransactionId");

                                            b3.ToTable("Transactions");

                                            b3.WithOwner()
                                                .HasForeignKey("TransactionAccountAccountReferenceOrTransactionAccountTransactionStateTransactionId");
                                        });
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}