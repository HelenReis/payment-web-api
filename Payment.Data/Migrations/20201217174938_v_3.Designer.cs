﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payment.Data;

namespace Payment.Data.Migrations
{
    [DbContext(typeof(PaymentContext))]
    [Migration("20201217174938_v_3")]
    partial class v_3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Payment.Domain.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Org")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("Payment.Domain.Models.BankAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("TypeAccount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("ClientId");

                    b.ToTable("BankAccount");
                });

            modelBuilder.Entity("Payment.Domain.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Payment.Domain.Models.FinancialPosting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("BankAccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Dtposted")
                        .HasColumnType("datetime");

                    b.Property<long>("Fitid")
                        .HasColumnType("bigint");

                    b.Property<string>("Memo")
                        .HasColumnType("text");

                    b.Property<double>("Trnamt")
                        .HasColumnType("double");

                    b.Property<int>("Trntype")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("FinancialPosting");
                });

            modelBuilder.Entity("Payment.Domain.Models.ImportedFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("BankAccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DtServer")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("ImportedFile");
                });

            modelBuilder.Entity("Payment.Domain.Models.BankAccount", b =>
                {
                    b.HasOne("Payment.Domain.Models.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Payment.Domain.Models.Client", "Client")
                        .WithMany("BankAccounts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Payment.Domain.Models.FinancialPosting", b =>
                {
                    b.HasOne("Payment.Domain.Models.BankAccount", "BankAccount")
                        .WithMany("FinancialPostings")
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Payment.Domain.Models.ImportedFile", b =>
                {
                    b.HasOne("Payment.Domain.Models.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
