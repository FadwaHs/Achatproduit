using System.ComponentModel.DataAnnotations;

namespace AchatProduit.Models
{
    public class LignePanier
    {
        [Key]
        public int LignePanierID { get; set; }
       
        public int ProductID { get; set; }
        public Produit Product { get; set; }

        public int Quantity { get; set; }


        public System.DateTime DateCreated { get; set; }

    }
}
