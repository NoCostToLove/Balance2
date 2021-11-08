using Balance2.Common;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Balance2.Content.Items.Spells
{
    public class SpellClear : ModItem
    {
        public override string Texture => "Balance2/Assets/Textures/Items/Spells/SpellTome";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of Amnesia");
            Tooltip.SetDefault("Removes all spells from attunment slots");

            DisplayName.AddTranslation(8, "Tomo do esquecimento");
            Tooltip.AddTranslation(8, "Remove todos os feitiços dos espaços de aprendizagem");

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
