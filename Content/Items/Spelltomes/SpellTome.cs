using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Balance2.Common;

namespace Balance2.Content.Items.Spelltomes
{
    public class SpellTome : ModItem
    {
        public override string Texture => "Balance2/Assets/Textures/Items/Spelltomes/SpellTome";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spell Tome Placeholder");
            Tooltip.SetDefault("Not intended to be used");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 18;
            Item.damage = 1;
            Item.knockBack = 1f;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.DamageType = DamageClass.Magic;
            Item.shoot = ProjectileID.TerraBeam;
            Item.mana = 5;
            Item.shootSpeed = 16f;
        }

        public override bool? UseItem(Player player)
        {
            ModPlayerAttunments.registerSpell(this.Type);

            Terraria.Audio.SoundEngine.PlaySound(SoundID.MenuTick);
            return true;
        }
        public override bool CanShoot(Player player)
        {
            return false;
        }
    }
}
