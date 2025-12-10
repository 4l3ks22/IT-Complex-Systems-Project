/*using EntityFramework.DataServices;
using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using WebLayer.Dtos;

namespace WebLayer.Controllers;

public abstract class BaseController<TDataService> : ControllerBase
    where TDataService : class //  ControllerBase is the interface provided by Asp.net
                               // Setting up are own base controller to control pagging and link generation
{
    protected readonly TDataService _dataService;
    protected readonly LinkGenerator _generator;
    protected readonly IMapper _mapper;

    public BaseController(
        TDataService dataService,
        LinkGenerator generator,
        IMapper mapper)
    {
        _dataService = dataService; // these are the parameters of the base to be mapped in all Controllers
        _generator = generator;
        _mapper = mapper;
    }

    protected object CreatePaging<T>(string endpointName, IEnumerable<T> items, int numberOfItems,
        QueryParams queryParams)
    {

        var numberOfPages = (int)Math.Ceiling((double)numberOfItems / queryParams.PageSize); // makes sure to round up when more pages are needed

        var prev = queryParams.PageNumber > 1
            ? GetUrl(endpointName, new { PageNumber = queryParams.PageNumber - 1, queryParams.PageSize }) // checking if we have previous page then it generates url
            : null;

        var next = (numberOfPages > 0 && queryParams.PageNumber < numberOfPages)
            ? GetUrl(endpointName, new { PageNumber = queryParams.PageNumber + 1, queryParams.PageSize }) // checking if we have next page then it generates url
            : null;

        var first = numberOfPages > 1 ? GetUrl(endpointName, new { PageNumber = 1, queryParams.PageSize }) : null;
        var cur = GetUrl(endpointName, new { queryParams.PageNumber, queryParams.PageSize });
        var last = numberOfPages > 0 ? GetUrl(endpointName, new { PageNumber = numberOfPages, queryParams.PageSize }) : null;

        return new // return object to be returned in JSON response
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

    protected string GetUrl(string endpointName, object values) // Method to generate links
    {
        return _generator.GetUriByName(HttpContext, endpointName, values);
    }
}*/

//After update for matching requests with Id route values like t http://localhost:5000/api/genres/27/titles
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper;

namespace WebLayer.Controllers;

public abstract class BaseController<TDataService> : ControllerBase
    where TDataService : class
{
    protected readonly TDataService _dataService;
    protected readonly LinkGenerator _generator;
    protected readonly IMapper _mapper;

    public BaseController(
        TDataService dataService,
        LinkGenerator generator,
        IMapper mapper)
    {
        _dataService = dataService;
        _generator = generator;
        _mapper = mapper;
    }


    // UPDATED: Added "routeValues" (optional)
    protected object CreatePaging<T>(
        string endpointName,
        IEnumerable<T> items,
        int numberOfItems,
        QueryParams queryParams,
        object? routeValues = null)
    {
        var numberOfPages = (int)Math.Ceiling((double)numberOfItems / queryParams.PageSize);

        // Merge routeValues with paging parameters
        object Merge(object extra, int page)
        {
            var dict = new Dictionary<string, object>();

            if (extra != null)
            {
                foreach (var prop in extra.GetType().GetProperties())
                {
                    dict[prop.Name] = prop.GetValue(extra)!;
                }
            }

            dict["PageNumber"] = page;
            dict["PageSize"] = queryParams.PageSize;

            return dict;
        }

        var first = numberOfPages > 1
            ? GetUrl(endpointName, Merge(routeValues, 1))
            : null;

        var prev = queryParams.PageNumber > 1
            ? GetUrl(endpointName, Merge(routeValues, queryParams.PageNumber - 1))
            : null;

        var next = (numberOfPages > 0 && queryParams.PageNumber < numberOfPages)
            ? GetUrl(endpointName, Merge(routeValues, queryParams.PageNumber + 1))
            : null;

        var last = numberOfPages > 0
            ? GetUrl(endpointName, Merge(routeValues, numberOfPages))
            : null;

        var current = GetUrl(endpointName, Merge(routeValues, queryParams.PageNumber));


        return new
        {
            First = first,
            Prev = prev,
            Next = next,
            Last = last,
            Current = current,
            NumberOfPages = numberOfPages,
            NumberOfIems = numberOfItems,
            Items = items
        };
    }

    protected string GetUrl(string endpointName, object values)
    {
        return _generator.GetUriByName(HttpContext, endpointName, values);
    }
}


