using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astarGrid : MonoBehaviour
{
    [SerializeField] float cellWidth;
    [SerializeField] float cellHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
      
        for (int i = 0; i < cellWidth + 1; i++)
        {
            Gizmos.DrawLine(transform.position + new Vector3(0, 0, i), new Vector3(cellHeight, 0, i));
        }

        for (int i = 0; i < cellHeight + 1; i++)
        {
            Gizmos.DrawLine( transform.position + new Vector3(i, 0, 0), new Vector3(i, 0, cellWidth));
        }

    }
}
