namespace MyTestableApi.Tests;

using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

public class UnitTest1
{
    /*
     * GIVEN : Le pays est "La France"
     * WHEN : Je demande le nombre de population
     * THEN : Je récupère le Int de population en Json
     */
    [Fact]
    public async Task IsGetCountryPopulationByIdIsOk()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("PopulationNumber/France");

        Assert.Equal("{\"idCountry\":\"France\",\"numberPop\":67000000,\"date\":2020}", await response.Content.ReadAsStringAsync());
    }

     /*
     * GIVEN : Le pays est "Le Listanbourg"
     * WHEN : Je demande le nombre de population
     * THEN : Retourne un Json vide
     */
    [Fact]
    public async Task IsGetCountryPopulationByIdIsNotOk()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("PopulationNumber/Listanbourg");

        Assert.Equal("{\"idCountry\":null,\"numberPop\":null,\"date\":null}", await response.Content.ReadAsStringAsync());
    }
}