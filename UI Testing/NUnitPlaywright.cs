﻿using System.Text.RegularExpressions;
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

        Assert.That(isExist);

    }

    [Test]
    public async Task TestNetworkExpecting200()
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
        var responce = await page.RunAndWaitForResponseAsync(async () =>
        {
            await loginPage.clickEmplyeeList();
        }, x => x.Url.Contains("/Employee") && x.Status == 200);

        
        var isExist = await loginPage.IsEmployeeDetailsExists();

        //Assert.IsTrue(isExist); Example from tutorial that i replaced
        Assert.That(isExist);
    }   

}