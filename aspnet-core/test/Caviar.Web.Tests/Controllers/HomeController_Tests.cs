using System.Threading.Tasks;
using Caviar.Models.TokenAuth;
using Caviar.Web.Controllers;
using Shouldly;
using Xunit;

namespace Caviar.Web.Tests.Controllers
{
    public class HomeController_Tests: CaviarWebTestBase
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