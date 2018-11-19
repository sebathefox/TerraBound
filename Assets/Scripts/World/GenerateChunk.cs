using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Blocks;
using Assets.Scripts.Blocks.Ores;
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
                        selectedTile = Block.blocks[1];
                    // Places stone
                    else
                    {
                        selectedTile = Block.blocks[0];
                    }
                    

                    GameObject gob = new GameObject();
                    gob.AddComponent(selectedTile);
                    gob.AddComponent<TileData>().tileType = Block.blocks.IndexOf(selectedTile);

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
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("TileStone"))
            {
                float random = Random.Range(0f, 100f);
                Type selectedTile = null;

                if (random <= BlockIron.NaturalSpawnChance)
                {

                    selectedTile = Block.blocks[2];

                }
                else if (random <= BlockIron.NaturalSpawnChance)
                {

                    selectedTile = Block.blocks[2];

                }
                
                if (selectedTile != null)
                {
                    AddBlock(selectedTile, o.transform.position.x, o.transform.position.y);
                    Destroy(o);
                }
            }
        }

        private void AddBlock(Type selectedTile, float i, float j)
        {
            GameObject gob = new GameObject();
            gob.AddComponent<TileData>().tileType = Block.blocks.IndexOf(selectedTile);
            gob.AddComponent(selectedTile);

            gob.transform.rotation = Quaternion.identity;
            gob.transform.position = Vector3.zero;
            
            gob.transform.position = new Vector3(i, j);

            if (selectedTile == typeof(BlockStone))
                gob.tag = "TileStone";
        }
    }
}
