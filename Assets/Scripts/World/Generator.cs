using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.World
{
    public class Generator : MonoBehaviour
    {
        public Transform Block;

        void Start()
        {
            for (float i = 0; i < 100; i += 0.32f)
            {
                Instantiate(Block, new Vector3(i, 0, 0), Quaternion.identity);
            }
        }
    }
}
