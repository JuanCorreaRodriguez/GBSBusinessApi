namespace GlamBeautyApi.Dtos.Category;

public class CategoryMinDto
{
    public Guid CategoryId { get; set; }

    public required string CategoryName { get; set; }

    public string CategoryDesc { get; set; } = string.Empty;
}