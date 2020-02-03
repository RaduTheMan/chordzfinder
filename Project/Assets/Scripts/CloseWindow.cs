using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{

    public GameObject fereastra;
    public void Close()
    {
        fereastra.SetActive(false);
    }
}
