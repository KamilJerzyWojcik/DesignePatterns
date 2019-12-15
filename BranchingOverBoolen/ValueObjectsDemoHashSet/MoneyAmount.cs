﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObjectsDemoHashSet
{
    sealed class MoneyAmount
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

        public static MoneyAmount operator *(MoneyAmount amount, decimal factor) => amount.Scale(factor);

        public override bool Equals(object obj) =>
            this.Equals(obj as MoneyAmount);

        private bool Equals(MoneyAmount other) =>
            other != null &&
            this.Amount == other.Amount &&
            this.CurrencySymbol == other.CurrencySymbol;

        public override int GetHashCode() =>
            this.Amount.GetHashCode() ^ this.CurrencySymbol.GetHashCode();

        public override string ToString() => $"{this.Amount} {this.CurrencySymbol}";
    }
}
