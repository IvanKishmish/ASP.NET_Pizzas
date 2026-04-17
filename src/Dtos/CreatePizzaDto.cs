using System.ComponentModel.DataAnnotations;

namespace AspNet1.Dtos;

public record CreatePizzaDto(
    [Required][MaxLength(50)]string Name,
    [Required][MaxLength(200)]string Description,
    [Range(1, 1000)]decimal? Price);

