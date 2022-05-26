using System;
using System.Threading;

namespace Akka.Ex0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();

            Thread thread1 = new Thread(t.Call1);
            Thread thread2 = new Thread(t.Call2);
            thread1.Start();
            thread2.Start();
            Thread.Sleep(3000); //Give enough time for threads to end
            Console.Write("{0},", t.MSum);
            t.MSum = 0;

            /*
             * Hello Thread 1, mSum value: 62    Goodbye Thread 1, mSum value: 63
             * Hello Thread 1, mSum value: 63    Goodbye Thread 1, mSum value: 64
             * Hello Thread 2, mSum value: 59    Goodbye Thread 2, mSum value: 65
             * Hello Thread 2, mSum value: 65    Goodbye Thread 2, mSum value: 66
             */
        }
    }
}
