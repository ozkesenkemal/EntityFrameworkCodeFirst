namespace EntityFrameworkCodeFirst.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> ProductTables { get; set; } = new List<Product>();
    }
}
