using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2.Content.Items.Weapons
{
    public class SpearLead : ModItem
    {
        public override string Texture => "Balance2/Assets/Textures/Items/Weapons/SpearLead";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lead Trident");
        }

        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.DamageType = DamageClass.Melee;
            Item.width = 30;
            Item.height = 30;
            Item.useAnimation = 22;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 2.6f;
            Item.rare = ItemRarityID.White;
            Item.value = 2590;

            Item.noUseGraphic = true;
            Item.noMelee = true;

            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Projectiles.SpearLeadProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LeadBar, 8)
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
