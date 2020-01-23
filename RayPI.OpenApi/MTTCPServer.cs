using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeetleX;
using BeetleX.EventArgs;
using Microsoft.Extensions.Logging;
using RayPI.Domain.Common;
using RayPI.Domain.Entity;
using Newtonsoft.Json;
using RayPI.Business;
using RayPI.OpenApi.Socket;
using System.Net.WebSockets;
using System.Threading;

namespace RayPI.OpenApi
{
    public class MTTCPServer : ServerHandlerBase
    {
        private WebSocketConnectionManager webSocketConnectionManager;
        public MTTCPServer( WebSocketConnectionManager webSocketConnectionManager)
        {
            this.webSocketConnectionManager = webSocketConnectionManager;
        }

        public override void SessionReceive(IServer server, SessionReceiveEventArgs e)
        {
            //byte[] bytes = new byte[e.Stream.Length];
            //e.Stream.Read(bytes, 0, (int)e.Stream.Length);

            string str = e.Stream.ToPipeStream().ReadToEnd();
            string[] strs = str.Split(',');
            byte[] bytes = new byte[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                bytes[i] = byte.Parse(strs[i]);
            }

            Console.WriteLine("begin.........................");
            foreach (var item in bytes)
            {
                Console.Write(item);
                Console.Write(",");
            }
            Console.WriteLine();
            Console.WriteLine("end.........................................");

            OrderEntity order = OrderFactory.Parse(bytes);

            if (order != null)
            {
                if (order.IsValid())
                {
                    string json = JsonConvert.SerializeObject(order);
                    Console.WriteLine(json);
                    //orderBusiness.Add(order);
                    var clients = webSocketConnectionManager.GetAll();
                    if (clients != null)
                    {
                        Console.WriteLine($"the clients count is:{clients.Count}");
                    }
                    foreach (var item in clients)
                    {
                        SendMsg(item.Value, json);
                    }
                }
                else
                {
                    Console.WriteLine("没有找到订单");
                }
            }
        }

        private async Task SendMsg(WebSocket socket, string message)
        {
            Console.WriteLine($"the socket state is:{socket.State}");
            if (socket.State != WebSocketState.Open)
                return;
            var bytes = Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(buffer: new ArraySegment<byte>(array: bytes, offset: 0, count: bytes.Length), messageType: WebSocketMessageType.Text, endOfMessage: true, cancellationToken: CancellationToken.None);
        }
    }
}
