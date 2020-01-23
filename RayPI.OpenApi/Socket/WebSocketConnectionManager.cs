using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace RayPI.OpenApi.Socket
{
    public class WebSocketConnectionManager
    {
        private Dictionary<string, WebSocket> _sockets = new Dictionary<string, WebSocket>();

        public int GetCount()
        {
            return _sockets.Count;
        }

        public WebSocket GetSocketById(string id)
        {
            return _sockets.FirstOrDefault(p => p.Key == id).Value;
        }

        public Dictionary<string, WebSocket> GetAll()
        {
            return _sockets;
        }
        public WebSocket GetWebSocket(string key)
        {
            WebSocket _socket;
            _sockets.TryGetValue(key, out _socket);
            return _socket;

        }

        public string GetId(WebSocket socket)
        {
            return _sockets.FirstOrDefault(p => p.Value == socket).Key;
        }
        public void AddSocket(WebSocket socket, string key)
        {
            if (GetWebSocket(key) != null)
            {
                _sockets.Remove(key, out WebSocket destoryWebsocket);
            }
            _sockets.TryAdd(key, socket);
            //string sId = CreateConnectionId();
            //while (!_sockets.TryAdd(sId, socket))
            //{
            //    sId = CreateConnectionId();
            //}
        }

        public async Task RemoveSocket(string id)
        {
            try
            {
                WebSocket socket;
                _sockets.Remove(id, out socket);
                await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public async Task CloseSocket(WebSocket socket)
        {
            await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
        }

        private string CreateConnectionId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
