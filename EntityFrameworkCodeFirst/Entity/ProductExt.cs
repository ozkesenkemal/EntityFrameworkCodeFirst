using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirst.Entity
{
    public class ProductExt
    {
        [ForeignKey("Product")]
        public int Id { get; set; }
        public string Color { get; set; }
        public string Segment { get; set; }
        public Product Product { get; set; }
    }
}