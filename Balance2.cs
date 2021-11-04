using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2
{
	public class Balance : Mod
	{
        public override void AddRecipes()
        {
            CreateRecipe(ItemID.TheRottedFork)
                .AddIngredient(ItemID.TissueSample, 5)
                .AddIngredient(ItemID.CrimtaneBar, 10)
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe(ItemID.BallOHurt)
                .AddIngredient(ItemID.ShadowScale, 5)
                .AddIngredient(ItemID.DemoniteBar, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}