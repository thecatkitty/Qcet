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
    public class API
    {
        private readonly HttpClient client = new HttpClient(new HttpClientHandler()
        {
            AllowAutoRedirect = false
        });
        private string token;

        public Uri Address { get; set; } = new Uri("http://localhost/");

        public API()
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
            token = await response.Content.ReadAsStringAsync();
        }
    }
}
