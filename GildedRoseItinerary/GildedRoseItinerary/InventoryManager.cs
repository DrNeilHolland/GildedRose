using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseItinerary
{
    public class InventoryManager
    {
        List<InventoryItem> items = new List<InventoryItem>();

        public string[] ReadTestInput()
        {
            string[] lines = System.IO.File.ReadAllLines("TestInput.txt");

            foreach (string line in lines)
            {
                items.Add(CreateInstance(line));
            }

            return lines;
        }

        public string[] UpdateItems()
        {
            List<string> lines = new List<string>();
            foreach (InventoryItem item in items)
            {
                item.Update();
                lines.Add(item.Output());
            }
            return lines.ToArray();
        }

        #region Static Functions
        static public InventoryItem CreateInstance(string line)
        {
            InventoryItem newItem = new InvalidItem();

            try
            {
                string[] stringBits = line.Split(' ');
                if (stringBits.Length > 2)
                {
                    string strQuality = stringBits[stringBits.Length - 1];
                    string strSellIn = stringBits[stringBits.Length - 2];
                    int quality = Int32.Parse(strQuality);
                    int sellIn = Int32.Parse(strSellIn);

                    if (line.StartsWith("Aged Brie"))
                        newItem = new AgedBrie(sellIn, quality);
                    else if (line.StartsWith("Backstage passes"))
                        newItem = new BackStage(sellIn, quality);
                    else if (line.StartsWith("Sulfuras"))
                        newItem = new Sulfuras(sellIn, quality);
                    else if (line.StartsWith("Normal Item"))
                        newItem = new NormalItem(sellIn, quality);
                    else if (line.StartsWith("Conjured"))
                        newItem = new Conjured(sellIn, quality);
                    else
                    {
                        return newItem;//This is the default invalid item
                    }

                }
            }
            catch (Exception ex)
            {
                //do nothing, just return InvalidItem
            }
            return newItem;
        }
        #endregion
    }
}
