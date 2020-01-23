using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Text;

namespace RayPI.OpenApi.Socket
{
    public class MTWebSocketHandler : WebSocketHandler
    {
        public MTWebSocketHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {

        }

        public override async Task OnConnected(WebSocket socket, string key)
        {
            await base.OnConnected(socket, key);
            int count = WebSocketConnectionManager.GetCount();
            Console.WriteLine($"the socket count is:{count}");
            //await SendMessageAsync(socket, "你好,客户端" + key);
        }

        public override Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            int count = WebSocketConnectionManager.GetCount();
            Console.WriteLine($"the socket count is:{count}");
            //string data = Encoding.UTF8.GetString(buffer);
            return Task.FromResult(0);
        }
    }
}
