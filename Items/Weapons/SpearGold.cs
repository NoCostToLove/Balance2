using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2.Items.Weapons
{
    public class SpearGold : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Yari");
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Melee;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 28;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 8500;
            Item.rare = ItemRarityID.White;
            Item.shootSpeed = 3.0f;

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.SpearGoldProjectile>();
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GoldBar, 8)
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
