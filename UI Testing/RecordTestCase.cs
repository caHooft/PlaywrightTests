using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace UITests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class RecordedTest
{
    [Test]
    public async Task NavigateToPlaywrightMakeATaskAndRemove()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();

        await page.GotoAsync("https://demo.playwright.dev/todomvc/");

        await page.GotoAsync("https://demo.playwright.dev/todomvc/#/");

        await page.GetByPlaceholder("What needs to be done?").ClickAsync();

        await page.GetByPlaceholder("What needs to be done?").FillAsync("I Need more values");

        await page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");

        await page.GetByPlaceholder("What needs to be done?").FillAsync("10");

        await page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");

        await page.GetByPlaceholder("What needs to be done?").FillAsync("12");

        await page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");

        await page.GetByPlaceholder("What needs to be done?").FillAsync("14");

        await page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");

        await page.GetByPlaceholder("What needs to be done?").FillAsync("16");

        await page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");

        await page.GetByPlaceholder("What needs to be done?").FillAsync("18");

        await page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");

        await page.Locator("li").Filter(new() { HasText = "10" }).GetByLabel("Toggle Todo").CheckAsync();

        await page.Locator("li").Filter(new() { HasText = "12" }).GetByLabel("Toggle Todo").CheckAsync();

        await page.Locator("li").Filter(new() { HasText = "14" }).GetByLabel("Toggle Todo").CheckAsync();

        await page.Locator("li").Filter(new() { HasText = "16" }).GetByLabel("Toggle Todo").CheckAsync();

        await page.Locator("li").Filter(new() { HasText = "18" }).GetByLabel("Toggle Todo").CheckAsync();

        await page.Locator("li").Filter(new() { HasText = "I Need more values" }).GetByLabel("Toggle Todo").CheckAsync();

        await page.GetByRole(AriaRole.Button, new() { Name = "Clear completed" }).ClickAsync();


    }
}
