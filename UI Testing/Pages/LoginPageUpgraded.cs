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

    //Act
    public async Task ClickLogin() => await _loginLink.ClickAsync();

    public async Task Login(string username, string password)
    {
        await _userName.FillAsync(username);
        await _password.FillAsync(password);
        await _buttonLogin.ClickAsync();
    }

    //Assert
    public async Task<bool> IsEmployeeDetailsExists() => await _LinkEmployeeDetails.IsVisibleAsync();

}