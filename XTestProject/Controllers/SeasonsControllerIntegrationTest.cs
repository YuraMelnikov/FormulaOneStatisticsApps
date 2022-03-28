using Moq;
using Services.DTO;
using Services.IEntityService;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace XTestProject.Controllers
{
    public class SeasonsControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly Mock<ISeasonsService> _profileServiceMock = new();

        public SeasonsControllerIntegrationTest(TestingWebAppFactory<Program> factory) =>
            _client = factory.CreateClient();

        [Theory]
        [InlineData("/api/seasons/")]
        public async Task CallReturnOk(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Theory]
        [InlineData("/api/seasons/")]
        public async Task CallReturnOk2(string url)
        {
            //var profile = new SeasonsDto
            //{
            //    Id = username,
            //    ImageLink = TestUtils.TestEmployerInfo,
            //    Name = TestUtils.TestPersonalInfo
            //};

            //_profileServiceMock.Setup(profileService => profileService.GetFullProfile(username))
            //    .ReturnsAsync(profile);

            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
