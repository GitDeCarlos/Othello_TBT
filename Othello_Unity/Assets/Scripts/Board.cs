using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[,] grid = new GameObject[8,8];
    public GameObject tile;

    private TextureController tc;
    
    public void Start()
    {
        tc = FindObjectOfType<TextureController>();

        string FilePath = tc.getFilePath();
        Sprite bg_board = tc.LoadNewSprite(FilePath);
        
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                grid[i, j] = Instantiate(tile, gameObject.transform);
                grid[i, j].GetComponent<RectTransform>().anchoredPosition = new Vector3(64*i +32, -64*j -32, 0);
                //Debug.Log("New Tile: " + i + ", " + j);
            }
        }
    }

}
