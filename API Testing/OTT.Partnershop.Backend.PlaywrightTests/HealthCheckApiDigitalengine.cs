namespace OTT.Partnershop.Backend.PlaywrightTests.AvailabilityTests;

[TestFixture("https://api.acc.kpn.org")]
[Parallelizable(ParallelScope.All)]
public class HealthCheckApiDigitalengine
{
    private String baseUrl;

    public HealthCheckApiDigitalengine(string baseUrl)
    {
        this.baseUrl = baseUrl;
    }

    [Test]
    public async Task AvailabilityCheckWalledGarden()
    {
        using IPlaywright playwright = await Playwright.CreateAsync();

        var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            BaseURL = baseUrl,
            IgnoreHTTPSErrors = true
        });

        var response = await requestContext.GetAsync(url: "/walled-garden/v2/health");
        var data = await response.TextAsync();
        
        //"date" is always in the correct respond format of walled garden
        data.Should().Contain("date");
    }
}