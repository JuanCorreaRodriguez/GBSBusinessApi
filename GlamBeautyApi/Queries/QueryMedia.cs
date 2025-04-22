namespace GlamBeautyApi.Queries;

public class QueryMedia
{
    public string? SortBy { get; set; }
    public int? PegeNumber { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
}