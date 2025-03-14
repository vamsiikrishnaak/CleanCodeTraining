﻿/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2025, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hamaraBasket
{
    public class SoftDrinkItem : Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public SoftDrinkItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            Quality = SellIn < 0 ? Quality - 4 : Quality - 2;
            if (Quality > 50)
            {
                Quality = 50;
            }
            else if (Quality < 0)
            {
                Quality = 0;
            }
            SellIn -= 1;
        }
    }
}
