using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chords : MonoBehaviour
{
    public static Chords instance;
    public  List<GameObject> myList = new List<GameObject>();
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
