using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    
    public GameObject[] texts;
    private int element;
    public void switchh()
    {
        element = PlayerPrefs.GetInt("switch", 1);
        element = 1 - element;
        texts[element].SetActive(true);
        texts[1-element].SetActive(false);
        PlayerPrefs.SetInt("switch", element);
        print(element);
    }
  
}
