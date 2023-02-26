using Terraria;
using Terraria.ModLoader;

namespace MoreEffect.Global
{
    public class ModGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool Bloodloss;
        public float BloodlossStack = 0;

        public override void ResetEffects(NPC npc)
        {
            Bloodloss = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (Bloodloss)
            {
                if (BloodlossStack >= 100) {
                    BloodlossStack = 100;
                    if (0 < (npc.life -= (int)(npc.lifeMax * 0.1F)))
                    {
                        npc.lifeRegen = -(int)(npc.lifeMax * 0.1F);
                        damage = (int)(npc.lifeMax * 0.1F);
                    }
                    else {
                        npc.life = 1;
                        Bloodloss = false;
                    }
                }
                else {
                        npc.lifeRegen = -(int)(npc.lifeMax * 0.01F);
                        damage = (int)(npc.lifeMax * 0.01);
                }
                
                if (BloodlossStack <= 0)
                    Bloodloss = false;
                else
                    BloodlossStack -= 0.5F;
            }
            else
            {
                BloodlossStack = 0;
            }
        }
    }
}
