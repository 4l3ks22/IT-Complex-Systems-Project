using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models;

public class QueryParams
{
    private const int MaxPageSize = 25;
    private int _pageNumber = 1;
    private int _pageSize = 10;

    [Range(1, int.MaxValue, ErrorMessage = "Page numbers start at 1")] // throws an error if page number is not at least 1
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value;
    }

    public int PageSize
    {
        get => _pageSize;
        set
        {
            var v = value < 1 ? 1 : value;            // make sure we have at least one item per page
            _pageSize = v > MaxPageSize ? MaxPageSize : v;
        }
    }
}