using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    W,
    B
}
public class GameController : MonoBehaviour
{
    public GameObject buttonPre;
    public GameObject board;
    public GameObject p1_tile;
    public GameObject p2_tile;
    public GameObject[,] gameboard = new GameObject[8,8];

    int turn = 0;
    public List<int> availableFields = new List<int>(64);

    public OthelloAgent Agent1;
    public OthelloAgent Agent2;

    public bool PlayerChanged = true;
    public Player currentPlayer;
    public Player player;

    // Start is called before the first frame update
    void Start(){

        // Create prefab from textures

        /*
        //Board is in [y,x] format
        Instantiate(board, new Vector3(5,5,0), Quaternion.identity);

        PlayerChanged = true;

        Instantiate(board, new Vector3(5,5,0), Quaternion.identity);
        int counter = 0;

        for(int y = 0; y < 8; y++){
            for (int x = 0; x < 8; x++)
            {
                float pos_y = ((y + 1) * 0.1f) + y + 1;
                float pos_x = ((x + 1) * 0.1f) + x + 1;
                gameboard[y, x] = Instantiate(buttonPre, new Vector3(pos_x, pos_y, -0.5f), Quaternion.identity);
                availableFields.Add(counter);
                counter++;
            }
        }


        //Placing the starting 4 pieces
        Destroy(gameboard[4,4]);
        RemoveAvailable(availableFields, 4, 4);
        gameboard[4,4] = Instantiate(p1_tile, new Vector3(5.5f, 5.5f, -0.5f), Quaternion.identity);
        Destroy(gameboard[3,3]);
        RemoveAvailable(availableFields, 3, 3);
        gameboard[3,3] = Instantiate(p1_tile, new Vector3(4.4f, 4.4f, -0.5f), Quaternion.identity);
        Destroy(gameboard[3,4]);
        RemoveAvailable(availableFields, 3, 4);
        gameboard[3,4] = Instantiate(p2_tile, new Vector3(4.4f, 5.5f, -0.5f), Quaternion.identity);
        Destroy(gameboard[4,3]);
        gameboard[4,3] = Instantiate(p2_tile, new Vector3(5.5f, 4.4f, -0.5f), Quaternion.identity);

        gameboard[2,2] = flip(gameboard[2,2]);
        RemoveAvailable(availableFields, 4, 3);
        gameboard[4,3] = Instantiate(p2_tile, new Vector3(5.5f, 4.4f, -0.5f), Quaternion.identity);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (PlayerChanged)
        {
            PlayerChanged = false;
            GetCurrentAgent().RequestDecision();
        }
    }

    public void ChangePlayer()
    {
            currentPlayer = currentPlayer == Player.B ? Player.W : Player.B;
            PlayerChanged = true;
    }


    private OthelloAgent GetCurrentAgent()
    {
        if (currentPlayer == Agent1.type) return Agent1;
        else return Agent2;
    }

    private OthelloAgent GetAgentOfType(Player type)
    {
        if (Agent1.type == type) return Agent1;
        else return Agent2;
    }
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
}
