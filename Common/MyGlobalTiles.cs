using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2.Common
{
    public class MyGlobalTiles : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            if (WorldGen.IsTileALeafyTreeTop(i,j) && type == TileID.Trees)
            {
                if(Main.rand.Next(100) < 35)
                    Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Content.Items.LeafGreen>(), Main.rand.Next(3) + 1);
            }

            if (WorldGen.shadowOrbSmashed)
            {
                var tile = Main.tile[i, j];
                if (tile.frameX >= 36 && tile.frameX < 54 && tile.frameY < 18 || tile.frameY < 54 && tile.frameY >= 36)
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CrimstoneBlock, 16);
                }
            }
            return true;
        }
    }
}