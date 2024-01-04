using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
//using Xunit;

namespace OTT.Partnershop.Backend.PlaywrightTests.AvailabilityTests;

[TestFixture]
public class HealthCheckApiPartnershop
{
    [Test]
    [TestCase("https://partnershop-backend.dev.ott.kpn.org")]
    [TestCase("https://partnershop-backend.acc.ott.kpn.org")]
    [TestCase("https://partnershop-backend.ott.kpn.org")]
    [Parallelizable(ParallelScope.All)]
    public async Task AvailabilityCheckPartnershop(string baseUrl)
    {
        using IPlaywright playwright = await Playwright.CreateAsync();

        var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            BaseURL = baseUrl,
            IgnoreHTTPSErrors = true
        });

        var response = await requestContext.GetAsync(url: "/HealthCheck");
        var data = await response.TextAsync();

        data.Should().Be("Hello Partnershop!");
    }

}

/* This is the API check as Xunit
public class HealthCheckApiAvailabilityTests
{
   [Xunit.Theory]
   [InlineData("https://partnershop-backend.dev.ott.kpn.org")]
   [InlineData("https://partnershop-backend.acc.ott.kpn.org")]
   [InlineData("https://partnershop-backend.ott.kpn.org")]
    public async Task AvailabilityCheck(string baseUrl)
   {
      using IPlaywright playwright = await Playwright.CreateAsync();

      var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
      {
         BaseURL = baseUrl,
         IgnoreHTTPSErrors = true
      });

      var response = await requestContext.GetAsync(url: "/HealthCheck");
      var data = await response.TextAsync();

      data.Should().Be("Hello Partnershop!");
   }
}
*/