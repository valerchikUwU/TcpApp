using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TcpApp.Application.AppData.Service.TCPListener
{
    /// <inheritdoc cref="ITCPListenerService"/>
    public class TCPListenerService : ITCPListenerService
    {


        /// <inheritdoc cref="ITCPListenerService.ReceivingData()"/>
        public async Task ReceivingData()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            using Socket _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _server.Bind(ipPoint);
            _server.Listen();
            Console.WriteLine($"Server started on port {8888}");

            while (true)
            {
                using var tcpClient = await _server.AcceptAsync();
                byte[] responseData = new byte[1024];
                int bytes = 0; 
                var response = new StringBuilder(); 
                do
                {
                    bytes = await tcpClient.ReceiveAsync(responseData);
                    response.Append(Encoding.UTF8.GetString(responseData, 0, bytes));

                    Console.WriteLine($"Ответ: {response}");
                    response.Clear();
                }
                while (bytes > 0);
            }
        }

    }
}
