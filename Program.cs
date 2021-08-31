using System;
using System.Collections.Generic;
using SalesTaxes.Helpers;
using SalesTaxes.Models;

namespace SalesTaxes
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Item> itemList = new List<Item>();
            InputMessageHelper inMessageHelper = new InputMessageHelper();
            OutputMessageHelper outMessageHelper = new OutputMessageHelper();

            inMessageHelper.RunInputMessage();
            itemList = inMessageHelper.GetItemList();

            foreach (Item i in itemList)
            {
                outMessageHelper.GetItemOutput(i);
            }

            outMessageHelper.OutputTotals();
        }
    }
}
