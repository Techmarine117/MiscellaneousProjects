using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class stateMachine : MonoBehaviour
{
    protected State state;

    public void setState()
    {
      
        
        State = new state;

        //StartCoroutine(routine: State.Start());
    }
}
