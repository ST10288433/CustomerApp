namespace CustomerApp.Models;

public class CustomerListViewModel
{
    public IEnumerable<Customer> Customers { get; set; }
    public string? NameFilter { get; set; }
    public string? VATFilter { get; set; }
    public string SortColumn { get; set; } = "Name";
    public string SortDirection { get; set; } = "ASC";
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalCount { get; set; }
    public int TotalPages => (TotalCount + PageSize - 1) / PageSize;

    public string GetSortDirection(string column) =>
    SortColumn == column && SortDirection == "ASC" ? "DESC" : "ASC";
}