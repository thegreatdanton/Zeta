using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta.Models
{
    public class Notification
    {
        public string OrderId { get; set; }

        public string Message { get; set; }

        public double Change { get; set; }
    }
}
