using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Tile[,] grid;
    private bool turn;

    private static int GSIZE = 8;
    
    public Board()
    {
        this.grid = new Tile[GSIZE,GSIZE];

        for (int i = 0; i < GSIZE; i++)
        {
            for (int j = 0; j < GSIZE; j++)
            {
                // Instantiate Tile(new Vector2(i, j)) @ position C(i, j);
                Debug.Log("New Tile: " + i + ", " + j);
            }
        }
        
    }
}
