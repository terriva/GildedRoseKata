using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseSolution
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var strategy = UpdateStrategyConstructor.GetStrategyFromItem(item);
                strategy.UpdateItemQuality(item);
            }
        }

    }
}
