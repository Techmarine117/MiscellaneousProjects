using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBoxCollider : MonoBehaviour
{
    [SerializeField] public float x1;
    [SerializeField] public float y1;
    [SerializeField] public float z1;

    [SerializeField] public float x2;
    [SerializeField] public float y2;
    [SerializeField] public float z2;



    private void Awake()
    {
        MyBoxCollider m_collider = GetComponent<MyBoxCollider>();
        GameObject.FindObjectOfType<MyCollisionHandler>().Colliders.Add(m_collider);
    }

    // Update is called once per frame
    void Update()
    {
        x1 = transform.position.x - transform.localScale.x / 2.0f;
        y1 = transform.position.y + transform.localScale.y / 2.0f;
        z1 = transform.position.z - transform.localScale.z / 2.0f;

        x2 = transform.position.x + transform.localScale.x / 2.0f;
        y2 = transform.position.y - transform.localScale.y / 2.0f;
        z2 = transform.position.z + transform.localScale.z / 2.0f;

    }

    public bool isCollided(MyBoxCollider b2)
    {
        if (b2.x1 < x2 && b2.x2 > x1 &&
            b2.y1 > y2 && b2.y2 < y1 &&
            b2.z1 < z2 && b2.z2 > z1)

        {
            return true;
        }
        return false;
    }

}
