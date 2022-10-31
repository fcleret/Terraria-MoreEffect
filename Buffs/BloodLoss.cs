using Terraria;
using Terraria.ModLoader;

namespace MoreEffect.Buffs
{
    public class BloodLoss : ModBuff
    {
        public override void SetStaticDefaults()
        {
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<GlNPC.ModGlobalNPC>().Bloodloss = true;
        }
    }
}
