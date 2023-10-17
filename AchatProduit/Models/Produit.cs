using AchatProduit.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchatProduit.Models
{
    public class Produit
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public String? Image { get; set; }
       
        public int CategoryID { get; set; }
        public virtual Categorie? Categorie { get; set; }
    }
}
