﻿using AchatProduit.Models;
using Microsoft.EntityFrameworkCore;

namespace AchatProduit.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Produit> Produits { get; set;}
        public DbSet<Categorie> Categories { get; set; }

        public DbSet<LignePanier> LignePaniers { get; set; }

        public DbSet<Panier> Paniers { get; set; }


    }
}
