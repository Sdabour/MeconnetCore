using AlgorithmatENM.ERP.ERPBusiness;
using Microsoft.AspNetCore.SignalR;
using NuGet.Packaging.Signing;
using NuGet.Protocol;
using S7.Net;
using SharpVision.SystemBase;
using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace AlgorithmatENMMVCCore.Hubs
{
    public class AlgGetOnlineService : BackgroundService
    {
        private readonly IHubContext<AlgHub> _hubContext;
        private readonly ILogger<AlgGetOnlineService> _logger;
        HttpClient _httpClient;
        public AlgGetOnlineService(
            IHubContext<AlgHub> hubContext,
            ILogger<AlgGetOnlineService> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
            _httpClient = new HttpClient();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Get Online Service started.");
            int intIndex = 1;
            string strMsg;
            List<SingleIDValue> lstIDValue;
            DataTable dtTemp;
            
            string strTempMsg = "";
            List<MOSimple> lstM;
            MOBiz objBiz;
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {

                    lstM = await BringOnlineData();
                    foreach (MOSimple objSimple in lstM) {
                        objBiz = objSimple.GetBiz();
                        objBiz.AddUniqueRef();
                    }
                    foreach (MOSimple objSimple in lstM)
                    {
                        await _hubContext.Clients.All.SendAsync("ReceiveMessage", "API:" + AlgHubServiceMessageType.MoReq.ToString(), System.Text.Json.JsonSerializer.Serialize(objSimple));
                    }

                    await MarkChangedMO(lstM);
                    if(lstM.Count==0)
                        await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);
                    // Wait before next iteration (e.g., 5 seconds)
                    intIndex++;
                    await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    // Service is stopping
                    await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in GetOnline background service");
                    await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
                }
            }

            _logger.LogInformation("GetOnline Background Service stopped.");
        }
        async Task<List<MOSimple>> BringOnlineData()
        {
            List<MOSimple> Returned = new List<MOSimple>();
            string strURL = SysData.ForeignURL + "api/MOChangesAPI";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, strURL);
            requestMessage.Headers.Add("Authorization", $"Bearer {SysData.OnlineToken}");


            var response = await _httpClient.SendAsync(requestMessage);
            string strTemp = await response.Content.ReadAsStringAsync();
            Returned = System.Text.Json.JsonSerializer.Deserialize<List<MOSimple>>(strTemp);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Progress update successful");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode} - {errorContent}");
            }
            return Returned;
        }
        async Task MarkChangedMO(List<MOSimple> lstSimple)
        {
            if (lstSimple == null || lstSimple.Count == 0)
                return;
            string strURL = SysData.ForeignURL + "api/MOChangesAPI";
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, strURL);
            requestMessage.Headers.Add("Authorization", $"Bearer {SysData.OnlineToken}");
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(lstSimple), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);

        }
        async Task CreateMO(MOSimple objSimple)
        {
          
            //string strURL = SysData.ForeignURL + "/mrp_production/create";
            //var requestMessage = new HttpRequestMessage(HttpMethod.Post, strURL);
            //requestMessage.Headers.Add("Authorization", $"Bearer {SysData.OnlineToken}");
            //requestMessage.Headers.Add("")
            //requestMessage.Content = new StringContent(JsonSerializer.Serialize(objSimple), Encoding.UTF8, "application/json");

            //var response = await _httpClient.SendAsync(requestMessage);

        }
    }
}
