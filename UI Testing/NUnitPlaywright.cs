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

    [Test]
    public async Task TestNetwork()
    {
        using var playwright = await Playwright.CreateAsync();

        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false

        });
        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync(url: "http://www.eaapp.somee.com");

        LoginPageUp loginPage = new LoginPageUp(page);
        await loginPage.ClickLogin();
        await loginPage.Login(username: "admin", password: "password");
        await loginPage.clickEmplyeeList();

        //var example for checking API request
        //Cannot get this to run, left the code commented out over here
        //var waitResponce :Task < IRequest > = page.WaitForRequestAsync(urlOrPredicate "**/Employee");
        //wait loginPage.clickEmplyeeList();
        //var getResponce :IRequest = await waitResponce;

        //alternative after many tries (cannot say for sure if it is exactly the same)
        var responce = await page.RunAndWaitForResponseAsync(async () =>
        {
            await loginPage.clickEmplyeeList();
        }, x => x.Url.Contains("/Employee"));

        
        var isExist = await loginPage.IsEmployeeDetailsExists();

        Assert.IsTrue(isExist);

    }

}