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
        public GameObject Grass;
        public GameObject Stone;

        public int width;
        public float heightMultiplier;

        public float smoothness;
        public int heightAddition;

        [HideInInspector]
        public float seed;

        void Start()
        {
            Generate();
        }

        public void Generate()
        {
            for (int i = 0; i < width; i++)
            {
                int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, (i + transform.position.x) / smoothness) * heightMultiplier) + heightAddition;
                GameObject selectedTile;

                for (int j = 0; j < h; j++)
                {
                    if (j < h - 4)
                        selectedTile = Stone;
                    else
                    {
                        selectedTile = Grass;
                    }

                    GameObject newTile = Instantiate(selectedTile, Vector3.zero, Quaternion.identity) as GameObject;
                    newTile.transform.parent = this.gameObject.transform;
                    newTile.transform.localPosition = new Vector3(i, j);
                }
            }
        }
    }
}
