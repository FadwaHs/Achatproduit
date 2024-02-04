using AchatProduit.Migrations;
using System.ComponentModel.DataAnnotations;

namespace AchatProduit.Models
{
    public class Panier
    {

        [Key]
        public int PanierID { get; set; }
        public ICollection<LignePanier> Items { get; set;}


        public Panier()
        {
            Items = new List<LignePanier>();
        }

        // Method to add a product to the shopping cart
        public void AddToPanier(Produit product, int quantity)
        {
            // Check if the product is already in the cart
            var cartItem = Items.FirstOrDefault(l => l.ProductID == product.ProductID);

            if(cartItem == null)
            {
                // If the product is not in the cart, add a new line

                cartItem = new LignePanier
                {
                    ProductID = product.ProductID,
                    Product = product,
                    Quantity = quantity,
                    DateCreated = DateTime.Now
                };

                Items.Add(cartItem);
            }
            else
            {
                // If the product is already in the cart, update the quantity
                cartItem.Quantity = quantity;
            }
        }


        // Method to remove a product from the shopping cart
        public void RemoveFromPanier(int productId)
        {
            // Find the item with the given productId
            var cartItem = Items.FirstOrDefault(l => l.ProductID == productId);

            if (cartItem != null)
            {
                // Remove the item from the cart
                Items.Remove(cartItem);
            }
        }

        // Method to calculate the total price of items in the shopping cart
        public decimal TotalPrice => (decimal)Items.Sum(item => item.Product.Price * item.Quantity);

    }
}
