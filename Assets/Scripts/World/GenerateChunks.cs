using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.World
{
    public class GenerateChunks : MonoBehaviour
    {
        public GameObject chunk;
        private int chunkWidth;
        public int numChunks;
        private float seed;

        void Start()
        {
            chunkWidth = chunk.GetComponent<GenerateChunk>().width;
            seed = Random.Range(-100000, 100000);
            Generate();
        }

        public void Generate()
        {
            int lastX = -chunkWidth;
            for (int i = 0; i < numChunks; i++)
            {
                GameObject newChunk = Instantiate(chunk, new Vector3(lastX, chunkWidth, 0f), Quaternion.identity) as GameObject;
                newChunk.GetComponent<GenerateChunk>().seed = seed;
                lastX += chunkWidth;
            }
        }
    }
}
