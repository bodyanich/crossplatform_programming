using lab6_RESTful;
using Microsoft.AspNetCore.Mvc.Testing;

namespace lab6_test
{
    public class ApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureClient(HttpClient client)
        {
            client.DefaultRequestHeaders.ConnectionClose = false;
        }
    }
}
