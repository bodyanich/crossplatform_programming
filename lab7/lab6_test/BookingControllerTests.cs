using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_test
{
    public class BookingControllerTests : IClassFixture<ApplicationFactory>
    {
        private readonly HttpClient _client;

        public BookingControllerTests(ApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetBookingByDateToTest()
        {
            // Arrange
            var expectedJson = "[{\"bookingId\":1,\"date_from\":\"2023-11-01T00:00:00\",\"date_to\":\"2023-11-05T00:00:00\",\"confirmation_letter_sent_yn\":\"Y\",\"payment_recived_yn\":\"N\",\"customerName\":\"John Doe\",\"customer_details\":\"Regular customer with a long history of renting vehicles.\",\"bookingStatusDescription\":\"Pending Approval\",\"regNumber\":\"ABC123\",\"currentMilleage\":50000,\"date_mot_due\":\"2023-12-31T00:00:00\",\"manufacturerName\":\"Toyota\",\"manufacturerDetails\":\"Japanese multinational automotive manufacturer known for reliable and fuel-efficient vehicles.\",\"daily_hire_rate\":50,\"model_name\":\"Camry\",\"vegicle_category_description\":\"Sedan\"}]";

            // Act
            var response = await _client.GetAsync("/api/Booking/date-to?date_to=2023-11-05");
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedJson, responseJson);
        }

        [Fact]
        public async Task GetBokingByDateSegmentTest()
        {
            // Arrange
            var expectedJson = "[{\"bookingId\":1,\"date_from\":\"2023-11-01T00:00:00\",\"date_to\":\"2023-11-05T00:00:00\",\"confirmation_letter_sent_yn\":\"Y\",\"payment_recived_yn\":\"N\",\"customerName\":\"John Doe\",\"customer_details\":\"Regular customer with a long history of renting vehicles.\",\"bookingStatusDescription\":\"Pending Approval\",\"regNumber\":\"ABC123\",\"currentMilleage\":50000,\"date_mot_due\":\"2023-12-31T00:00:00\",\"manufacturerName\":\"Toyota\",\"manufacturerDetails\":\"Japanese multinational automotive manufacturer known for reliable and fuel-efficient vehicles.\",\"daily_hire_rate\":50,\"model_name\":\"Camry\",\"vegicle_category_description\":\"Sedan\"}]";

            // Act
            var response = await _client.GetAsync("/api/Booking/date-from-segment?date_from_start=2023-10-01&date_from_end=2023-12-01");
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedJson, responseJson);
        }

        [Fact]
        public async Task GetBookingByQueryTest()
        {
            // Arrange
            var expectedJson = "[{\"bookingId\":4,\"date_from\":\"2024-02-15T00:00:00\",\"date_to\":\"2024-02-20T00:00:00\",\"confirmation_letter_sent_yn\":\"Y\",\"payment_recived_yn\":\"Y\",\"customerName\":\"Emily Davis\",\"customer_details\":\"City dweller looking for a compact and fuel-efficient vehicle.\",\"bookingStatusDescription\":\"Completed\",\"regNumber\":\"GHI789\",\"currentMilleage\":40000,\"date_mot_due\":\"2023-11-15T00:00:00\",\"manufacturerName\":\"Hyundai\",\"manufacturerDetails\":\"South Korean automaker producing a diverse range of vehicles, including sedans and SUVs.\",\"daily_hire_rate\":40,\"model_name\":\"Elantra\",\"vegicle_category_description\":\"Compact\"}]";

            // Act
            var response = await _client.GetAsync("/api/Booking/search?query=Emily%20Davis");
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedJson, responseJson);
        }
    }
}
