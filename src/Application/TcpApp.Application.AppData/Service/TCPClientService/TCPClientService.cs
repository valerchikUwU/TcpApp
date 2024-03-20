using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TcpApp.Application.AppData.Service.TCPClient
{
    /// <inheritdoc cref="ITCPClientService"/>
    public class TCPClientService : ITCPClientService
    {

        /// <inheritdoc cref="ITCPClientService.SendingData()"/>
        public async Task SendingData()
        {
            using var tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                await tcpClient.ConnectAsync("127.0.0.1", 8888);
                Console.WriteLine("Connected to server");

                while (true)
                {
                    string time = DateTime.Now.ToString();
                    byte[] data = Encoding.UTF8.GetBytes(time);

                    await tcpClient.SendAsync(data);
                    Console.WriteLine($"Sent: {time}");
                    

                    await Task.Delay(TimeSpan.FromSeconds(30)); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                tcpClient.Close();
            }
             finally
            {
            
                tcpClient.Close();
            }
        }

    }
}
