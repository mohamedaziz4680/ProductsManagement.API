namespace ProductsManagement.Domain.Products;

public class Price
{
    public decimal Value { get; set; }
    public string Currency { get; set; }

    public Price()
    {
        
    }
    public Price(decimal value, string currency)
    {
        Value = value;
        Currency = currency;
    }
}