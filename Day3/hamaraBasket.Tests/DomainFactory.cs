/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2025, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hamaraBasket.Tests
{
    class DomainFactory
    {
        public IList<Item> PrepareSingleItemList(string name, int sellIn, int quality)
        {
            switch (name)
            {
                case "Indian Wine":
                    return new List<Item> { new IndianWineItem(name, sellIn, quality) };
                case "Forest Honey":
                    return new List<Item> { new ForestHoneyItem(name, sellIn, quality) };
                case "Movie Tickets":
                    return new List<Item> { new MovieTicketItem(name, sellIn, quality) };
                case "Soft Drink":
                    return new List<Item> { new SoftDrinkItem(name, sellIn, quality) };
                default:
                    return new List<Item> { new GenericItem(name, sellIn, quality) };

            }
        }

        public Item GetItemAfterHamaraBasketUpdate(IList<Item> items)
        {
            HamaraBasket app = new HamaraBasket(items);
            app.UpdateQuality();
            return items[0];
        }
    }
}
