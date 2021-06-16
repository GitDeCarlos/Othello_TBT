using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector2 position;
    private Piece piece = null;

    public GameObject GameManager;
    public GameController Script;
    
    public Tile(Vector2 position)
    {
        this.position = position;
    }

    public bool isVacant()
    {
        if (piece == null)
        {
            return true;
        }
        else return false;
    }
    
    public Piece getPiece()
    {
        return this.piece;
    }
    
    //

    void Awake()
    {
        Script = GameManager.GetComponent<GameController>();
    }

    private void OnMouseDown()
    { Debug.Log("click");
        Script.Place(this.gameObject);
    }
}
