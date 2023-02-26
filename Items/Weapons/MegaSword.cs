using MoreEffect.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreEffect.Items.Weapons
{
    public class MegaSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault($"BloodLoss sword ! {Main.maxTilesX}");
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.crit = 50;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.scale = 3;
            Item.useTime = 36;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = -12;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddIngredient(ItemID.CopperOre, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.StoneBlock, 10);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.Register();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(ModContent.BuffType<BloodLoss>(), 1000);
            target.GetGlobalNPC<Global.ModGlobalNPC>().BloodlossStack += 20;

        }
    }
}