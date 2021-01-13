using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject buttonPre;
    public GameObject p1_tile;
    public GameObject p2_tile;

    // Start is called before the first frame update
    void Start(){
        //Board is in [y,x] format
        public GameObject[,] board;
        board = new GameObject[8,8];
        for(int y = 0; y < 8; y++){
            for(int x = 0; x < 8; x++){
                board[y,x] = buttonPre;
                pos = 
                Instatiate(board[y,x], new Vector3())

            }
        }
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
