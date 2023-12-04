using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_test
{
    public class VehicleControllerTests : IClassFixture<ApplicationFactory>
    {
        private readonly HttpClient _client;

        public VehicleControllerTests(ApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetVehicleTest()
        {
            // Arrange
            var expectedJson = "[{\"regNumber\":\"ABC123\",\"currentMilleage\":50000,\"date_mot_due\":\"2023-12-31T00:00:00\",\"manufacturerName\":\"Toyota\",\"manufacturerDetails\":\"Japanese multinational automotive manufacturer known for reliable and fuel-efficient vehicles.\",\"daily_hire_rate\":50,\"model_name\":\"Camry\",\"vegicle_category_description\":\"Sedan\"},{\"regNumber\":\"XYZ789\",\"currentMilleage\":75000,\"date_mot_due\":\"2024-06-30T00:00:00\",\"manufacturerName\":\"Ford\",\"manufacturerDetails\":\"American multinational automaker with a wide range of vehicles, including trucks and SUVs.\",\"daily_hire_rate\":60,\"model_name\":\"F-150\",\"vegicle_category_description\":\"Truck\"},{\"regNumber\":\"DEF456\",\"currentMilleage\":60000,\"date_mot_due\":\"2024-03-15T00:00:00\",\"manufacturerName\":\"BMW\",\"manufacturerDetails\":\"German luxury automobile manufacturer with a focus on performance and elegance.\",\"daily_hire_rate\":80,\"model_name\":\"X5\",\"vegicle_category_description\":\"SUV\"},{\"regNumber\":\"GHI789\",\"currentMilleage\":40000,\"date_mot_due\":\"2023-11-15T00:00:00\",\"manufacturerName\":\"Hyundai\",\"manufacturerDetails\":\"South Korean automaker producing a diverse range of vehicles, including sedans and SUVs.\",\"daily_hire_rate\":40,\"model_name\":\"Elantra\",\"vegicle_category_description\":\"Compact\"},{\"regNumber\":\"JKL012\",\"currentMilleage\":20000,\"date_mot_due\":\"2024-09-01T00:00:00\",\"manufacturerName\":\"Ferrari\",\"manufacturerDetails\":\"Italian luxury sports car manufacturer synonymous with high-performance and exclusivity.\",\"daily_hire_rate\":300,\"model_name\":\"488 GTB\",\"vegicle_category_description\":\"Sports Car\"}]";

            // Act
            var response = await _client.GetAsync("/api/Vehicle");
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedJson, responseJson);
        }

        [Fact]
        public async Task GetVehicleByCodeTest()
        {
            // Arrange
            var expectedJson = "[{\"regNumber\":\"ABC123\",\"currentMilleage\":50000,\"date_mot_due\":\"2023-12-31T00:00:00\",\"manufacturerName\":\"Toyota\",\"manufacturerDetails\":\"Japanese multinational automotive manufacturer known for reliable and fuel-efficient vehicles.\",\"daily_hire_rate\":50,\"model_name\":\"Camry\",\"vegicle_category_description\":\"Sedan\"}]";

            // Act
            var response = await _client.GetAsync("/api/Vehicle/ABC123");
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedJson, responseJson);
        }
    }
}
