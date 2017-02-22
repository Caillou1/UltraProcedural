using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour {
    public float tileSize;

    private Terrain terrain;
    
    void Start()
    {
        terrain = GetComponent<Terrain>();
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            Generate();
        }
    }

    void Generate()
    {
        float[,] heights = new float[terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight];

        for (int i = 0; i < terrain.terrainData.heightmapWidth; i++)
        {
            for (int k = 0; k < terrain.terrainData.heightmapHeight; k++)
            {
                heights[i, k] = Mathf.PerlinNoise(((float)i / (float)terrain.terrainData.heightmapWidth) * tileSize, ((float)k / (float)terrain.terrainData.heightmapHeight) * tileSize) / 10.0f;
            }
        }

        terrain.terrainData.SetHeights(0, 0, heights);
    }
}
