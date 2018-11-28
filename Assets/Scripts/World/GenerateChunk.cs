using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Assets.Scripts.Blocks;
using Assets.Scripts.Blocks.Ores;
using Assets.Scripts.Common;
using Assets.Scripts.Common.Registry;
using Assets.Scripts.Inventory;
using CielaSpike;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.World
{
    class GenerateChunk : MonoBehaviour
    {

        public int width; // The width of a single chunk
        public float heightMultiplier; // The height multipllication of a chunk

        public float smoothness; // How smooth the chunk is
        public int heightAddition;

        [HideInInspector]
        public float seed; // The seed to use with the noise generation

        void Start()
        {
            Generate();
        }

        /// <summary>
        /// Generates the chunk
        /// </summary>
        public void Generate()
        {
            for (int i = 0; i < width; i++)
            {
                // Generates the terrain and sets the height
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
                        Populate(gob);
                }
            }
        }

        /// <summary>
        /// Generates ores in the world
        /// </summary>
        /// <param name="obj">The block to (Possibly) transform into an ore</param>
        public void Populate(GameObject obj)
        {
            Dictionary<string, float>.Enumerator pair = OreSpawn.SpawnChance.GetEnumerator();

            // For every ore in the Dictionary ron the code below
            while (pair.MoveNext())
            {
                float random = Random.Range(0f, 100f); // A random float to check if the selected block is an ore
                
                Type selectedTile = Registry.Instance.BlockRegistry[2].GetComponent<Block>().GetType(); // Gets the type of the Block component

                KeyValuePair<string, float> par = pair.Current; // Copies the KeyValuePair to a temporary instance

                // If random is below the spawn chance the ore will spawn
                if (random <= par.Value)
                {
                    // Adds the ore to the world
                    AddOre(selectedTile, obj.transform.position, par.Key, "Sprites/Blocks/" + par.Key);
                    Destroy(obj);
                }
            }
            pair.Dispose(); // Disposes the IEnumerator
        }

        /// <summary>
        /// Adds a new ore with the specified parameters
        /// </summary>
        /// <param name="selectedTile">The <see cref="Type"/> of the component to add to the <see cref="GameObject"/>.</param>
        /// <param name="pos">The <see cref="Vector3"/> Position to set to the ore.</param>
        /// <param name="unlocalizedName">The unlocalized name of the <see cref="Component"/> (used for files and internal registry's)</param>
        /// <param name="spritePath">The path to the <see cref="GameObject"/>'s <see cref="Texture2D"/>.</param>
        /// <param name="hardness">How hard it is to destroy the <see cref="GameObject"/>.</param>
        private void AddOre(Type selectedTile, Vector3 pos,string unlocalizedName, string spritePath, float hardness = 1.0f)
        {
            GameObject gob = new GameObject(unlocalizedName, selectedTile); // Creates a new GameObject

            gob.transform.rotation = Quaternion.identity; // Sets no rotation

            gob.transform.position = pos; // Copies the parent's position

            // Sets the block's specific properties
            gob.GetComponent<BlockOre>().Hardness = hardness;
            gob.GetComponent<BlockOre>().SetUnlocalizedName(unlocalizedName);
            gob.GetComponent<BlockOre>().SetOreSprite(spritePath);
        }
    }
}
