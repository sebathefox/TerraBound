using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.World
{
    class GenerateChunk : MonoBehaviour
    {
        public int width;
        public float heightMultiplier;

        public float smoothness;
        public int heightAddition;

        private float seed;

        void Start()
        {
            Block.InitBlocks();
            seed = Random.Range(-10000f, 10000f);
            Generate();
        }

        public void Generate()
        {
            for (int i = 0; i < width; i++)
            {
                int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, i / smoothness) * heightMultiplier) + heightAddition;
                Block selectedTile;

                for (int j = 0; j < h; j++)
                {
                    if (j < h - 4)
                        selectedTile = Block.blocks[0].Value;
                    else
                    {
                        selectedTile = Block.blocks[1].Value;
                    }

                    Instantiate(selectedTile, new Vector3(i, j), Quaternion.identity);
                }
            }
        }
    }
}
