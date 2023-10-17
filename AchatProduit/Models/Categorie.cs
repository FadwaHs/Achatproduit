using System.ComponentModel.DataAnnotations;

namespace AchatProduit.Models
{
    public class Categorie
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Produit>? Produits { get; set; }

    }
}
