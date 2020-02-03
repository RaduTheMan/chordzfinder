using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Play : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private AudioSource chord;
    public GameObject border;
    public GameObject aux;
    public GameObject picture;
    public int isBorderActive = 0;
    private bool dark_applied = false;
    void Start()
    {
       chord = this.gameObject.GetComponent<AudioSource>();
       border = this.gameObject.transform.GetChild(0).gameObject;
       picture = this.gameObject.transform.GetChild(1).gameObject;
    }
    public void play()
    {
        if (game_control.instance.isGameActive == false)
        {
            chord.Play();
            isBorderActive = 1 - isBorderActive;
            if (isBorderActive == 1)
                border.SetActive(true);
            else
                border.SetActive(false);
            if (isBorderActive == 1)
            {
                Chords.instance.myList.Add(this.gameObject);
            }
            else
                Chords.instance.myList.Remove(this.gameObject);
            
        }
    }
     void Update()
    {
            if(game_control.instance.isGameActive == true && dark_applied==false)
        {
            dark_applied = true;
            this.gameObject.GetComponent<Image>().color = new Color32(60, 62, 70, 255);
        }
         else
            if(game_control.instance.isGameActive == false && dark_applied==true)
        {
            dark_applied = false;
            this.gameObject.GetComponent<Image>().color = Color.white;
        }
       
    
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(game_control.instance.isGameActive==false)
        picture.SetActive(true);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        picture.SetActive(false);
    }

}
