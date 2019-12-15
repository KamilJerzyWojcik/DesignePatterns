using System;

namespace ValueObjectsDemo
{
    class Program
    {
        static bool IsHappyHour { get; set; }

        static MoneyAmount Reserve(MoneyAmount cost)
        {
            decimal factor = 1;
            MoneyAmount newCost = cost;

            if(IsHappyHour)
            {
                factor = 0.5M;
            }

            Console.WriteLine("\nReserving an item that cost {0}.", cost);

            return cost.Scale(factor);
        }

        static void Buy(MoneyAmount wallet, MoneyAmount cost)
        {
            bool enoughMoney = wallet.Amount >= cost.Amount;

            MoneyAmount finalCost =  Reserve(cost);

            bool finalEnough = wallet.Amount >= finalCost.Amount;

            if (enoughMoney && finalEnough)
            {
                Console.WriteLine("You will pay {0} with your {1}.", cost, wallet);
            }
            else if (finalEnough)
            {
                Console.WriteLine("This time, {0} will be enough to pay {1}.", wallet, finalCost);
            }
            else
            {
                Console.WriteLine("You cannot pay {0} with your {1}.", cost, wallet);
            }
        }

        static void Main(string[] args)
        {
            var wallet = new MoneyAmount(12, "USD");
            var cost = new MoneyAmount(10, "USD");

            Buy(wallet, cost);

            var wallet2 = new MoneyAmount(7, "USD");
            var cost2 = new MoneyAmount(10,  "USD");

            Buy(wallet2, cost2);

            Console.ReadLine();
        }
    }
}
