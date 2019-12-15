using System;

namespace ValueObjectsDemoImmutableObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            MoneyAmount x = new MoneyAmount(2, "USD");
            MoneyAmount y = new MoneyAmount(4, "USD");

            if (x.Equals(y))
            {
                Console.WriteLine("Equal.");
            }

            if((x * 2).Equals(y))
            {
                Console.WriteLine("Eual After scaling.");
            }

            Console.ReadLine();
        }
    }
}
