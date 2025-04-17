namespace ProductClientHubAPI.Entities;

public class Product:EntityBase
{
    
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public Guid clientId { get; set; } 
}