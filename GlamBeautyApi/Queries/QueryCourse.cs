namespace GBSApi.Queries;

public class QueryCourse
{
    public string? Category { get; set; } = null;
    public decimal? Price { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
}