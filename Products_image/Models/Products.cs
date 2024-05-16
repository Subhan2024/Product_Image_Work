using System.ComponentModel.DataAnnotations.Schema;

namespace Products_image.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProdName { get; set; }
        public string ProdDesc { get; set; }
        public double ProdPrice { get; set; }
        [NotMapped]
        public IFormFile ProdImage { get; set; }

        public string ProdImagePath { get; set; }
    }
}
