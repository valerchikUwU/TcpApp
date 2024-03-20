using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpApp.Domain
{
    public class TimeLog
    {
        public Guid Id {  get; set; }
        public DateTime Date_Time {  get; set; }
        public bool IsChecked { get; set; }
    }
}
