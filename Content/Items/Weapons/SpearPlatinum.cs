using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Balance2.Content.Items.Weapons
{
    public class SpearPlatinum : ModItem
    {
        public override string Texture => "Balance2/Assets/Textures/Items/Weapons/SpearPlatinum";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platinum Dang Pa");
        }

        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.DamageType = DamageClass.Melee;
            Item.width = 30;
            Item.height = 30;
            Item.useAnimation = 22;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 12400;
            Item.rare = ItemRarityID.White;
            Item.shootSpeed = 2.6f;

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Projectiles.SpearPlatinumProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PlatinumBar, 8)
                .AddIngredient(ItemID.Wood, 12)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
    }
}
