using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualBasic;
using NUnit.Framework;

//Use NUnit Assert over XUnit assert
using Assert = NUnit.Framework.Assert;

namespace OTT.Partnershop.Backend.PlaywrightTests.NUnitAPITest;

public class LoginPage
{
   //Arrange
   private readonly IPage _page;
   private readonly ILocator _LinkLogin;
   private readonly ILocator _UserName;
   private readonly ILocator _Password;
   private readonly ILocator _buttonLogin;
   private readonly ILocator _LinkEmployeeDetails;

   public LoginPage(IPage page)
   {
      _page = page;
      _LinkLogin = _page.Locator(selector: "text=Login");
      _UserName = _page.Locator(selector: "#UserName");
      _Password = _page.Locator(selector: "#Password");
      _buttonLogin = _page.Locator(selector: "text=Log in");
      _LinkEmployeeDetails = _page.Locator(selector: "text=Employee Details");

   }
   //Act
   public async Task ClickLogin() => await _LinkLogin.ClickAsync();

   public async Task Login(string username, string password)
   {
      await _UserName.FillAsync(username);
      await _Password.FillAsync(password);
      await _buttonLogin.ClickAsync();
   }

   //Assert
   public async Task<bool> IsEmployeeDetailsExists() => await _LinkEmployeeDetails.IsVisibleAsync();

}