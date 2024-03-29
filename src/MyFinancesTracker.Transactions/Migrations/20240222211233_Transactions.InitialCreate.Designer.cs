﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFinancesTracker.Transactions.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyFinancesTracker.Transactions.Migrations
{
    [DbContext(typeof(TransactionDbContext))]
    [Migration("20240222211233_Transactions.InitialCreate")]
    partial class TransactionsInitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyFinancesTracker.Transactions.DbModel.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TransactionType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Transaction", "Transactions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Transaction");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MyFinancesTracker.Transactions.DbModel.BankTransaction", b =>
                {
                    b.HasBaseType("MyFinancesTracker.Transactions.DbModel.Transaction");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Receiver")
                        .HasColumnType("text");

                    b.Property<string>("Sender")
                        .HasColumnType("text");

                    b.ToTable("Transaction", "Transactions");

                    b.HasDiscriminator().HasValue("BankTransaction");
                });
#pragma warning restore 612, 618
        }
    }
}
