using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public virtual mainMenu Screen()
    {
        yield break;
    }
}
