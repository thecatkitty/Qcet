using FundacjaBT.EventTool;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace Qcet.QueueDisplay
{
    public class Client
    {
        private readonly HttpClient client = new HttpClient();

        public Uri Address { get; set; } = new Uri("http://localhost/");

        public Client(ApiClient api)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", string.Format(
                "Qcet/{0}.{1}",
                Assembly.GetExecutingAssembly().GetName().Version.Major,
                Assembly.GetExecutingAssembly().GetName().Version.Minor
                ));

            client.DefaultRequestHeaders.Add(
                ApiClient.TokenHeader,
                api.Token);
        }

        public async Task<bool> Detect()
        {
            try
            {
                var response = await client.GetAsync(Address + "displayDetect");
                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            var response = await client.GetAsync(Address + ticket.Code);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }
    }
}
