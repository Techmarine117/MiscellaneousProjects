using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathNode 
{
    int Gcost { get; set; }
    int Hcost { get; set; }
    int Fcost
    {
        get
        {
            return Gcost + Hcost;
        }
    }
    public Vector3 worldPositon { get; }

    

   public pathNode(Vector3 worldPositon)
    {
        this.worldPositon = worldPositon;
    }
}
