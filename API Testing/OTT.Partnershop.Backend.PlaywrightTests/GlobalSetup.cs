/*Some code made with Tim, based on OTT engine. Does not work outside OTT

using NUnit.Framework;
using OTT.Partnershop.Backend.PlaywrightTests.Authentication;

namespace OTT.Partnershop.Backend.PlaywrightTests;

[SetUpFixture]
public class GlobalSetup
{
   [OneTimeSetUp]
   public async Task OneTimeSetUp()
   {
      // Retrieve valid bearer token
      await AuthenticationHelper.GetTokenAsync();
   }

   [OneTimeTearDown]
   public void OneTimeTearDown()
   {
      // Clear bearer token
      TokenStoreHelper.Store.ClearToken();
   }
}
*/