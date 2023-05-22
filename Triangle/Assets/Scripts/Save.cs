using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Data
{
    public int number = 23;
    public string name = "Brendan";
}
public class Save : MonoBehaviour
{
    
    private void Start()
    {
        Data d = new Data();
        // saving or writing
        UtilitySave.SecureSerialize(Application.dataPath + "saveFile.data", d);
        // reading
        Data sd = UtilitySave.SecureDeserialize(Application.dataPath + "saveFile.data");


    }

}
