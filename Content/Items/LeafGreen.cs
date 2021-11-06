using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2.Content.Items
{
    public class LeafGreen : ModItem
    {
        public override string Texture => "Balance2/Assets/Textures/Items/LeafGreen";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GreenLeaf");
            Tooltip.SetDefault("Sometimes fall of trees" +
                "\nJust a tiny leaf, nothing too special");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 17;
            Item.holdStyle = 1;
            Item.rare = ItemRarityID.White;
            Item.value = 100;
            Item.maxStack = 99;
        }
    }
}
