using EntityFramework.Interfaces;
using EntityFramework.Models;
using MapsterMapper;
using WebLayer.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Controllers;

[ApiController]
[Route("api/persons")]
public class PersonController : BaseController<IPersonData>
{
    protected IPersonData _personData => _dataService;

    public PersonController(
        IPersonData personData,
        LinkGenerator generator,
        IMapper mapper) : base(personData, generator, mapper)
    { }

    [HttpGet(Name = nameof(GetPersons))]
    public IActionResult GetPersons([FromQuery] QueryParams queryParams)
    {
        queryParams.PageSize = Math.Min(queryParams.PageSize, 3);

        var persons = _personData
            .GetPersons(queryParams.Page, queryParams.PageSize)
            .Select(x => CreatePersonDto(x));

        var numOfItems = _personData.GetPersonsCount();

        var result = CreatePaging(nameof(GetPersons), persons, numOfItems, queryParams);

        return Ok(result);
    }

    private PersonDto CreatePersonDto(Person person)
    {
        // Uses your global Mapster configuration automatically
        var modeldto = _mapper.Map<PersonDto>(person);
        return modeldto;
    }
}