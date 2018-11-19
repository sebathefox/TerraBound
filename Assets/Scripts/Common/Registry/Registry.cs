using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Common.Registry
{
    public class Registry
    {
        //private static bool shuttingDown = false;
        //private static object objLock = new object();
        private static readonly Registry instance = new Registry();

        static Registry()
        {
        }

        protected Registry()
        {
        }

        public static Registry Instance
        {
            get { return instance; }
        }

        public List<Type> BlockRegistry { get; set; }

        public List<KeyValuePair<string, Type>> ItemRegistry { get; set; }
    }
}
