using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace MoreEffect.Config
{
    public class GeneralConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Multiplier")]
        [DefaultValue(1000)]
        [Range(1, 100)]
        public int MaxTiles;
    }
}
