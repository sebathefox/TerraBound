using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.World
{
    public static class OreSpawn
    {
        /// <summary>
        /// Contains all of the ore names and their respective spawn chance
        /// </summary>
        public static readonly Dictionary<string, float> SpawnChance = new Dictionary<string, float>()
        {
            { "ore_iron", 1.0f },
            { "ore_copper", 1.5f }
        };
    }
}
