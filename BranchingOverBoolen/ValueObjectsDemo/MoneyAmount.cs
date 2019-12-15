using System;

namespace ValueObjectsDemo
{
    public class MoneyAmount
    {
        public decimal Amount { get; }

        public string CurrencySymbol { get; }

        public MoneyAmount(decimal amount, string currencySymbol)
        {
            Amount = amount;
            CurrencySymbol = currencySymbol;
        }

        public MoneyAmount Scale(decimal factor) =>
            new MoneyAmount(this.Amount * factor, this.CurrencySymbol);

        public override string ToString() => $"{this.Amount} {this.CurrencySymbol}";
    }
}
