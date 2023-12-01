using cross_lab5.Models.DTO;

namespace cross_lab5.Data
{
    public class RESTfulDataSource
    {
        private readonly HttpClient client = new()
        {
            BaseAddress = new System.Uri("http://localhost:5001")
        };

        public async Task<List<Manufacturer>> GetManufacturerAsync()
        {
            var response = await client.GetAsync("/api/Manufacturer");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Manufacturer>>();
        }

        public async Task<List<Manufacturer>> GetManufacturerAsync(string id)
        {
            var response = await client.GetAsync($"/api/Manufacturer/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Manufacturer>>();
        }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            var response = await client.GetAsync("/api/Customer");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Customer>>();
        }

        public async Task<List<Customer>> GetCustomerAsync(int id)
        {
            var response = await client.GetAsync($"/api/Customer/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Customer>>();
        }

        public async Task<List<Booking>> GetBookingAsync()
        {
            var response = await client.GetAsync("/api/Booking");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Booking>>();
        }

        public async Task<List<Booking>> GetBookingAsync(int id)
        {
            var response = await client.GetAsync($"/api/Booking/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Booking>>();
        }

        public async Task<List<Booking>> GetBookingDateToAsync(string date_to)
        {
            var response = await client.GetAsync($"/api/Booking/date-to?date_to={date_to}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Booking>>();
        }

        public async Task<List<Booking>> GetBookingDateFromSegmentAsync(string date_from_start, string date_from_end)
        {
            var response = await client.GetAsync($"/api/Booking/date-from-segment?date_from_start={date_from_start}&date_from_end={date_from_end}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Booking>>();
        }

        public async Task<List<Booking>> GetBookingByQueryAsync(string query)
        {
            var response = await client.GetAsync($"/api/Booking/search?query={query}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Booking>>();
        }
    }
}
