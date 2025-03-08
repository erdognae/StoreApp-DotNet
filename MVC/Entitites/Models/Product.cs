
namespace Entitites.Models;

// Bu bölüm veri tabanının modelini temsil eder: ProductID, ProductName ve ProductPrice gibi veritabanında sütunlar olacaktır. 
public class Product
{
    public int ProdcutId { get; set; }

    public String ProductName { get; set; } = String.Empty;

    public decimal ProductPrice { get; set; }

    public String? Summary {get;init;} = String.Empty;

    public String? ImageUrl {get; set;} 
    
    public int? CategoryId { get; set; }  // Foreign Key

    public Category? Category{ get; set; } // Navigation Property

}




