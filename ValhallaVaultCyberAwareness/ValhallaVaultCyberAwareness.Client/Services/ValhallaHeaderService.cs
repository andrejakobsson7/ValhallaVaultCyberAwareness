using System.Net.Http.Headers;
using System.Text;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class ValhallaHeaderService
    {
        public void ConfigureHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.ASCII.GetBytes($"-1:ApplicationPassword")));
        }
    }
}
