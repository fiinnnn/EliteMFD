using System;
using System.Net;
using System.Timers;
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

        private const double Timeout = 10000;

        private readonly Timer _timer;

        public EDSMConnector()
        {
            GetStatus();

            _timer = new Timer {Interval = Timeout};
            _timer.Elapsed += ConnectionTimeout;
        }

        /// <summary>
        /// Requests system coordinates from EDSM
        /// </summary>
        /// <param name="name">System name</param>
        /// <param name="callback">Function to call after recieving response</param>
        public void GetSysCoordinates(string name, Action<EDSMSystemInfo> callback)
        {
            var client = new RestClient(new Uri(SystemUrl));

            if (ConnectionStatus != Status.Success)
                GetStatus();

            if (ConnectionStatus != Status.Success)
                return;

            var request = new RestRequest(Method.POST);
            request.AddParameter("systemName", name);
            request.AddParameter("showCoordinates", 1);

            _timer.Start();
            client.ExecuteAsync<EDSMSystemInfo>(request, response =>
            {
                _timer.Stop();
                if (response.StatusCode == HttpStatusCode.OK)
                    callback(response.Data);
                else
                    ConnectionStatus = Status.Error;
            });
        }

        /// <summary>
        /// Check connection status
        /// </summary>
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

        /// <summary>
        /// Check status if timer elapses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="elapsedEventArgs"></param>
        private void ConnectionTimeout(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            _timer.Stop();
            GetStatus();
        }
    }
}
