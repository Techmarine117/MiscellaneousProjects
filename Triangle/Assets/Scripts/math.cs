using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class math : MonoBehaviour
{
    [SerializeField] GameObject sphere;
    [SerializeField] float angle, height,radius;
    [SerializeField] float angleIncrement, heightIncrement;
    [SerializeField] int maximumObj;
    [SerializeField] List<GameObject> ObjectList;

    // Start is called before the first frame update
    void Start()
    {
        ObjectList = new List<GameObject>(maximumObj);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 pos = new Vector3();

            pos.x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            pos.y = height;
            pos.z = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

            ObjectList.Add(Instantiate(sphere, pos, Quaternion.identity));

            if (ObjectList.Count >= maximumObj)
            {
                Destroy(ObjectList[0]);
                ObjectList.RemoveAt(0); 
            }
            angle += angleIncrement;
            height += heightIncrement;
        }
    }
}
