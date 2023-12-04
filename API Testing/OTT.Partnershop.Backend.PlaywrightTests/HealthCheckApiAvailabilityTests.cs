using Microsoft.Playwright;

namespace OTT.Partnershop.Backend.PlaywrightTests.AvailabilityTests;

public class HealthCheckApiAvailabilityTests
{
   [Theory]
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