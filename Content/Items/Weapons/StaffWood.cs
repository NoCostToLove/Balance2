using Balance2.Common;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Balance2.Content;

namespace Balance2.Content.Items.Weapons
{
    public class StaffWood : ModItem
    {

        public override string Texture => "Balance2/Assets/Textures/Items/Weapons/StaffWood";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Staff");
            Tooltip.SetDefault("Require spell tomes to use" +
                "\n'A beginner's best friend!'");
            Item.staff[Item.type] = true;
        }

        public int mana
        {
            get;
            set;
        }

        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.mana = 1;
            Item.width = 40;
            Item.height = 36;
            Item.useTime = 30;
            Item.useAnimation = 28;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.White;
            Item.value = 210;
            Item.knockBack = 3f;
            Item.shootSpeed = 6f;

            Item.noMelee = true;

            Item.UseSound = SoundID.Item43;
            Item.shoot = ProjectileID.PurificationPowder;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddTile(TileID.WorkBenches)
                .AddIngredient(ItemID.Wood, 15)
                .AddIngredient(ModContent.ItemType<Content.Items.LeafGreen>(), 5)
                .Register();
        }

        public override void ModifyWeaponDamage(Player player, ref StatModifier damage, ref float flat)
        {
            float magic = player.GetDamage<MagicDamageClass>();
            float summon = player.GetDamage<SummonDamageClass>();

            damage *= (magic + summon)/2;
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int tome = ModPlayerAttunments.attachScroll();

            if (tome == 0)
            {
                Item.useStyle = ItemUseStyleID.None;
                type = ProjectileID.None;
                Item.noMelee = false;
            }
            else if (tome == ModContent.ItemType<Content.Items.Spelltomes.SpellTome>())
            {
                Item.useStyle = ItemUseStyleID.Swing;
                Item.mana = 5;
                float rotation = MathHelper.ToRadians(20f);

                position += Vector2.Normalize(velocity) * 45f;

                for (int i = 0; i < 4; i++)
                {
                    Vector2 pertubedspeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (3 - 1))) * .2f;
                    Projectile.NewProjectile(source, position, pertubedspeed, ProjectileID.TerraBeam, damage, knockback, player.whoAmI);
                }
            }

            return false;
        }
    }
}
