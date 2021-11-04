using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2.Items.Weapons
{
    public class SpearCorruption: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infected needle");
            Tooltip.SetDefault("Hits through enemies' defense" +
                "\n'Fear right into their veins!'");
        }

        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.DamageType = DamageClass.Melee;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 10;
            Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 23200;
            Item.rare = ItemRarityID.Blue;
            Item.shootSpeed = 6f;
            Item.knockBack = 2f;

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Projectiles.SpearCorruptionProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ShadowScale, 5)
                .AddIngredient(ItemID.DemoniteBar, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }

        public override bool CanShoot(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 peturbed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10f));
            velocity.X = peturbed.X;
            velocity.Y = peturbed.Y;
        }
    }
}
