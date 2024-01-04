namespace OTT.Partnershop.Backend.PlaywrightTests.AvailabilityTests;

[TestFixture]
public class HealthCheckApiDigitalengine
{
    [Test]
    [TestCase("https://api.acc.kpn.org")]
    [Parallelizable(ParallelScope.All)]
    public async Task AvailabilityCheckWalledGarden(string baseUrl)
    {
        using IPlaywright playwright = await Playwright.CreateAsync();

        var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            BaseURL = baseUrl,
            IgnoreHTTPSErrors = true
        });

        var response = await requestContext.GetAsync(url: "/walled-garden/v2/health");
        var data = await response.TextAsync();
        
        //date is always in the correct respond format of walled garden
        data.Should().Contain("date");
    }
}