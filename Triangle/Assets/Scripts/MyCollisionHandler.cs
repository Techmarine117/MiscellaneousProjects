using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollisionHandler : MonoBehaviour
{
    [SerializeField]public List<MyBoxCollider> Colliders;

    // Update is called once per frame
    void Update()
    {
        foreach (var item in Colliders)
        {
            foreach (var collider in Colliders)
            {
                if (item != collider)
                {
                    if (item.isCollided(collider))
                    {
                        Debug.Log(item.name + "Collided with " + collider.name);
                        Destroy(item.gameObject);
                        Colliders.Remove(item);
                        Destroy(collider.gameObject);
                        Colliders.Remove(collider);
                        return;
                    }
                }   
            }
        }
    }
}
