using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Balance2.Content.Items.Weapons
{
    public class SpearWood : ModItem
    {
        public override string Texture => "Balance2/Assets/Textures/Items/Weapons/SpearWood";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden spear");
            Tooltip.SetDefault("Use it to poke your enemies!");

            DisplayName.AddTranslation(8, "Lança de madeira");
            Tooltip.AddTranslation(8, "Use para cutucar seus inimigos!");
        }

        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.DamageType = DamageClass.Melee;
            Item.width = 30;
            Item.height = 30;
            Item.knockBack = 4f;
            Item.useTime = 30;
            Item.useAnimation = 18;
            Item.rare = ItemRarityID.White;
            Item.value = 130;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 2.5f;

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Projectiles.SpearWoodProjectile>();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddTile(TileID.WorkBenches)
                .AddIngredient(ItemID.Wood, 15)
                .Register();
        }
    }
}
