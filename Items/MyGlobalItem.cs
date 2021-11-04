using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2.Items
{
    public class MyGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.TheRottedFork:
                    item.damage = 14;
                    item.value = 24600;
                    break;
                case ItemID.BallOHurt:
                    item.value = 25900;
                    break;
            }

        }
    }
}
