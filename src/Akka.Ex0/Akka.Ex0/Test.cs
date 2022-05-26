using System;

namespace Akka.Ex0
{
    public class Test
    {
        public int MSum = 0;
        public void Call1()
        {
            //lock (this)
            //{

            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine("Hello Thread 1, mSum value: {0}", MSum);
                MSum += 1;
                Console.WriteLine("Goodbye Thread 1, mSum value: {0}", MSum);
            }
            //}
            //  Console.WriteLine(mSum);
        }
        public void Call2()
        {
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine("Hello Thread 2, mSum value: {0}", MSum);
                MSum += 1;
                Console.WriteLine("Goodbye Thread 2, mSum value: {0}", MSum);
            }
        }
    }
}