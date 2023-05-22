using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frank;

public class Test : MonoBehaviour
{
    public GameObject UnitObject;
    public Transform UnitParent;
    public GameObject Battlefield;
    public int NumberofUnits = 40;
    public Frank.Unit UnitPrefab;



    Frank.Grid greed = new Frank.Grid();
    Frank.SpatialController spatialController = new Frank.SpatialController();
    private HashSet<Frank.Unit> allUnits = new HashSet<Frank.Unit>();
    // Start is called before the first frame update
    void Start()
    {
        spatialController.grid = greed;
        spatialController.Initialize(Battlefield, UnitPrefab, UnitParent, NumberofUnits); 
    }

    public static void ChangeMaterialColor(MeshRenderer renderer, Color color)
    {
        renderer.sharedMaterial.color = color;
    }
    // Update is called once per frame
    void Update()
    {
        spatialController.Run();
    }
}
