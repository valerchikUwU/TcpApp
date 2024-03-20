using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpApp.Application.AppData.Service.TCPClient
{
    /// <summary>
    /// Сервис имитации клиента
    /// </summary>
    public interface ITCPClientService
    {
        /// <summary>
        /// Отправка информации
        /// </summary>
        /// <returns></returns>
        public Task SendingData();
    }
}
