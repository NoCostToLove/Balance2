using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace Balance2.Common
{
    public class ModPlayerAttunments : ModPlayer
    {
        public int[] attunment;
        public int active;
        public bool initiate;
        public float[] bonus;

        public override void Initialize()
        {
            attunment = new int[12];
            for (int i = 0; i < 12; i++)
                attunment[i] = 0;

            bonus = new float[9];
            for (int i = 0; i < 9; i++)
                bonus[i] = 0.0f;
            //0 for life, 1 for earth, 2 for water, 3 for grass, 4 for fire, 5 for storm, 6 for wind, 7 for light, 8 for dark

            active = 0;

            initiate = false;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket modPacket = Mod.GetPacket();

            for (int i=0; i < 5; i++)
            {
                modPacket.Write(attunment[i]);
            }
            modPacket.Write(active);
            modPacket.Write(initiate);
        }
        public override void SaveData(TagCompound tag)
        {
            tag.Set("Attunment", attunment);
            tag.Set("Active", active);
            tag.Set("Initiate", initiate);
        }

        public override void LoadData(TagCompound tag)
        {
            attunment = tag.GetIntArray("Attunment");
            active = tag.GetInt("Active");
            initiate = tag.GetBool("Initiate");
        }

        public static void clearSpellSlots()
        {
            Player player = Main.LocalPlayer;

            for (int i = 0; i < player.GetModPlayer<ModPlayerAttunments>().attunment.Length; i++)
            {
                player.GetModPlayer<ModPlayerAttunments>().attunment[i] = 0;
            }
        }

        public static void registerSpell(int type)
        {
            Player player = Main.LocalPlayer;
            bool isSet = false;


            for(int j = 4; j >= 0;j--)
            {
                foreach(int a in player.GetModPlayer<ModPlayerAttunments>().attunment)
                {
                    if (a == type)
                        isSet = true;
                }
                if (isSet)
                    break;

                if (j > 0)
                    player.GetModPlayer<ModPlayerAttunments>().attunment[j] = player.GetModPlayer<ModPlayerAttunments>().attunment[j - 1];

                else
                    player.GetModPlayer<ModPlayerAttunments>().attunment[j] = type;

                if (!isValidSlot(j))
                    player.GetModPlayer<ModPlayerAttunments>().attunment[j] = 0;
            }
        }

        public static bool isValidSlot(int index)
        {
            if (index <= 1)
                return true;
            else if (index <= 2)
                return NPC.downedBoss2;
            else if (index <= 3)
                return Main.hardMode;
            else if (index <= 4)
                return NPC.downedPlantBoss;
            else if (index <= 5)
                return NPC.downedMoonlord;
            else
                return false;
        }

        public static int attachScroll()
        {
            ModPlayerAttunments attunment = Main.LocalPlayer.GetModPlayer<ModPlayerAttunments>();
            int spell = attunment.attunment[attunment.active];

            if(spell == ModContent.ItemType<Content.Items.Spelltomes.SpellTome>())
                return spell;
            else
                return 0;
        }

        public static int attachPage()
        {
            return 0;
        }

        public static int attachTome()
        {
            return 0;
        }
    }
}
