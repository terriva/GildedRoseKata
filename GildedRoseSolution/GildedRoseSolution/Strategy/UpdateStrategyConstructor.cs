using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseSolution.Strategy
{
    public class UpdateStrategyConstructor
    {
        public static IUpdateQualityStrategy GetStrategyFromItem(Item item)
        {
            if (item.Name.Contains("Aged Brie"))
            {
                return new AgedBrieUpdateStrategy();
            }            
            else if (item.Name.Contains("Sulfuras"))
            {
                return new SulfurasUpdateStrategy();
            }
            else if (item.Name.Contains("Backstage pass"))
            {
                return new BackstagePassesUpdateStrategy();
            }
            else if (item.Name.Contains("Conjured"))
            {
                return new ConjuredUpdateStrategy();
            }
            else
            {
                return new NormalUpdateStrategy();
            }
        }
    }
}
