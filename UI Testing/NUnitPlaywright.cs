using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace UITests;

[Parallelizable(ParallelScope.Self)]

[TestFixture]
public class NUnitPlaywright
{
    [Test]
    public async Task LoginUsingValidCredentials()
    {
        using var playwright = await Playwright.CreateAsync();

        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false

        });

        var page = await browser.NewPageAsync();
        await page.GotoAsync(url: "http://www.eaapp.somee.com");

        LoginPageUp loginPage = new LoginPageUp(page);
        await loginPage.ClickLogin();
        await loginPage.Login(username:"admin", password:"password");
        var isExist = await loginPage.IsEmployeeDetailsExists();

        Assert.IsTrue(isExist);

    }

}