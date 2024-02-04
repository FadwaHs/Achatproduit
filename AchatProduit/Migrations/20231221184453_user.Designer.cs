﻿// <auto-generated />
using System;
using AchatProduit.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AchatProduit.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231221184453_user")]
    partial class user
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("AchatProduit.Models.Categorie", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AchatProduit.Models.LignePanier", b =>
                {
                    b.Property<int>("LignePanierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PanierID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("LignePanierID");

                    b.HasIndex("PanierID");

                    b.HasIndex("ProductID");

                    b.ToTable("LignePaniers");
                });

            modelBuilder.Entity("AchatProduit.Models.Panier", b =>
                {
                    b.Property<int>("PanierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("PanierID");

                    b.ToTable("Paniers");
                });

            modelBuilder.Entity("AchatProduit.Models.Produit", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategorieCategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductID");

                    b.HasIndex("CategorieCategoryID");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("AchatProduit.Models.LignePanier", b =>
                {
                    b.HasOne("AchatProduit.Models.Panier", null)
                        .WithMany("Items")
                        .HasForeignKey("PanierID");

                    b.HasOne("AchatProduit.Models.Produit", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AchatProduit.Models.Produit", b =>
                {
                    b.HasOne("AchatProduit.Models.Categorie", "Categorie")
                        .WithMany("Produits")
                        .HasForeignKey("CategorieCategoryID");

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("AchatProduit.Models.Categorie", b =>
                {
                    b.Navigation("Produits");
                });

            modelBuilder.Entity("AchatProduit.Models.Panier", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}