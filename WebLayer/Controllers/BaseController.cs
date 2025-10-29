using EntityFramework.DataServices;
using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper;

namespace WebLayer.Controllers;

/*public class BaseController : ControllerBase
{
    protected readonly LinkGenerator _generator;
    protected readonly GenreData _genreData;

    public BaseController(LinkGenerator generator, GenreData genreData)
    {
        _generator = generator;
        _genreData = genreData;
    }
    protected object CreatePaging<T>(string endpointName, IEnumerable<T> items, int numberOfItems, QueryParams queryParams)
    {
        var numberOfPages = (int)Math.Ceiling((double)numberOfItems / queryParams.PageSize);

        var prev = queryParams.Page > 0
            ? GetUrl(endpointName, new { page = queryParams.Page - 1, queryParams.PageSize })
            : null;

        var next = queryParams.Page < numberOfPages - 1
            ? GetUrl(endpointName, new { page = queryParams.Page + 1, queryParams.PageSize })
            : null;

        var first = GetUrl(endpointName, new { page = 0, queryParams.PageSize });
        var cur = GetUrl(endpointName, new { queryParams.Page, queryParams.PageSize });
        var last = GetUrl(endpointName, new { page = numberOfPages - 1, queryParams.PageSize });

        return new
        {
            First = first,
            Prev = prev,
            Next = next,
            Last = last,
            Current = cur,
            NumberOfPages = numberOfPages,
            NumberOfIems = numberOfItems,
            Items = items
        };
    }
    protected string? GetUrl(string endpointName, object values)
    {
        return _generator.GetUriByName(HttpContext, endpointName, values);
    }
}*/


public abstract class BaseController<TDataService> : ControllerBase
    where TDataService : class //  ControllerBase is the interface provided by Asp.net 
{
    protected readonly TDataService _dataService;
    protected readonly LinkGenerator _generator;
    protected readonly IMapper _mapper;

    public BaseController(
        TDataService dataService,
        LinkGenerator generator,
        IMapper mapper)
    {
        _dataService = dataService; // these are the parameters of the base to be mapped in TitlesController
        _generator = generator;
        _mapper = mapper;
    }

    protected object CreatePaging<T>(string endpointName, IEnumerable<T> items, int numberOfItems,
        QueryParams queryParams)
    {
        var numberOfPages = (int)Math.Ceiling((double)numberOfItems / queryParams.PageSize);

        var prev = queryParams.Page > 0
            ? GetUrl(endpointName, new { page = queryParams.Page - 1, queryParams.PageSize })
            : null;

        var next = queryParams.Page < numberOfPages - 1
            ? GetUrl(endpointName, new { page = queryParams.Page + 1, queryParams.PageSize })
            : null;

        var first = GetUrl(endpointName, new { page = 0, queryParams.PageSize });
        var cur = GetUrl(endpointName, new { queryParams.Page, queryParams.PageSize });
        var last = GetUrl(endpointName, new { page = numberOfPages - 1, queryParams.PageSize });

        return new
        {
            First = first,
            Prev = prev,
            Next = next,
            Last = last,
            Current = cur,
            NumberOfPages = numberOfPages,
            NumberOfIems = numberOfItems,
            Items = items
        };
    }

    protected string? GetUrl(string endpointName, object values)
    {
        return _generator.GetUriByName(HttpContext, endpointName, values);
    }
}
