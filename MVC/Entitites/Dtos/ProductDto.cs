using System.ComponentModel.DataAnnotations;

namespace Entitites.Dtos
{
    public record ProductDto
    {
    public int ProdcutId { get; init; }

    [Required(ErrorMessage ="Bu alan boş olamaz!")]
    public String ProductName { get; init; } = String.Empty;

    [Required(ErrorMessage ="Bu alan boş olamaz!")]
    public decimal ProductPrice { get; init; }

    public int? CategoryId { get; init; }  // Foreign Key



    }


}
