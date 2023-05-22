using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProceduralManager : MonoBehaviour
{
[SerializeField] int Width , Height;
[SerializeField] GameObject R2,B2;
    // Start is called before the first frame update
    void Start()
    {
        generator();
    }

    void generator()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Instantiate(R2, new Vector2(x, y), Quaternion.identity);
            }
            //Instantiate(B2, new Vector2(x, Height), Quaternion.identity);
        }

    }
}
