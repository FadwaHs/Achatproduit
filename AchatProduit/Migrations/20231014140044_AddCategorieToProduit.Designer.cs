﻿// <auto-generated />
using AchatProduit.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AchatProduit.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231014140044_AddCategorieToProduit")]
    partial class AddCategorieToProduit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("AchatProduit.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("CategorieID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AchatProduit.Models.Produit", b =>
                {
                    b.Property<int>("ProduitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategorieID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("prix")
                        .HasColumnType("REAL");

                    b.HasKey("ProduitID");

                    b.HasIndex("CategorieID");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("AchatProduit.Models.Produit", b =>
                {
                    b.HasOne("AchatProduit.Models.Categorie", "Categorie")
                        .WithMany("Produits")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("AchatProduit.Models.Categorie", b =>
                {
                    b.Navigation("Produits");
                });
#pragma warning restore 612, 618
        }
    }
}
