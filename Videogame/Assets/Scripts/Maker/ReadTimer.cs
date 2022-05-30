using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTimer : MonoBehaviour
{

    public static float input;

    public void ReadStringInput(string s) 
    {
        input = float.Parse(s);
        Debug.Log(input);
    }
}
