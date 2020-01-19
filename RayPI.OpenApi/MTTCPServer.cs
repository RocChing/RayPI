using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeetleX;
using BeetleX.EventArgs;
using Microsoft.Extensions.Logging;

namespace RayPI.OpenApi
{
    public class MTTCPServer : ServerHandlerBase
    {
        private Encoding encoding;
        private ILogger<MTTCPServer> logger;
        public MTTCPServer(ILogger<MTTCPServer> logger)
        {
            this.logger = logger;
            encoding = Encoding.GetEncoding("gbk");
        }

        public override void SessionReceive(IServer server, SessionReceiveEventArgs e)
        {
            byte[] bytes = new byte[e.Stream.Length];
            e.Stream.Read(bytes, 0, (int)e.Stream.Length);

            var lines = GetLines(bytes);
            foreach (var item in lines)
            {
                Console.Write(item);
            }
        }

        private string GetLineString(List<byte> list)
        {
            return encoding.GetString(list.ToArray());
        }

        private List<string> GetLines(byte[] bytes)
        {
            int[] array1 = new int[] { 27, 29 };
            int[] array2 = new int[] { 33, 76, 74, 100, 86, 32, 97, 105, 69, 66 };
            int sp_value = 64;

            List<string> reslut = new List<string>();
            List<byte> list = new List<byte>();
            for (int i = 0; i < bytes.Length; i++)
            {
                byte value = bytes[i];
                if (array1.Contains(value))
                {
                    if (list.Count > 0)
                    {
                        reslut.Add(GetLineString(list));
                        list.Clear();
                    }
                    int value_next = bytes[i + 1];
                    if (value_next == sp_value)
                    {
                        i += 1;
                        continue;
                    }
                    if (array2.Contains(value_next))
                    {
                        i += 2;
                        continue;
                    }
                }
                else
                {
                    list.Add(value);
                }
            }
            return reslut;
        }
    }
}
