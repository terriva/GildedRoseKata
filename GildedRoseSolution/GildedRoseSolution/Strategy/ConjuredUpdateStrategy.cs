using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseSolution.Strategy
{
    public class ConjuredUpdateStrategy : IUpdateQualityStrategy
    {
        public void UpdateItemQuality(Item item)
        {
            if(item.SellIn > 0)
            {
                item.Quality = item.Quality - 2;
            }else
            {
                item.Quality = item.Quality - 4;
            }
            if(item.Quality < 0)
            {
                item.Quality = 0;
            }
            item.SellIn = item.SellIn - 1;
        }
    }
}
