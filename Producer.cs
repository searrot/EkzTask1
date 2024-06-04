using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WpfApp1
{
    internal class Producer
    {
        private readonly int id;
        private Storage storage;
        private Random random;

        public bool IsAlive { get; private set; }

        public Producer(int id, Storage storage, Random random) { 
            this.id = id;
            this.storage = storage;
            this.random = random;
        }


        public void Start()
        {
            int limit;
            if (IsAlive) return;

            IsAlive = true;

            new Thread (_ =>
                {
                    while (IsAlive)
                    {
                        Thread.Sleep(random.Next(1000, 10000));
                        if (id == 0)
                        {
                            limit = random.Next(0, 20);
                        } else limit = random.Next(20, 40);

                        storage.Put(id, limit);
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
