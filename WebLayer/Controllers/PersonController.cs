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

    /*[HttpGet(Name = nameof(GetPersons))]
    public IActionResult GetPersons([FromQuery] QueryParams queryParams)
    {

        var persons = _personData
            .GetPersons(queryParams.PageNumber, queryParams.PageSize)
            .Select(x => CreatePersonDto(x));

        var numOfItems = _personData.GetPersonsCount();

        var result = CreatePaging(nameof(GetPersons), persons, numOfItems, queryParams);

        return Ok(result);
    }*/
    // replacing above action to use pagination
    [HttpGet(Name = nameof(GetPersons))]
    public IActionResult GetPersons([FromQuery] QueryParams queryParams)
    {

        var persons = _personData
            .GetPersons(queryParams)
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
    
    //Adding new controller to search titles by name to implement request
    
    [HttpGet("search", Name = nameof(SearchPersons))]
    public IActionResult SearchPersons(string name)
    {

        var persons = _personData.SearchPersonsByName(name);
        if (persons == null) return NotFound();

        // Map each person to PersonDto
        var result = persons.Select(p => CreatePersonDto(p));

        return Ok(result);
    }

    private PersonDto CreatePersonDto(Person person)
    {
        var modeldto = _mapper.Map<PersonDto>(person);
        //OJO added trim to get rid of %20 spaces and get a clean Nconst, useful to match searches in frontend
        modeldto.Url = GetUrl(nameof(GetPersonById), new { personId = person.Nconst.Trim() });
        foreach (var titleDto in modeldto.Titles)
        {
            //OJO added trim to get rid of %20 for spaces and get a clean Tconst, useful to match searches in frontend
            titleDto.Url = GetUrl(nameof(TitlesController.GetTitleById), new { id = titleDto.Tconst.Trim()});        }
        
        return modeldto;
    }
    
    
}