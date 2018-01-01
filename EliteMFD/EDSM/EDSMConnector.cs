using System;
using System.Net;
using RestSharp;

namespace EliteMFD.EDSM
{
    class EDSMConnector
    {
        public enum Status
        {
            Success,
            Error
        }

        public Status ConnectionStatus { get; private set; }

        private const string StatusUrl = "https://www.edsm.net/api-status-v1/elite-server";
        private const string SystemUrl = "https://www.edsm.net/api-v1/system";

        public EDSMConnector()
        {
            GetStatus();
        }

        public void GetSysCoordinates(string name, Action<EDSMSystemInfo> callback)
        {
            var client = new RestClient(new Uri(SystemUrl));

            if (ConnectionStatus != Status.Success)
                GetStatus();

            if (ConnectionStatus != Status.Success)
                return;

            var request = new RestRequest(Method.GET);
            request.AddParameter("systemName", name);
            request.AddParameter("showCoordinates", 1);

            client.ExecuteAsync<EDSMSystemInfo>(request, response => { callback(response.Data); });
        }

        private void GetStatus()
        {
            var client = new RestClient(new Uri(StatusUrl));
            var request = new RestRequest(Method.GET);

            var response = client.Execute<EDSMStatus>(request);
            if (response.StatusCode == HttpStatusCode.OK)
                ConnectionStatus = response.Data.message == "OK" ? Status.Success : Status.Error;
            else
                ConnectionStatus = Status.Error;
        }
    }
}
