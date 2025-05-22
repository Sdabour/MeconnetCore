using AlgorithmatENM.ENM.ENMBiz;
using AlgorithmatENM.ERP.ERPBusiness;
using Microsoft.AspNetCore.SignalR;
using System;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Data;
namespace AlgorithmatENMMVCCore.Hubs
{
    public enum AlgHubServiceMessageType { BufV,MoReq };
    public class SingleIDValue { public int ID { set; get; }
        public string Value { set; get; } }
    public class MessageQueue {
        private readonly ConcurrentQueue<Message> _queue = new();

        public void Enqueue(Message message) => _queue.Enqueue(message);

        public bool TryDequeue(out Message message) => _queue.TryDequeue(out message);
    }
    public class AlgHubService:BackgroundService
    {
        private readonly IHubContext<AlgHub> _hubContext;
        private readonly ILogger<AlgHubService> _logger;
        
        public AlgHubService(
            IHubContext<AlgHub> hubContext,
            ILogger<AlgHubService> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("SignalR Background Service started.");
            int intIndex = 1;
            string strMsg;
            List<SingleIDValue> lstIDValue;
            DataTable dtTemp;
            BufferCol objBufferCol = new BufferCol(false);
            PLCCol objPlcCol = objBufferCol.PLCCol;
            string strTempMsg = "";
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    dtTemp = objPlcCol.SaveS7BufferRead("");
                    lstIDValue = dtTemp.Rows.Cast<DataRow>().Select(objDr => new SingleIDValue() { ID = int.Parse(objDr["BufferID"].ToString()), Value = objDr["MeasureValue"].ToString() }).ToList();
                    //objCol = new BufferMeasureCol(true, DateTime.Now, DateTime.Now);
                    //objMeasureCol = objCol.Cast<BufferMeasureBiz>().ToList().GetMeasurementLst();
                    //lstIDValue = objCol.Cast<BufferMeasureBiz>().Select(x => new SingleIDValue() { ID = x.BufferID, Value = x.MeasureValue.ToString() }).ToList();
                    if (lstIDValue.Count == 0)
                    {

                    }
                    // Your continuous logic here
                    strMsg = System.Text.Json.JsonSerializer.Serialize(lstIDValue);// $"Update at {DateTime.Now:HH:mm:ss}-Index-{intIndex.ToString()}";

                    // Push to all connected clients
                    //  await _hubContext.Clients.All.SendAsync("ReceiveUpdate", message);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Server:" + AlgHubServiceMessageType.BufV.ToString(), strMsg);
                    strTempMsg = lstIDValue.Count.ToString()  +" of data has been sent ";
                   _logger.LogInformation("Sent update: {Message}", strTempMsg);
                  
                    // Wait before next iteration (e.g., 5 seconds)
                    intIndex++;
                    await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    // Service is stopping
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in SignalR background service");
                    await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                }
            }

            _logger.LogInformation("SignalR Background Service stopped.");
        }
        protected  async Task ExecuteAsyncOld(CancellationToken stoppingToken)
        {
            _logger.LogInformation("SignalR Background Service started.");
            int intIndex = 1;
            string strMsg;
            List<SingleIDValue> lstIDValue;
            BufferMeasureCol objCol;
            MeasurementCol objMeasureCol;
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {

                     objCol = new BufferMeasureCol(true, DateTime.Now, DateTime.Now);
                     objMeasureCol = objCol.Cast<BufferMeasureBiz>().ToList().GetMeasurementLst();
                    lstIDValue =objCol.Cast<BufferMeasureBiz>().Select(x=>new SingleIDValue() { ID=x.BufferID,Value=x.MeasureValue.ToString()}).ToList();
                    if(lstIDValue.Count == 0)
                    {
                      
                    }
                    // Your continuous logic here
                    strMsg = System.Text.Json.JsonSerializer.Serialize(lstIDValue);// $"Update at {DateTime.Now:HH:mm:ss}-Index-{intIndex.ToString()}";

                    // Push to all connected clients
                    //  await _hubContext.Clients.All.SendAsync("ReceiveUpdate", message);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Server:"+AlgHubServiceMessageType.BufV.ToString(), strMsg);
                    _logger.LogInformation("Sent update: {Message}", strMsg);

                    // Wait before next iteration (e.g., 5 seconds)
                    intIndex++;
                    await Task.Delay(TimeSpan.FromSeconds(120), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    // Service is stopping
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in SignalR background service");
                    await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                }
            }

            _logger.LogInformation("SignalR Background Service stopped.");
        }
        
    }
}
