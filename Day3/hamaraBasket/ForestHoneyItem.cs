/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2025, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hamaraBasket
{
    public class ForestHoneyItem : Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public ForestHoneyItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
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
