using System;
using System.Collections.Generic;

namespace MangaStore.Shared.Models
{
    public class Money : ValueObject
    {
        public Money()
        {
            Value = null;
            Currency = null;
        }

        public Money(decimal value, string currency)
        {
            Value = value;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public decimal? Value { get; private set; }
        public string Currency { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Currency.ToUpper();
        }
    }
}