using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector2 position;
    private Piece piece = null;
    
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

    public void addPieceToTile(bool marker)
    {
        // Instantiate piece @ C(this.position)
        
        // this.piece = instantiated piece.getComponent<Piece>;
    }
}
