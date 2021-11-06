using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2.Content.Items.Weapons
{
    public class SpearTungsten : ModItem
    {
        public override string Texture => "Balance2/Assets/Textures/Items/Weapons/SpearTungsten";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tungsten Halberd");
        }
        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Melee;
            Item.width = 30;
            Item.height = 30;
            Item.useAnimation = 22;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 6590;
            Item.rare = ItemRarityID.White;
            Item.shootSpeed = 2.6f;
            Item.knockBack = 4.5f;

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Projectiles.SpearTungstenProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TungstenBar, 8)
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
