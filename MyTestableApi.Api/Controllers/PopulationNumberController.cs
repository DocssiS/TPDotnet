using Microsoft.AspNetCore.Mvc;
using ChoETL;

namespace MyTestableApi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PopulationNumberController : ControllerBase
{
    private readonly ILogger<PopulationNumberController> _logger;

    public PopulationNumberController(ILogger<PopulationNumberController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}", Name = "GetPopulationNumberById")]
    public PopulationNumber GetCountry(string id)
    {
        using (var reader = new ChoCSVReader(AppDomain.CurrentDomain.BaseDirectory + "../../../DataBase.csv").WithFirstLineHeader().WithDelimiter(","))
        {
            foreach (var Country in reader)
            {
                if (Country.IdCountry == id){

                var result = new PopulationNumber{
                    IdCountry = Country.IdCountry,
                    NumberPop = Int32.Parse(Country.NumberPop),
                    Date = Int32.Parse(Country.Date)
                };
                return result;
                }
                } 
                return new PopulationNumber {};       
        }
    }
}
