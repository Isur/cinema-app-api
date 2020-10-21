using Xunit;
using cinema_app_api.Helpers;
using cinema_app_api.Models;

namespace cinema_app_tests
{
    public class RoleTest
    {
        [Theory]
        [InlineData("Admin", Roles.ADMIN)]
        [InlineData("Worker", Roles.WORKER)]
        [InlineData("User", Roles.USER)]
        public void RoleToString(string expected, Roles input) {
            Assert.Equal(expected, RoleHelper.RoleToString(input));
        }
    }
}