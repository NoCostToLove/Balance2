using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2.Tiles
{
    public class MyGlobalTiles : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            if (WorldGen.IsTileALeafyTreeTop(i,j) && type == TileID.Trees)
            {
                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.DirtBlock);
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