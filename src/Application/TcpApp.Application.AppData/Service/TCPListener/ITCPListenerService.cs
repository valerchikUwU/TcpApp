using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpApp.Application.AppData.Service.TCPListener
{
    /// <summary>
    /// Сервис имитации сервера
    /// </summary>
    public interface ITCPListenerService
    {

        /// <summary>
        /// Прием информации
        /// </summary>
        /// <returns></returns>
        public Task ReceivingData();
    }
}
