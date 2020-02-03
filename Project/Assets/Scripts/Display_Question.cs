using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Display_Question : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject legenda;
    void Start()
    {
        legenda = this.gameObject.transform.GetChild(0).gameObject;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        legenda.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        legenda.SetActive(false);
    }
}
