using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Balance2.Content.Items.Weapons
{
    public class SpearCopper : ModItem
    {
        public override string Texture => "Balance2/Assets/Textures/Items/Weapons/SpearCopper";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Pike");

            DisplayName.AddTranslation(8, "Pique de cobre");
        }

        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.DamageType = DamageClass.Melee;
            Item.useTime = 28;
            Item.useAnimation = 22;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 30;
            Item.height = 30;
            Item.knockBack = 4f;
            Item.rare = ItemRarityID.White;
            Item.value = 439;
            Item.shootSpeed = 2.4f;

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Projectiles.SpearCopperProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperBar, 8)
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
