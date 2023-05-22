using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public GameObject unitObj;
    private Grid grid;

    [System.NonSerialized] public Unit prev;
    [System.NonSerialized] public Unit next;

    private MeshRenderer MeshRenderer;
    private Color unitColor;
    private float unitSpeed;

    [SerializeField] public const float AttackDistance = 1.0f;

    public void InitUnits(Grid grid, Vector3 startPos)
    {
        this.grid = grid;
        transform.position = startPos;
        prev = null;
        next = null;

        grid.Add(this, isNewUnit: true);
        MeshRenderer = unitObj.GetComponent<MeshRenderer>();

        unitColor = Color.white;
        MeshRenderer.material.color = unitColor;

        unitSpeed = Random.Range(1f, 5f);
        transform.rotation = GetRandomDirection();
    }

    public void Move(float dt)
    {
        Vector3 oldPos = transform.position;
        Vector3 newPos = oldPos + transform.forward * unitSpeed * dt;
        bool isValid = grid.IsPosValid(newPos);

        if (isValid)
        {
            transform.position = newPos;
            grid.Move(this, oldPos, newPos);
        }
        else
        {
            transform.rotation = GetRandomDirection();
        }
    }

    private Quaternion GetRandomDirection()
    {
        Quaternion randomDir = Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));

        return randomDir;
    }

    public void StartFighting()
    {
        StopCoroutine(fightCooldown());
        StartCoroutine(fightCooldown());
    }

    private IEnumerator fightCooldown()
    {
        MeshRenderer.sharedMaterial.color = Color.red;
        Debug.Log("color");
        yield return new WaitForSeconds(1f);

        MeshRenderer.sharedMaterial.color = unitColor;
    }
}
