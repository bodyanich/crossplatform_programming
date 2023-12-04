using System;
using System.Net.Http.Json;
using lab6_RESTful.Models;

namespace lab6_test
{
    public class ManufacturerControllerTests : IClassFixture<ApplicationFactory>
    {
        private readonly HttpClient _client;

        public ManufacturerControllerTests(ApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetManufacturerTest()
        {
            // Arrange
            var expectedJson = "[{\"manufacturer_code\":\"0000000001\",\"manufacturer_name\":\"Toyota\",\"manufacturer_details\":\"Japanese multinational automotive manufacturer known for reliable and fuel-efficient vehicles.\"},{\"manufacturer_code\":\"0000000002\",\"manufacturer_name\":\"Ford\",\"manufacturer_details\":\"American multinational automaker with a wide range of vehicles, including trucks and SUVs.\"},{\"manufacturer_code\":\"0000000003\",\"manufacturer_name\":\"BMW\",\"manufacturer_details\":\"German luxury automobile manufacturer with a focus on performance and elegance.\"},{\"manufacturer_code\":\"0000000004\",\"manufacturer_name\":\"Hyundai\",\"manufacturer_details\":\"South Korean automaker producing a diverse range of vehicles, including sedans and SUVs.\"},{\"manufacturer_code\":\"0000000005\",\"manufacturer_name\":\"Ferrari\",\"manufacturer_details\":\"Italian luxury sports car manufacturer synonymous with high-performance and exclusivity.\"}]";

            // Act
            var response = await _client.GetAsync("/api/Manufacturer");
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedJson, responseJson);
        }

        [Fact]
        public async Task GetManufacturerByCodeTest()
        {
            // Arrange
            var expectedJson = "[{\"manufacturer_code\":\"0000000001\",\"manufacturer_name\":\"Toyota\",\"manufacturer_details\":\"Japanese multinational automotive manufacturer known for reliable and fuel-efficient vehicles.\"}]";

            // Act
            var response = await _client.GetAsync("/api/Manufacturer/0000000001");
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedJson, responseJson);
        }
    }
}
