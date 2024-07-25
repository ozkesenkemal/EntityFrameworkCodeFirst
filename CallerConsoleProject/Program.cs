// See https://aka.ms/new-console-template for more information
using EntityFrameworkCodeFirst.DAL;

Console.WriteLine("Hello, World!");



DbContextInitializer.Build();
using (var _context = new AppDbContext())//(DbContextInitializer.OptionsBuilder.Options))// farklı db ler verebilmek için kullanım.
{
    var productList = _context.Product.ToList();

    foreach (var item in productList)
    {
        Console.WriteLine(item.Name + " " + item.Description+ " " + item.Price);
    }
}
