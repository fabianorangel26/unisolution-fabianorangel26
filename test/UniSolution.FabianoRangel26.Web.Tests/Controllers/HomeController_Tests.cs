using System.Threading.Tasks;
using UniSolution.FabianoRangel26.Models.TokenAuth;
using UniSolution.FabianoRangel26.Web.Controllers;
using Shouldly;
using Xunit;

namespace UniSolution.FabianoRangel26.Web.Tests.Controllers
{
    public class HomeController_Tests: FabianoRangel26WebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}