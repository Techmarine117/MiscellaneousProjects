using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar : MonoBehaviour
{
    [SerializeField] astarGrid grid;
    [SerializeField] Vector2Int _startNode;
    [SerializeField] Vector2Int _goalNode;

    pathNode startNode;
    pathNode goalNode;
    void Start()
    {
        int i = -1;

        i = grid.Convert2DToIndex(_startNode.x, _startNode.y);
        startNode = grid.nodes[i];

        i = grid.Convert2DToIndex(_goalNode.x, _goalNode.y);
        goalNode = grid.nodes[i];
    }

    if(currentNode.gridzPosition.x - 1 >= 0)
        {
             
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
