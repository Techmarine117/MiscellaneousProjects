using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorChangingTool : ScriptableWizard
{
    public Color color;

    [MenuItem("tool/ColorChangingTool")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<ColorChangingTool>("ColorChanger", "Change Color");
    }

    private void OnWizardCreate()
    {
        GameObject[] selected = Selection.gameObjects;
        if (selected.Length > 0)
        {
            foreach (var item in selected)
            {
                if (item.GetComponent<MeshRenderer>())
                {
                    item.GetComponent<MeshRenderer>().material.color = color;
                }
            }
        }

    }
}

