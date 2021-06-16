using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject p1_tile;
    public GameObject p2_tile;
    public GameObject[,] gameboard = new GameObject[8,8];

    int turn = 0;
    public List<int> availableFields = new List<int>(64);

    public OthelloAgent Agent1;
    public OthelloAgent Agent2;

    public bool PlayerChanged = true;

    // UI related variables
    public GameObject canvas;
    public GameObject board;

    public enum Player
    {
        EMPTY,
        WHITE,
        BLACK
    };

    public Player Turn;

    public GameObject p1;
    public GameObject p2;

    // Start is called before the first frame update
    void Start(){

        // Create prefab from textures
        
        // Instantiate board

        //Placing the starting 4 pieces
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (PlayerChanged)
        {
            PlayerChanged = false;
           // GetCurrentAgent().RequestDecision();
        }
    }

    /*private OthelloAgent GetCurrentAgent()
    {
        if (currentPlayer == Agent1.type) return Agent1;
        else return Agent2;
    }

    private OthelloAgent GetAgentOfType(Player type)
    {
        if (Agent1.type == type) return Agent1;
        else return Agent2;
    }*/
    private List<int> RemoveAvailable(List<int> available, int x, int y)
    {
        int count = 0;
       for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (y == i && x == j)
                {
                    available.RemoveAt(count);
                }
                count++;
            }
        }

        return available;
    }
    /*
    public void AssignRewardsOnWin(WinState winState)
    {
        if (winState == WinState.CrossWin)
        {
            GetAgentOfType(Player.X).SetReward(1f);
            GetAgentOfType(Player.O).SetReward(-1f);
        }
        else if (winState == WinState.NoughtWin)
        {
            GetAgentOfType(Player.O).SetReward(1f);
            GetAgentOfType(Player.X).SetReward(-1f);
        }
        else if (winState == WinState.Draw)
        {
            if (_board._fieldsOccupiedO > _board._fieldsOccupiedX)
            {
                GetAgentOfType(Player.O).SetReward(-0.25f);
                GetAgentOfType(Player.X).SetReward(0.75f);
            }
            else
            {
                GetAgentOfType(Player.O).SetReward(0.75f);
                GetAgentOfType(Player.X).SetReward(-0.25f);
            }
        }
    }
    */

    public IEnumerable<int> GetAvailableFields()
    {
        return availableFields.ToArray();
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
    
    //

    public void Place(GameObject tile)
    {
        if (Turn == Player.BLACK)
        {
            Instantiate(p1_tile, tile.transform.position, Quaternion.identity);
            Turn = Player.WHITE;
        }
        else
        {
            Instantiate(p2_tile, tile.transform.position, Quaternion.identity);
            Turn = Player.BLACK;
        }
    }
}
