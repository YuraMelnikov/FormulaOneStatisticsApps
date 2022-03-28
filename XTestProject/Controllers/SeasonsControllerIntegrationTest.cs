using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace XTestProject.Controllers
{
    public class SeasonsControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;

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
    }
}
