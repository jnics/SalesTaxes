using SalesTaxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxes.Helpers
{
    public class InputMessageHelper
    {
        List<Item> itemList = new List<Item>();
        public void RunInputMessage()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            Console.WriteLine("Please input items and press enter when a second time when done. Example input:  1 Book at 12.49 ");
            while (key.Key != ConsoleKey.Enter)
            {
                Item newItem = RunItemInput();

                if (!UpdateItemQuantity(newItem.Name))  itemList.Add(newItem);
                key = Console.ReadKey(true);
            }
        }

        public List<Item> GetItemList()
        {
            return itemList;
        }

        private Item RunItemInput()
          {
            return StringToItem(Console.ReadLine());
        }

        private Item StringToItem(string userInput)
        {
            int quantityIndex = userInput.IndexOf(" ");
            string tempQuantity = userInput.Substring(0, quantityIndex);
            string postQuantityStr = userInput.Substring(quantityIndex, userInput.Length - 1);
            string[] priceNameArray = postQuantityStr.Split(" at ");

            int quantity = int.TryParse(tempQuantity, out int quantityValue) ? quantityValue : 0;
            double price = double.TryParse(priceNameArray[1], out double priceValue) ? priceValue : 0;

            return new Item { Name = priceNameArray[0], Price = price, Quantity = quantity };
        }

        private bool UpdateItemQuantity(string name)
        {
            foreach(Item item in itemList.Where(i => i.Name == name))
            {
                item.Quantity++;
                return true;
            }
            return false;

        }
    }
}