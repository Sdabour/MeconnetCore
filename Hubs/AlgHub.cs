namespace AlgorithmatENMMVCCore.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    public class AlgHub:Hub
    {
        public async Task SendMessage(string strID,string strMessage)
        {
            await Clients.All.SendAsync("ReceiveMessage",strID, strMessage);
        }
        
    }
}
