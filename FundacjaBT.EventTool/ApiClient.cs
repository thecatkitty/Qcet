using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace FundacjaBT.EventTool
{
    public class ApiClient
    {
        private readonly HttpClient client = new HttpClient(
            new HttpClientHandler()
        {
            AllowAutoRedirect = false
        });

        public Uri Address { get; set; } = new Uri("http://localhost/");

        public ApiClient()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", string.Format(
                "FundacjaBT.EventTool/{0}.{1}",
                Assembly.GetExecutingAssembly().GetName().Version.Major,
                Assembly.GetExecutingAssembly().GetName().Version.Minor
                ));
        }

        ~ApiClient()
        {
            Disconnect().Wait();
        }
        
        public async Task Connect(NetworkCredential credential)
        {
            if (credential.Domain != Address.DnsSafeHost)
            {
                throw new InvalidCredentialException("Invalid domain name");
            }
            
            var response = await client.PostAsync(
                Address + "token",
                new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "username", credential.UserName },
                    { "password", credential.Password }
                }));

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            client.DefaultRequestHeaders.Add(
                "X-AUTH-TOKEN",
                await response.Content.ReadAsStringAsync());
        }

        public async Task Disconnect()
        {
            var response = await client.GetAsync(Address + "api/logout");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            client.DefaultRequestHeaders.Remove("X-AUTH-TOKEN");
        }

        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            var serializer = new DataContractJsonSerializer(
                typeof(List<Ticket>));
            var response = await client.GetAsync(Address + "api/list");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return serializer.ReadObject(
                await response.Content.ReadAsStreamAsync()) as List<Ticket>;
        }

        public async Task<List<Ticket>> GetTicketsAsync(string phrase)
        {
            var serializer = new DataContractJsonSerializer(
                typeof(List<Ticket>));
            var response = await client.GetAsync(Address + $"api/list/{phrase}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return serializer.ReadObject(
                await response.Content.ReadAsStreamAsync()) as List<Ticket>;
        }

        public async Task ValidateTicketAsync(Ticket ticket)
        {
            var serializer = new DataContractJsonSerializer(
                typeof(List<Ticket>));
            var response = await client.GetAsync(Address + $"api/list/{ticket.Id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }
    }
}
