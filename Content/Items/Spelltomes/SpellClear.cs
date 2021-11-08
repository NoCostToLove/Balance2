using Balance2.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2.Content.Items.Spelltomes
{
    public class SpellClear : ModItem
    {
        public override string Texture => "Balance2/Assets/Textures/Items/Spelltomes/SpellTome";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of Amnesia");
            Tooltip.SetDefault("Removes all spells from attunment slots");


        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.mana = 5;
        }

        public override bool? UseItem(Player player)
        {
            Terraria.Audio.SoundEngine.PlaySound(SoundID.MenuTick);
            ModPlayerAttunments.clearSpellSlots();
            return true;
        }
    }
}
