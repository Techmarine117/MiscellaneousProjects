using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialController : MonoBehaviour
{
    public GameObject BattlefieldObject;
    public Unit unitPrefab;
    public Transform unitParentTrans;

    private Grid grid;
    private HashSet<Unit> allUnits = new HashSet<Unit>();
    [SerializeField] const int NumberOfUnits = 60;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid();
        float BattleFieldWidth = Grid.NumOfCells * Grid.CellSize;

        BattlefieldObject.transform.localScale = new Vector3(BattleFieldWidth, 1f, BattleFieldWidth);
        BattlefieldObject.transform.position = new Vector3(BattleFieldWidth * 0.5f, -1f, BattleFieldWidth * 0.5f);

        for(int i = 0; i < NumberOfUnits; i++)
        {
            float randomX = Random.Range(0f, BattleFieldWidth);
            float randomZ = Random.Range(0f, BattleFieldWidth);

            Vector3 randomPos = new Vector3(randomX, 0f, randomZ);
            Unit newUnit = Instantiate(unitPrefab, parent: unitParentTrans) as Unit;

              newUnit.InitUnits(grid, randomPos);
                allUnits.Add(newUnit);
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Unit unit in allUnits)
        {
            unit.Move(Time.deltaTime);
        }

        grid.HandleMelee();
    }
}
