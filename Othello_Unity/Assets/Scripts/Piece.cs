using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private bool marker;
    
    public Piece(bool marker)
    {
        this.marker = marker;
    }

    public bool getMarker()
    {
        return this.marker;
    }

    public void flipMarker()
    {
        this.marker = !this.marker;
    }
}
