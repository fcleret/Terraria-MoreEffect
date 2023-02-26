using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreEffect.Global
{
    public class ModGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public int level;

        public override void SetDefaults(Item item)
        {
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (IsCompatible(item))
            {
                TooltipLine line = new(Mod, "", $"Level: {level}")
                {
                    OverrideColor = Color.Cyan
                };
                tooltips.Add(line);
            }
        }

        public override GlobalItem NewInstance(Item target)
        {
            level = 1;
            return base.NewInstance(target);
        }

        public override bool CanRightClick(Item item)
        {
            return IsCompatible(item) || base.CanRightClick(item);
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            return !IsCompatible(item) && base.ConsumeItem(item, player);
        }

        public override void RightClick(Item item, Player player)
        {
            if (IsCompatible(item))
            {
                Main.NewText($"Merge: {item.Name} with {player.HeldItem.Name}");
                
                if (item.netID == player.HeldItem.netID
                    && GetLevel(item) == GetLevel(player.HeldItem))
                {
                    Main.NewText("Merge success !");

                    IncrementLevel(item);
                    item.damage += (int)(player.HeldItem.damage * 0.2);

                    player.HeldItem.TurnToAir();

                    /*
                    Item dropItem = player.HeldItem;
                    player.DropItem(dropItem.GetSource_FromThis(), Vector2.Add(player.position, new(0, 2)), ref dropItem);
                    */
                }
            }
        }

        private static void IncrementLevel(Item item)
        {
            item.GetGlobalItem<ModGlobalItem>().level++;
        }

        private static int GetLevel(Item item)
        {
            return item.GetGlobalItem<ModGlobalItem>().level;
        }

        private static bool IsCompatible(Item item)
        {
            return item.damage > 0;
        }
    }
}
