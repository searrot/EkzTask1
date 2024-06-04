using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Consumer
    {
        private readonly int id;
        private Storage storage;
        private Random random;

        public bool IsAlive { get; private set; }

        public Consumer(int id, Storage storage, Random random)
        {
            this.id = id;
            this.storage = storage;
            this.random = random;
        }

        private int CalculateIntegral(int lowLimit, int highLimit)
        {
            return lowLimit * highLimit;
        }

        public void Start()
        {
            List<int> data;
            int integralValue;
            if (IsAlive) return;

            IsAlive = true;

            new Thread(_ =>
            {
                while (IsAlive)
                {
                    
                    data = storage.Get();
                    Thread.Sleep(random.Next(1000, 10000));
                    integralValue = CalculateIntegral(data[0], data[1]);
                }
            }

                ).Start();
        }

        public void Stop()
        {
            IsAlive = false;
        }

    }
}
