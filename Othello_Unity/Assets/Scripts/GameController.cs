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
        
        for(int y = 0; y < 8; y++){
            for(int x = 0; x < 8; x++){
                float pos_y = ((y+1)*0.1f) + y + 1;
                float pos_x = ((x+1)*0.1f) + x + 1;
                gameboard[y,x] = Instantiate(buttonPre, new Vector3(pos_x,pos_y, -0.5f), Quaternion.identity);
            }
        }

        Destroy(gameboard[4,4]);
        gameboard[4,4] = Instantiate(p1_tile, new Vector3(5.5f, 5.5f, -0.5f), Quaternion.identity);
        Destroy(gameboard[3,3]);
        gameboard[3,3] = Instantiate(p1_tile, new Vector3(4.4f, 4.4f, -0.5f), Quaternion.identity);
        Destroy(gameboard[3,4]);
        gameboard[3,4] = Instantiate(p2_tile, new Vector3(4.4f, 5.5f, -0.5f), Quaternion.identity);
        Destroy(gameboard[4,3]);
        gameboard[4,3] = Instantiate(p2_tile, new Vector3(5.5f, 4.4f, -0.5f), Quaternion.identity);     
    }

    // Update is called once per frame
    void Update(){
        
    }

    //Flips a tile and returns new gameobject to reference
    GameObject flip(GameObject curr){
        GameObject newTile;
        if(turn%2 == 0){
            newTile = p1_tile;
        }
        else{
            newTile = p2_tile;
        }

        Vector3 pos = curr.transform.position;
        Debug.Log("pos: " + pos);
        Destroy(curr);
        GameObject temp = Instantiate(newTile, pos, Quaternion.identity);
        return temp;
    }
}