namespace ProductsManagement.Domain.Categories;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int ProductCount { get; set; }

    public Category()
    {
        
    }
    public Category(Guid id, string name)
    {
        Id = id;
        Name = name;
        ProductCount = 0; // Starts at 0 since there are no products initially
    }

    public void UpdateProductCount(int count)
    {
        ProductCount = count;
    }
    
    public void IncrementProductCount()
    {
        ProductCount++;
    }

    public void DecrementProductCount()
    {
        if (ProductCount > 0)
        {
            ProductCount--;
        }
    }
}