using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class UISceneController : MonoBehaviour
{

    [SerializeField] StateController stateController;
    [SerializeField] Manager manager;
    public GameObject xWins;
    public GameObject oWins;
    public GameObject Draw;
    public GameObject  X;
    public GameObject O; 
    public GameObject button;

    // Start is called before the first frame update
    void Awake()
    {
        X.SetActive(false);
        O.SetActive(false);
        oWins.SetActive(false);
        xWins.SetActive(false);
        Draw.SetActive(false);
        button.SetActive(false);
    }

    void Update() 
    {
        PlayTracker();
        VictoryScreen();
        
    }

    void PlayTracker() 
    {
        if (manager.RealPlayer == true)
        {
            X.SetActive(true);
            O.SetActive(false);
        }
        else if (manager.RealPlayer == false)
        {
            X.SetActive(false);
            O.SetActive(true);
        }
        else 
        {
            X.SetActive(false);
            O.SetActive(false);
        }
    }

    void VictoryScreen()
    {
        if (manager.WinCondition == 1)
        {
            xWins.SetActive(true);
            oWins.SetActive(false);
            button.SetActive(true);
        }
        else if (manager.WinCondition == 2)
        {
            oWins.SetActive(true);
            xWins.SetActive(false);
            button.SetActive(true);
        }
        else if (manager.WinCondition == 3)
        {
            oWins.SetActive(false);
            xWins.SetActive(false);
            Draw.SetActive(true);
            button.SetActive(true);

        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

}

