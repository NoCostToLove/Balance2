using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Balance2.Content.Items.Weapons
{
    public class SpearSilver : ModItem
    {
        public override string Texture => "Balance2/Assets/Textures/Items/Weapons/SpearSilver";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Guan dao");
        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Melee;
            Item.width = 30;
            Item.height = 30;
            Item.knockBack = 4f;
            Item.useTime = 28;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.rare = ItemRarityID.White;
            Item.value = 4200;
            Item.shootSpeed = 3f;

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Projectiles.SpearSilverProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverBar, 8)
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
