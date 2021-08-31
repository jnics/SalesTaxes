using SalesTaxes.Models;
using System;
using System.Collections.Generic;

namespace SalesTaxes.Helpers
{
    public class OutputMessageHelper
    {
        public double salesTax;
        public double total;

        public void GetItemOutput(Item item)
        {
            TaxCalcHelper.SetItemSalesTax(item);
            Console.WriteLine(ItemToString(item));
        }

        public void OutputTotals()
        {
            Console.WriteLine($"Sales Taxes: {salesTax}");
            Console.WriteLine($"Total: {total}");
        }
        private string ItemToString(Item item)
        {
            SetSalesTaxTotal(item.Price * item.Quantity, item.TaxAmount);
            return item.Quantity == 1 ?
                    $"{item.Name}: {item.Price}" :
                    $"{item.Name}: {item.Price * item.Quantity} ({item.Quantity} at {item.Price})";
        }

        private void SetSalesTaxTotal(double price, double TaxAmount)
        {
            salesTax += TaxAmount;
            total += price;
        }
    }
}