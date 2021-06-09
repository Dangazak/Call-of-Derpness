using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayTest : MonoBehaviour
{
    public List<string> nameList = new List<string>();
    public string[] nameArray = new string[10000];

    public bool usingList;

    // Update is called once per frame
    void Update()
    {
        if (usingList)
        {
            for (int i = 0; i < 10000; i++)
            {
                nameList.Add("Nombre");
            }
        }
        else{
            for (int i = 0; i < 10000; i++)
            {
                nameArray[i] = "Nombre";
            }
        }
    }
}
