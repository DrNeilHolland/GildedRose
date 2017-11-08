using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GildedRoseItinerary
{
    public abstract class InventoryItem
    {
        #region Properties
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public string Name { get; set; }
        #endregion

        #region Member Functions
        public virtual void Update()
        {
            UpdateSellIn();
            UpdateQuality();
        }

        //Provide a default function for updating SellIn
        public virtual void UpdateSellIn()
        {
            SellIn -= 1;
        }

        //Provide a default function for updating Quality
        public virtual void UpdateQuality()
        {
            //Has it passed it sell in date?

            //No
            if(SellIn >= 0)
                Quality = Math.Min(50, Math.Max(0, Quality-1));
            //Yes - it degrades twice as fast
            else
                Quality = Math.Min(50, Math.Max(0, Quality - 2));
        }

        public virtual string Output()
        {
            return $"{Name} {SellIn} {Quality}\n";
        }
        #endregion

       
    }

    public class AgedBrie : InventoryItem
    {
        public AgedBrie(int sellIn, int quality)
        {
            this.Name = "Aged Brie";
            this.SellIn = sellIn;
            this.Quality = quality;
        }
        public override void UpdateQuality()
        {
            Quality = Math.Min(Quality + 1, 50);
        }
    }

    public class BackStage : InventoryItem
    {
        public BackStage(int sellIn, int quality)
        {
            this.Name = "Backstage passes";
            this.SellIn = sellIn;
            this.Quality = quality;
        }
        public override void UpdateQuality()
        {
            if (SellIn > 10)
                Quality = Math.Min(50, Quality + 1);
            else if (SellIn > 5)
                Quality = Math.Min(50, Quality + 2);
            else if (SellIn > 0)
                Quality = Math.Min(50, Quality + 3);
            else
                Quality = 0;
        }
    }

    public class Sulfuras : InventoryItem
    {
        public Sulfuras(int sellIn, int quality)
        {
            this.Name = "Sulfuras";
            this.SellIn = sellIn;
            this.Quality = quality;
        }

        public override void UpdateSellIn()
        {
            //no change to SellIn
        }

        public override void UpdateQuality()
        {
            //no change to Quality
        }
    }

    public class Conjured : InventoryItem
    {
        public Conjured(int sellIn, int quality)
        {
            this.Name = "Conjured";
            this.SellIn = sellIn;
            this.Quality = quality;
        }

        public override void UpdateQuality()
        {
            //Has it passed it sell in date?

            //No
            if (SellIn >= 0)
                Quality = Math.Min(50, Math.Max(0, Quality - 2));
            //Yes - it degrades twice as fast
            else
                Quality = Math.Min(50, Math.Max(0, Quality - 4));
        }
    }

    public class NormalItem : InventoryItem
    {
        public NormalItem(int sellIn, int quality)
        {
            this.Name = "Normal Item";
            this.SellIn = sellIn;
            this.Quality = quality;
        } 
        
        //No need to override functions, just use defaults
    }

    public class InvalidItem: InventoryItem
    {
        public override void UpdateSellIn()
        {
            SellIn = 0;
        }

        public override void UpdateQuality()
        {
            Quality = 0;
        }

        public override string Output()
        {
            return "NO SUCH ITEM\n";
        }
    }
}
