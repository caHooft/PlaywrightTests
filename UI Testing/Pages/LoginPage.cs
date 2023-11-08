using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace UITests;

[Parallelizable(ParallelScope.Self)]

[TestFixture]
public class NUnitPlaywright : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync(url: "http://www.eaapp.somee.com");
    }

    [Test]
    public async Task LoginUsingValidCredentials()
    {
        await Page.ClickAsync(selector: "text=Login");
        await Page.FillAsync(selector: "#UserName", value: "admin");
        await Page.FillAsync(selector: "#Password", value: "password");
        await Page.ClickAsync(selector: "text=Log in");

        await Expect(Page.Locator(selector: "text='Employee Details'")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions
        {
            Timeout = 1
        });

/*        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "Hello Admin.jpg"
        });
*/
    }

}