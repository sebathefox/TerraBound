using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Items
{
    public interface ITool : IDurable
    {
        float MiningLevel { get; }

        float ToolXp { get; }

        float ToolSpeed { get; }
    }
}
