using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.World
{
    public static class OreSpawn
    {
        public static readonly Dictionary<string, float> SpawnChance = new Dictionary<string, float>()
        {
            { "ore_iron", 1.0f },
            { "ore_copper", 0.89f }
        };
    }
}
