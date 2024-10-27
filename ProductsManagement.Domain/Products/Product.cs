namespace ProductsManagement.Domain.Products;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Price Price { get; set; }
    public Guid CategoryId { get; set; }

    public Product()
    {
        
    }
    public Product(Guid id, string name, Price price, Guid categoryId)
    {
        Id = id;
        Name = name;
        Price = price;
        CategoryId = categoryId;
    }
}