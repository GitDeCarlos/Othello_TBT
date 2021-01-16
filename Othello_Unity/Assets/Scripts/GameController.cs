using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject buttonPre;
    public GameObject board;
    public GameObject p1_tile;
    public GameObject p2_tile;
    public GameObject[,] gameboard = new GameObject[8,8];
    
    int turn = 0;

    // Start is called before the first frame update
    void Start(){

        //Board is in [y,x] format
        Instantiate(board, new Vector3(5,5,0), Quaternion.identity);
        
        //Creating the board
        for(int y = 0; y < 8; y++){
            for(int x = 0; x < 8; x++){
                float pos_y = ((y+1)*0.1f) + y + 1;
                float pos_x = ((x+1)*0.1f) + x + 1;
                gameboard[y,x] = Instantiate(buttonPre, new Vector3(pos_x,pos_y, -0.5f), Quaternion.identity);
            }
        }


        //Placing the starting 4 pieces 
        Destroy(gameboard[4,4]);
        gameboard[4,4] = Instantiate(p1_tile, new Vector3(5.5f, 5.5f, -0.5f), Quaternion.identity);
        Destroy(gameboard[3,3]);
        gameboard[3,3] = Instantiate(p1_tile, new Vector3(4.4f, 4.4f, -0.5f), Quaternion.identity);
        Destroy(gameboard[3,4]);
        gameboard[3,4] = Instantiate(p2_tile, new Vector3(4.4f, 5.5f, -0.5f), Quaternion.identity);
        Destroy(gameboard[4,3]);
        gameboard[4,3] = Instantiate(p2_tile, new Vector3(5.5f, 4.4f, -0.5f), Quaternion.identity);

        gameboard[2,2] = flip(gameboard[2,2]);
    }

    // Update is called once per frame
    void Update(){
        
    }

    GameObject tileOnTurn(){
        GameObject newTile;

        //Determines which tile to place
        if(turn%2 == 0){
            newTile = p1_tile;
        }
        else{
            newTile = p2_tile;
        }

        return newTile;
    }

    GameObject place(GameObject curr){
        GameObject newTile = tileOnTurn();

        //Replaces the original tile with the new tile
        Vector3 pos = curr.transform.position;
        Destroy(curr);
        GameObject temp = Instantiate(newTile, pos, Quaternion.identity);
        return temp;
    }

    //Flips a tile and returns new gameobject to reference
    //Note- is flip needed? With how place works, it may not be.
    GameObject flip(GameObject curr){
        GameObject newTile;
        newTile = tileOnTurn();

        if(curr.tag != "Tile"){
            GameObject temp = place(curr);
            return temp;
        }
        Debug.Log("Oopsie");
        return null;
    }
}