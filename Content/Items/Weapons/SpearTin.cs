using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2.Content.Items.Weapons
{
    public class SpearTin : ModItem
    {
        public override string Texture => "Balance2/Assets/Textures/Items/Weapons/SpearTin";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tin Spear");

            DisplayName.AddTranslation(8, "Lança de estanho");
        }
        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.DamageType = DamageClass.Melee;
            Item.width = 30;
            Item.height = 30;
            Item.knockBack = 4.5f;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 30;
            Item.useAnimation = 24;
            Item.rare = ItemRarityID.White;
            Item.value = 590;
            Item.shootSpeed = 2.7f;

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Projectiles.SpearTinProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TinBar, 8)
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
