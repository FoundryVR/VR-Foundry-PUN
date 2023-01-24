using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public StateController[] boardSpaces;
    GameObject selectedObject;

    [SerializeField] AIStateController aiStateController;

    //static char[] array = {'0', '1', '2','3','4','5','6','7','8','9'}; 
    static int player = 1;
    bool realPlayer = true;
    public int Player => player;

    static int winCondition = 0;
    public int WinCondition => winCondition;
    public bool RealPlayer => realPlayer;

    void Awake() 
    {
        winCondition = 0;
        for(int i=0; i<boardSpaces.Length;i++) {
            boardSpaces[i].SetState(0);
        }

        realPlayer = true;

    }
    void Update() 
    {
        PlayerSelectMove();
    }

    void PlayerSelectMove()
    {
        if(winCondition != 0) 
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && realPlayer == true) 
        {
            Ray pointer = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(pointer.origin, pointer.direction * 100, Color.red, 20f);
            RaycastHit hit;
            if (Physics.Raycast(pointer, out hit)) 
            {
                selectedObject = hit.transform.gameObject;
                Debug.Log(selectedObject.name); 
                PlayerAlternator();
                XWinConditions();
                OWinConditions();
                if (IsDraw()) 
                {
                    winCondition = 3;
                }
            }
        }
    }

    void AISelectMove() 
    {
        if (realPlayer == false) 
        {
            aiStateController.DetermineMark();
            PlayerAlternator();
        }
    }

/////////////////////////////SWITCH TURNS FUNCTION///////////////////////////////////////////
    // void SwitchTurns() 
       
    // {
    //     if(player == 1)
    //     {
    //         realPlayer = true;
    //         for(int i=0; i<boardSpaces.Length;i++) 
    //         {
    //             if(boardSpaces[i].gameObject.name == selectedObject.name && boardSpaces[i].State == 0) 
    //             {
    //                 boardSpaces[i].SetState(1);
    //             }
    //         }
    //         player ++;
    //     }
    //     else if(player == 2) {
    //         realPlayer = false;
    //         for(int i=0; i<boardSpaces.Length;i++)
    //         {
    //             if(boardSpaces[i].gameObject.name == selectedObject.name && boardSpaces[i].State == 0)
    //             {
    //                 boardSpaces[i].SetState(2);
    //             }
    //         }
    //         player --;
    //     }
    // }
    void PlayerAlternator() 
    {
        if(realPlayer == true) 
        {
            for(int i=0; i<boardSpaces.Length;i++) 
            {
                if(boardSpaces[i].gameObject.name == selectedObject.name && boardSpaces[i].State == 0) 
                {
                    boardSpaces[i].SetState(1);
                }
            }
            realPlayer = false;
        }
        else if(realPlayer == false)
        {
            aiStateController.DetermineMark();
        }

    }

    void XWinConditions()
    {
        if(boardSpaces[0].XFlag == true && boardSpaces[3].XFlag == true && boardSpaces[6].XFlag == true) 
        {
            Debug.Log("X Wins");
            winCondition = 1;
        }
         else if(boardSpaces[1].XFlag == true && boardSpaces[4].XFlag == true && boardSpaces[7].XFlag == true) 
        {
            Debug.Log("X Wins");
            winCondition = 1;

        }
         else if(boardSpaces[2].XFlag == true && boardSpaces[5].XFlag == true && boardSpaces[8].XFlag == true) 
        {
            Debug.Log("X Wins");
            winCondition = 1;

        }
         else if(boardSpaces[0].XFlag == true && boardSpaces[1].XFlag == true && boardSpaces[2].XFlag == true) 
        {
            Debug.Log("X Wins");
            winCondition = 1;

        }
         else if(boardSpaces[3].XFlag == true && boardSpaces[4].XFlag == true && boardSpaces[5].XFlag == true) 
        {
            Debug.Log("X Wins");
            winCondition = 1;

        }
         else if(boardSpaces[6].XFlag == true && boardSpaces[7].XFlag == true && boardSpaces[8].XFlag == true) 
        {
            Debug.Log("X Wins");
            winCondition = 1;

        }
         else if(boardSpaces[0].XFlag == true && boardSpaces[4].XFlag == true && boardSpaces[8].XFlag == true) 
        {
            Debug.Log("X Wins");
            winCondition = 1;

        }
         else if(boardSpaces[2].XFlag == true && boardSpaces[4].XFlag == true && boardSpaces[6].XFlag == true) 
        {
            Debug.Log("X Wins");
            winCondition = 1;

        }
    }

    void OWinConditions()
    {
        if(boardSpaces[0].OFlag == true && boardSpaces[3].OFlag == true && boardSpaces[6].OFlag == true) 
        {
            Debug.Log("O Wins");
            winCondition = 2;

        }
         else if(boardSpaces[1].OFlag == true && boardSpaces[4].OFlag == true && boardSpaces[7].OFlag == true) 
        {
            Debug.Log("O Wins");
            winCondition = 2;
        }
         else if(boardSpaces[2].OFlag == true && boardSpaces[5].OFlag == true && boardSpaces[8].OFlag == true) 
        {
            Debug.Log("O Wins");
            winCondition = 2;
        }
         else if(boardSpaces[0].OFlag == true && boardSpaces[1].OFlag == true && boardSpaces[2].OFlag == true) 
        {
            Debug.Log("O Wins");
            winCondition = 2;
        }
         else if(boardSpaces[3].OFlag == true && boardSpaces[4].OFlag == true && boardSpaces[5].OFlag == true) 
        {
            Debug.Log("O Wins");
            winCondition = 2;
        }
         else if(boardSpaces[6].OFlag == true && boardSpaces[7].OFlag == true && boardSpaces[8].OFlag == true) 
        {
            Debug.Log("O Wins");
            winCondition = 2;
        }
         else if(boardSpaces[0].OFlag == true && boardSpaces[4].OFlag == true && boardSpaces[8].OFlag == true) 
        {
            Debug.Log("O Wins");
            winCondition = 2;
        }
         else if(boardSpaces[2].OFlag == true && boardSpaces[4].OFlag == true && boardSpaces[6].OFlag == true) 
        {
            Debug.Log("O Wins");
            winCondition = 2;
           
        }
    }

    bool IsDraw() 
    {
        foreach(StateController space in boardSpaces)
        {
            if(space.State == 0)
            {
                return false;
            }
        }
        if(winCondition != 0)
        {
            return false;
        }
        return true;
    }



}


