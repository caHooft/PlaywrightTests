using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace APITests;

[Parallelizable(ParallelScope.Self)]

[TestFixture]
public class APIAvailabilityTest
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public async Task CheckIfAPIIsAvailable()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();

    }

}