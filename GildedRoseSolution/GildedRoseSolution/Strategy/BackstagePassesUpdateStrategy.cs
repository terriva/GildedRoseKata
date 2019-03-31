using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseSolution.Strategy
{
    public class BackstagePassesUpdateStrategy : IUpdateQualityStrategy
    {
        public void UpdateItemQuality(Item item)
        {
            if (item.SellIn > 10)
            {
                item.Quality = item.Quality + 1;
            }
            if (item.SellIn <= 10)
            {
                item.Quality = item.Quality + 2;
            }
            if (item.SellIn <= 5)
            {
                item.Quality = item.Quality + 1;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
            item.SellIn = item.SellIn - 1;
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }

        }
    }
}
