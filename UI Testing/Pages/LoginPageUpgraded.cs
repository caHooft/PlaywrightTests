using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace UITests;

public class LoginPageUp
{
    //Arrange
    private IPage _page;
    public LoginPageUp(IPage page) => _page = page;

    private ILocator _loginLink => _page.Locator(selector: "text=Login");
    private ILocator _userName => _page.Locator(selector: "#UserName");
    private ILocator _password => _page.Locator(selector: "#Password");
    private ILocator _buttonLogin => _page.Locator(selector: "text=Log in");
    private ILocator _LinkEmployeeDetails => _page.Locator(selector: "text=Employee Details");
    private ILocator _LinkEmployeeLists => _page.Locator(selector: "text=Employee List");

    //Act
    [Obsolete]
    public async Task ClickLogin()
    {
        //Deprecated call (RunAndWaitForNavigationAsync) but closest to the tutorial and its functional
        await _page.RunAndWaitForNavigationAsync(async () =>
        {
            await _loginLink.ClickAsync();
        }, new PageRunAndWaitForNavigationOptions
        {
            UrlString = "**/Login"
        });
    }

    public async Task Login(string username, string password)
    {
        await _userName.FillAsync(username);
        await _password.FillAsync(password);
        await _buttonLogin.ClickAsync();
    }
    public async Task clickEmplyeeList() => await _LinkEmployeeLists.ClickAsync();

    //Assert
    public async Task<bool> IsEmployeeDetailsExists() => await _LinkEmployeeDetails.IsVisibleAsync();

}