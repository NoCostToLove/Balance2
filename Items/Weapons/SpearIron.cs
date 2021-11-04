using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2.Items.Weapons
{
    public class SpearIron : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron Brandistock");
        }

        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.DamageType = DamageClass.Melee;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 28;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4f;
            Item.shootSpeed = 3f;
            Item.rare = ItemRarityID.White;
            Item.value = 1680;

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Projectiles.SpearIronProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IronBar, 8)
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
