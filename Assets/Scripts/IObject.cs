using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public interface IObject
    {
        Image Image { get; set; }

        int MaxStackSize { get; }

        string UnlocalizedName { get; }
    }
}
