/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2025, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hamaraBasket
{
    public class MovieTicketItem : Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public MovieTicketItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            if (SellIn <= 0)
            {
                Quality = 0;
            }
            else if (SellIn <= 5)
            {
                Quality = Quality < 50 ? Quality + 3 : 50;
            }
            else if (SellIn <= 10)
            {
                Quality = Quality < 50 ? Quality + 2 : 50;
            }
            if (Quality < 0)
            {
                Quality = 0;
            }
            else if (Quality > 50)
            {
                Quality = 50;
            }
        }
    }
}
