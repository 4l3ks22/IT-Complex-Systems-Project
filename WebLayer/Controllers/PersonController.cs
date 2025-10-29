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

    [HttpGet("{personId}", Name = nameof(GetPersonById))]
    public IActionResult GetPersonById(string personId)
    {
        var person = _personData.GetById(personId);
        if (person == null) return NotFound();

        var result = CreatePersonDto(person);
        return Ok(result);
    }

    private PersonDto CreatePersonDto(Person person)
    {
        var modeldto = _mapper.Map<PersonDto>(person);
        modeldto.Url = GetUrl(nameof(GetPersonById), new { personId = person.Nconst });
        
        return modeldto;
    }
}