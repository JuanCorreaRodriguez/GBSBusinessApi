using GBSApi.Dtos.Unions;

namespace GBSApi.Dtos.Category;

public class CategoryUpdateDto
{
    public string? CategoryName { get; set; }

    public string? CategoryDesc { get; set; } = string.Empty;

    public Guid? ParentId { get; set; } = Guid.Empty;

    public string? CategoryType { get; set; } = string.Empty;

    public List<Ids>? Media { get; set; } = [];
}