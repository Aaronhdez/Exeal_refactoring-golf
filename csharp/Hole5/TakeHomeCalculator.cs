﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Hole5
{
    public class TaxRate
    {
        public TaxRate(int percent)
        {
            Percent = percent;
        }

        public int Percent { get; private set; }
    }

    public class TakeHomeCalculator
    {
        private readonly TaxRate taxRate;

        public TakeHomeCalculator(TaxRate taxRate)
        {
            this.taxRate = taxRate;
        }

        public Money NetAmount(Money first, params Money[] rest)
        {
            List<Money> monies = rest.ToList();

            Money total = first;

            foreach (Money next in monies)
            {
                total = total.Plus(next);
            }

            Double amount = total.value * (taxRate / 100d);
            Money tax = Money.Create(Convert.ToInt32(amount), first.currency);

            return total.Minus(tax);
        }
    }
}