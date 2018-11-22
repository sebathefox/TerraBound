using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Blocks;
using Assets.Scripts.Blocks.Ores;
using Assets.Scripts.Common;
using Assets.Scripts.Common.Registry;
using Assets.Scripts.Inventory;
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

        [HideInInspector]
        public float seed;

        void Start()
        {
            Block.InitBlocks();
            Generate();
        }

        public void Generate()
        {
            for (int i = 0; i < width; i++)
            {
                int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, (i + transform.position.x) / smoothness) * heightMultiplier) + heightAddition;
                Type selectedTile;

                for (int j = 0; j < h; j++)
                {
                    // Places grass at the four highest positions
                    if (j < h - 4)
                        selectedTile = Registry.Instance.BlockRegistry[1].GetComponent<Block>().GetType();
                    // Places stone
                    else
                    {
                        selectedTile = Registry.Instance.BlockRegistry[0].GetComponent<Block>().GetType();
                    }
                    

                    GameObject gob = new GameObject();
                    gob.AddComponent(selectedTile);

                    gob.transform.rotation = Quaternion.identity;
                    gob.transform.position = Vector3.zero;

                    gob.transform.parent = this.gameObject.transform;
                    gob.transform.localPosition = new Vector3(i, j);

                    if (selectedTile == typeof(BlockStone))
                        gob.tag = "TileStone";
                }
            }
            Populate();
        }

        public void Populate()
        {
            Dictionary<string, float>.Enumerator pair = OreSpawn.SpawnChance.GetEnumerator();

            while (pair.MoveNext())
            {
                foreach (GameObject o in GameObject.FindGameObjectsWithTag("TileStone"))
                {
                    

                    float random = Random.Range(0f, 100f);
                    Type selectedTile = Registry.Instance.BlockRegistry[2].GetComponent<Block>().GetType();

                    GameObject ore = new GameObject("tmp", typeof(BlockOre));

                    
                        KeyValuePair<string, float> par = pair.Current;
                        if (random <= par.Value)
                            AddOre(selectedTile, o.transform.position, par.Key, "Sprites/Blocks/" + par.Key);
                    Destroy(ore);
                }
            }
            pair.Dispose();
        }

        private void AddOre(Type selectedTile, Vector3 pos,string unlocalizedName, string spritePath, float hardness = 1.0f)
        {
            GameObject gob = new GameObject("Ore", selectedTile);

            gob.transform.rotation = Quaternion.identity;
            gob.transform.position = Vector3.zero;

            gob.transform.position = pos;

            gob.GetComponent<BlockOre>().Hardness = hardness;
            gob.GetComponent<BlockOre>().SetUnlocalizedName(unlocalizedName);
            gob.GetComponent<BlockOre>().SetOreSprite(spritePath);
        }
    }
}
