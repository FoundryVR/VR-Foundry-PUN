using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateController : MonoBehaviour
{
    [SerializeField] GameObject X;
    [SerializeField] GameObject O;

    int state = 0; 
    bool xFlag = false;
    bool oFlag = false;
    public int State => state;
    public bool OFlag => oFlag;
    public bool XFlag => xFlag;

    public void SetState(int value)
    {
        state = value; 
        StateControl();
    }

    void StateControl() 
    {
        if (state == 0) 
        {
            X.SetActive(false);
            O.SetActive(false);
        }
        else if (state == 1)
        {
            X.SetActive(true);
            O.SetActive(false);
            xFlag = true;
            Debug.Log("you placed an X");
        }
        else if (state == 2)
        {
            X.SetActive(false);
            O.SetActive(true);
            oFlag = true;
            Debug.Log("you placed an O");
        }
    }

}


