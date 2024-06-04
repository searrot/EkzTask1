using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Record
    {
        public int LowLimit {  get; set; }

        public int HighLimit { get; set; }

        public int IntegralValue { get; set; }

        public Record(int lowLimit, int highLimit, int integralValue)
        {
            LowLimit = lowLimit;
            HighLimit = highLimit;
            IntegralValue = integralValue;
        }
    }
}
