﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumidor.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var producer = new Producer();
            var consumers = new List<Consumer>()
            {
                new Consumer { Id = "Consumer 1" },
                new Consumer { Id = "Consumer 2" },
                new Consumer { Id = "Consumer 3" },
                new Consumer { Id = "Consumer 4" },
                new Consumer { Id = "Consumer 5" },
            };

            var service = new Service<int>(producer, consumers);
            service.ProducerRefreshTimes = 2;
            service.Start();

            Console.WriteLine("Press something to stop producer");
            Console.ReadLine();
            service.ProducerCancelationTokenSource.Cancel();

            Console.WriteLine("Press something to stop consumers");
            Console.ReadLine();
            service.ConsumerCancelationTokenSource.Cancel();
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
