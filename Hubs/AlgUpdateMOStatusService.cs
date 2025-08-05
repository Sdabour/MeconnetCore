
using AlgorithmatENM.ERP.ERPBusiness;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    class OdooScadaApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _bearerToken;

        public OdooScadaApiClient(string baseUrl, string bearerToken)
        {
            _baseUrl = baseUrl;
            _bearerToken = bearerToken;
            _httpClient = new HttpClient();
        }

        public async Task<bool> UpdateManufacturingOrderProgress(int moId, DateTime timestamp, ProgressUpdateRequest request)
        {
            try
            {
                var url = $"{_baseUrl}/mrp_production/{moId}/progress";

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", $"Bearer {_bearerToken}");
                requestMessage.Headers.Add("X-Timestamp", timestamp.ToString("o"));

                var jsonContent = JsonSerializer.Serialize(request);
                requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {

                    Console.WriteLine("Progress update successful");
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {response.StatusCode} - {errorContent}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }
    }

    // Request model
    public class ProgressUpdateRequest
    {
        public int workcenter_id { get; set; }
        public double quantity { set; get; } = 0;
        public string status { get; set; } // "ongoing", "finished", "failure", "paused"
        public List<ConsumptionItem> consumption { get; set; } = new List<ConsumptionItem>();
        public string timestamp { get; set; }
        public string message { get; set; }
        public float elapsed_time { get; set; }
        public List<Byproduct> byproducts { get; set; } = new List<Byproduct>();
        public List<Workorder> workorders { get; set; }=new List<Workorder>();
    }

    public class ConsumptionItem
    {
        public int id { get; set; }
        public float quantity { get; set; }
        public int uom_id { get; set; }
    }

    public class Byproduct
    {
        public int id { get; set; }
        public float quantity { get; set; }
        public int uom_id { get; set; }
    }

    public class Workorder
    {
        public int id { get; set; }
        public float time_elapsed { get; set; }
    }

    public class AlgUpdateMOStatusService : BackgroundService
    {
        private readonly IHubContext<AlgHub> _hubContext;
        private readonly ILogger<AlgUpdateMOStatusService> _logger;
        HttpClient _httpClient;
        public AlgUpdateMOStatusService(
            IHubContext<AlgHub> hubContext,
            ILogger<AlgUpdateMOStatusService> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
            _httpClient = new HttpClient();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Get Online Servuce started.");
            ProgressUpdateRequest objRequest;
            int intTemp = 0;
            int intWaitingSecond = 30*2*5;
            MOCol objCol;
            bool blCreated;
            OdooScadaApiClient objClient = new OdooScadaApiClient(SysData.ODOOURL, SysData.APIKey);
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {

                    using (var objMutex = new Mutex(false, SysData.MOUpdateStatusMutex,out blCreated))
                    {
                       blCreated = objMutex.WaitOne();
                       // blCreated = true;

                        if (blCreated)
                        {
                           
                            try
                            {
                                //objMutex.WaitOne();
                                 objCol = new MOCol("",false,DateTime.Now,DateTime.Now, intChangeStatus:0, inStatusChangedStatus: 1);
                                if(objCol.Count > 0)
                                {

                                    objCol.SetCol();
                                    foreach(MOBiz objBiz in objCol)
                                    {
                                        intTemp = 0;
                                        if (!int.TryParse(objBiz.Ref, out intTemp))
                                            continue;

                                        objBiz.SetMeasureCol();
                                         objRequest = objBiz.GetProgressUpdateRequest();
                                        try
                                        {
                                            if (await objClient.UpdateManufacturingOrderProgress(intTemp, DateTime.Now, objRequest))
                                            {
                                                objBiz.EditMOStatusChanged();
                                            }
                                        }
                                        catch { }


                                    }
                                }    

                            }
                            catch (Exception ex) { }
                            finally { 
                            if(blCreated)
                                {

                                    objMutex.ReleaseMutex(); 
                                }

                            }

                        }
                       

                    }

                        await Task.Delay(TimeSpan.FromSeconds(intWaitingSecond), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    // Service is stopping
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in GetOnline background service");
                    await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
                }
            }

            _logger.LogInformation("GetOnline Background Service stopped.");
        }
     
    }
}

