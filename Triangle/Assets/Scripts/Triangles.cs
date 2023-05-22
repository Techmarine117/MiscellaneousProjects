using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangles : MonoBehaviour
{
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;
    [SerializeField] Material mat;
    [SerializeField] int cellsX, cellsY;
    [SerializeField] int verticesX,verticesY,totalVertices,totalIndecies,indeciesX,indeciesY;
    [SerializeField] Texture2D heightTexture;
    [SerializeField] float heightMapStrength;
    // Start is called before the first frame update
    void Start()
    {
        verticesX = cellsX + 1;
        verticesY = cellsY + 1;
        totalVertices = verticesX * verticesY;

        indeciesX = cellsX * 6;
        indeciesY = cellsY * 6;
        totalIndecies = indeciesX * indeciesY;

        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = mat;

        //meshFilter.mesh.vertices = new Vector3[]
        //{
        //    new Vector3(-1f,1f,0),
        //    new Vector3(1f,1f,0),
        //    new Vector3(1f,-1f,0),
        //    new Vector3(-1,-1,0),
        //    new Vector3(3,1,0),
        //    new Vector3(3,-1,0)
        //};

        List<Vector3> vertices = new List<Vector3>();
        for (int x = 0; x < verticesX; x++)
        {
            for (int y = 0; y < verticesY; y++)
            {
                float normalizedX = (float)x / (float)verticesX * (float)heightTexture.width;
                float normalizedY = (float)y / (float)verticesY * (float)heightTexture.height;
                float Y = heightTexture.GetPixel((int)normalizedX, (int)normalizedY).r * heightMapStrength;

                vertices.Add(new Vector3(normalizedX, Y, normalizedY));
            }
        }
       


        List<int> Indecies = new List<int>();
        
        
        int index = 0;
        for (int x = 0; x < indeciesX ; x+=6)
        {
            for (int y = 0; y < indeciesY ; y += 6)
            {
                Indecies.Add(index);
                Indecies.Add(index  +1);
                Indecies.Add(index + verticesY);

                Indecies.Add(index + 1);
                Indecies.Add(index + 1 + verticesY);
                Indecies.Add(index + verticesY);

                //Indecies[i + 0] = index;
                //Indecies[i + 1] = index + verticesX;
                //Indecies[i + 2] = index + verticesX + 1;

                //Indecies[i + 3] = index + verticesX + 1;
                //Indecies[i + 4] = index + 1;
                //Indecies[i + 5] = index;

                index++;
            }
            index++;
        }
        Debug.Log(Indecies.Count);
        meshFilter.mesh.vertices = vertices.ToArray();
        meshFilter.mesh.triangles = Indecies.ToArray();

        
        //meshFilter.mesh.triangles = new int[]
        //{
        //    0,
        //    1,
        //    2,

        //    2,
        //    3,
        //    0,

        //    1,
        //    4,
        //    5,

        //    5,
        //    2,
        //    1,
        //};


    }
}