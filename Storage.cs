using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Storage
    {
        private List<int> _data;
        private List<int> dataCopy;

        public Storage()
        {
            _data = new List<int>(2);
            for (int i = 0; i < 2; i++) {
                _data.Add(-1);
            }
        }

        public void Put(int index, int value)
        {
            lock (_data)
            {
                _data[index] = value;
                Monitor.PulseAll(_data);
            }
            
        }

        public List<int> Get()
        {
            lock (_data) { 

                while (_data.Contains(-1))
                {
                    Monitor.Wait(_data);
                }
                dataCopy = _data.ToList();
                _data[0] = _data[1] = -1;
            }
            return dataCopy;
        }



    }
}
