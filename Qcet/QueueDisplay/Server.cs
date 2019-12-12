using FundacjaBT.EventTool;
using System;
using System.ComponentModel;
using System.Net;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Qcet.QueueDisplay
{
    public class Server
    {
        private HttpListener listener;
        private BackgroundWorker worker;
        private Uri apiAddress;

        public Server(int port, ApiClient api)
        {
            apiAddress = api.Address;

            listener = new HttpListener();
            listener.Prefixes.Add($"http://*:{port}/");

            worker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            worker.DoWork += worker_DoWork;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            listener.Start();

            while (!worker.CancellationPending)
            {
                HttpListenerContext context = listener.GetContext();

                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                if (request.HttpMethod != "GET")
                {
                    response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                }
                else if (request.Headers.Get(ApiClient.TokenHeader) == null)
                {
                    response.StatusCode = (int)HttpStatusCode.Forbidden;
                }
                else
                {
                    ProcessRequestAsync(request, response);
                }
            }
            listener.Stop();
        }

        public void Start()
        {
            worker.RunWorkerAsync();
        }

        public void Stop()
        {
            worker.CancelAsync();
        }

        private async void ProcessRequestAsync(HttpListenerRequest request, HttpListenerResponse response)
        {
            Match match = Regex.Match(request.RawUrl, @"^/(?<code>[0-9a-fA-F]+)$");
            if (match.Success)
            {
                try
                {
                    ApiClient api = new ApiClient
                    {
                        Address = apiAddress,
                        Token = request.Headers.Get(ApiClient.TokenHeader)
                    };
                    OnReceived((await api.GetTicketsAsync(match.Groups["code"].Value))[0]);
                    response.StatusCode = (int)HttpStatusCode.OK;
                }
                catch (Exception)
                {
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
            }
        }

        protected virtual void OnReceived(Ticket ticket)
        {
            Received?.Invoke(this, ticket);
        }

        public event EventHandler<Ticket> Received;
    }
}
