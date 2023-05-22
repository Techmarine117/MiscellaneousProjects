using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public const int NumOfCells = 10;
    public const int CellSize = 5;

    private Unit[,] cells = new Unit[NumOfCells, NumOfCells];

    public int UnitCount { get; private set; }

    public Grid()
    {
        for (int x = 0; x < NumOfCells; x++)
        {
            for (int y = 0; y < NumOfCells; y++)
            {
                cells[x, y] = null;
            }
        }
    }

    public void Add(Unit newUnits, bool isNewUnit = false)
    {
        Vector2Int CellPositon = ConvertFromWorld_ToCell(newUnits.transform.position);

        newUnits.prev = null;
        newUnits.next = cells[CellPositon.x, CellPositon.y];

        cells[CellPositon.x, CellPositon.y] = newUnits;

        if (newUnits.next != null)
        {
            Unit nextUnit = newUnits.next;
            nextUnit.prev = newUnits;
        }

        if (isNewUnit)
        {
            UnitCount += 1;
        }
    }

    public void Move(Unit unit, Vector3 oldPos, Vector3 newPos)
    {
        Vector2Int oldCellPositon = ConvertFromWorld_ToCell(oldPos);
        Vector2Int newCellPositon = ConvertFromWorld_ToCell(newPos);

        if (oldCellPositon.x == newCellPositon.x && oldCellPositon.y == newCellPositon.y)
        {
            return;
        }

        Unlink(unit);

        if (cells[oldCellPositon.x, oldCellPositon.y] == unit)
        {
            cells[oldCellPositon.x, oldCellPositon.y] = unit.next;
        }

        Add(unit);

    }

    private void Unlink(Unit unit)
    {
        if (unit.prev != null)
        {
            unit.prev.next = unit.next;
        }

        if (unit.next != null)
        {
            unit.next.prev = unit.prev;
        }
    }

    public Vector2Int ConvertFromWorld_ToCell(Vector3 pos)
    {
        int CellY = Mathf.FloorToInt(pos.z / CellSize);
        int CellX = Mathf.FloorToInt(pos.x / CellSize);
        Vector2Int CellPositon = new Vector2Int(CellX, CellY);
        return CellPositon;
    }

    public bool IsPosValid(Vector3 pos)
    {
        Vector2Int CellPositon = ConvertFromWorld_ToCell(pos);
        if (CellPositon.x >= 0 && CellPositon.x < NumOfCells && CellPositon.y >= 0 && CellPositon.y < NumOfCells)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void HandleMelee()
    {
        for (int x = 0; x < NumOfCells; x++)
        {
            for (int y = 0; y < NumOfCells; y++)
            {
                Handle(x, y);
            }
        }
    }

    private void Handle(int x, int y)
    {
        Unit unit = cells[x, y];

        while (unit != null)
        {
            HandleUnits(unit, unit.next);

            if (x > 0 && y > 0)
            {
                HandleUnits(unit, cells[x - 1, y - 1]);
            }
            if (x > 0)
            {
                HandleUnits(unit, cells[x - 1, y - 0]);
            }
            if (y > 0)
            {
                HandleUnits(unit, cells[x - 0, y - 1]);
            }
            if (x > 0 && y < NumOfCells - 1)
            {
                HandleUnits(unit, cells[x - 1, y + 1]);
            }

            unit = unit.next;
        }
    }

    private void HandleUnits(Unit unit, Unit unit1)
    {
        while (unit1 != null)
        {
            if ((unit.transform.position - unit1.transform.position).sqrMagnitude < Unit.AttackDistance * Unit.AttackDistance)
            {
                HandleAttack(unit, unit1);
            }
            unit1 = unit1.next;
        }
    }

    private void HandleAttack(Unit one, Unit two)
    {
        one.StartFighting();
        two.StartFighting();
    }
}
