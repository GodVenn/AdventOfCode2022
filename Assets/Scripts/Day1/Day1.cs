using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Day1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParseInput();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ParseInput()
    {
        string day = "Day1";
        string path = $"Assets/Scripts/{day}/input.txt";
        string content = File.ReadAllText(path);
        Debug.Log(content);
    }
}
