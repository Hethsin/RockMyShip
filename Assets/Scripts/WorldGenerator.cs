using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

    private Transform newChunk;
    public int layerNum;

    public void GenerateWorld()  //Generate layers of chunks.
    {
        int chunkNum = 8;  //Number of chunks on first layer
        Vector3 centrePos = new Vector3(0, 0, 0);
        for (int h = 0; h < layerNum; h++)
        {
            for (float pointNum = 0; pointNum < chunkNum * h; pointNum++)  //Instantiate in a circle
            {
                float i = pointNum / (chunkNum * h);
                float angle = i * Mathf.PI * 2;
                float x = Mathf.Sin(angle) * h;
                float y = Mathf.Cos(angle) * h;
                Vector3 pos = new Vector3(x, y, 0) + centrePos;
                newChunk = Instantiate(GameControl.control.chunk, pos, Quaternion.identity);
                newChunk.SetParent(GameControl.control.world);
            }
        }
    }
}
