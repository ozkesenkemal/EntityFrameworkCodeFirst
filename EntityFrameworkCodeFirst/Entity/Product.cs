using EntityFrameworkCodeFirst.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirst.Entity
{
    //[Table("CrdProduct", Schema = "public")]
    public class Product : IAuditable
    {
        //[ForeignKey("Product")]
        public int Id { get; set; }
        //[Column("ProductName")]
        public string Name { get; set; }
        public string Description { get; set; }
        //[Column("ProductPrice")]
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public string Barcode { get; set; }
        public int ProductNumber { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public Category Category { get; set; }
        public ProductExt ProductExt { get; set; } = new ProductExt();
    }
}