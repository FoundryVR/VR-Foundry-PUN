using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateController : MonoBehaviour
{
    [SerializeField] StateController stateController;
    [SerializeField] Manager manager;
    // Start is called before the first frame update

    public void DetermineMark()
    {
        Debug.Log("AI is thinking");
        if(manager.boardSpaces[4].OFlag == false && manager.boardSpaces[4].XFlag == false) {
            manager.boardSpaces[4].SetState(2);
            Debug.Log("AI is thinking");
        }
    }
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}

