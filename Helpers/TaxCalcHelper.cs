using SalesTaxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxes.Helpers
{
    public class TaxCalcHelper
    {

        public static bool IsItemTaxable(Item item)
        {
            return !Enum.IsDefined(typeof(NonTaxables), item.Name.Replace(" ", ""));
        }

        public static void SetItemSalesTax(Item item)
        {
            double preRoundTax = 0;
            if (item.Name.Contains("Imported") && TaxCalcHelper.IsItemTaxable(item))
            {
                preRoundTax = item.Price * .05;
                preRoundTax = Math.Round(preRoundTax / .05) * .05;
                preRoundTax += item.Price * .1;
            }
            else if (!item.Name.Contains("Imported") && TaxCalcHelper.IsItemTaxable(item))
            {
                preRoundTax = item.Price * .1;

            } else if (item.Name.Contains("Imported") && !TaxCalcHelper.IsItemTaxable(item))
            {
                preRoundTax = item.Price * .05;
            } else
            {
                return;
            }
            item.TaxAmount = Math.Round(preRoundTax / .05) * .05;
            item.Price = Math.Round((item.Price + item.TaxAmount) * item.Quantity, 2, MidpointRounding.AwayFromZero);
        }
    }

}