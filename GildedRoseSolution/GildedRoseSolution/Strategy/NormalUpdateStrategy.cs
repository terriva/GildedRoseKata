using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseSolution.Strategy
{
    public class NormalUpdateStrategy : IUpdateQualityStrategy
    {
        public void UpdateItemQuality(Item item)
        {
            if(item.SellIn > 0)
            {
                item.Quality = item.Quality - 1;
                item.SellIn = item.SellIn - 1;
            }else
            {
                item.SellIn = item.SellIn - 1;
                item.Quality = item.Quality - 2;
            }

            if(item.Quality <= 0)
            {
                item.Quality = 0;
            }
        }
    }
}
