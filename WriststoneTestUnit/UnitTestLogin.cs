using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wriststone.Controllers;

namespace WriststoneTestUnit
{
    [TestClass]
    public class UnitTestLogin
    {
        [TestMethod]
        public void Test_Login()
        {
            ProfileController profile = new ProfileController();
            var result = profile.SignUp("fsninetwo", "CfrVfq<jkc1Nfqvc", null);
            Assert.AreEqual(result, "View");
        }
    }
}
