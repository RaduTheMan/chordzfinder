using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class game_control : MonoBehaviour
{
    // Start is called before the first frame update
    public static game_control instance;
    public bool isGameActive = false;
    public bool isWarningActive = false;
    private bool isCorrect = false;
    private bool isWrong = false;
    public GameObject warning;
    public GameObject choose;
    public GameObject play_hidden_chord;
    public GameObject alege;
    public GameObject wrong;
    public GameObject correct;
    public Text progres;
    public Dropdown choose_dropdown;
    public int number_chords_to_guess = 5;
    public int index_chord_to_guess;
    public int index = 1;
    private int number_chords_selected;
    private float waitTime = 2.0f;
    private float wait_answer_time = 1.0f;
    private float time = 0.0f;
    public List<string> selectedChords = new List<string>();
    public void StartGame()
    {
        if (Chords.instance.myList.Count >= 2)
        {
            selectedChords.Clear();
            alege.SetActive(true);
            progres.text = index.ToString() + '/' + number_chords_to_guess.ToString();
            play_hidden_chord.SetActive(true);
            isGameActive = true;
            choose.SetActive(true);
            choose_dropdown = choose.GetComponent<Dropdown>();
            choose_dropdown.ClearOptions();
            for(int i=0;i<Chords.instance.myList.Count;i++)
            {
                selectedChords.Add(Chords.instance.myList[i].name);
            }
            selectedChords.Sort();
            choose_dropdown.AddOptions(selectedChords);
            number_chords_selected = Chords.instance.myList.Count;
            index_chord_to_guess = Random.Range(0, number_chords_selected);
        }
        else
        {
            isWarningActive = true;
            warning.SetActive(true);
        }
    }
    public void Verify()
    {
         if(choose_dropdown.value==index_chord_to_guess)
        {
            ///print("ACORD CORECT");
            if (index < number_chords_to_guess)
            {
                index++;
                progres.text = index.ToString() + '/' + number_chords_to_guess.ToString();
                index_chord_to_guess = Random.Range(0, number_chords_selected);
            }
            else
            {
                isGameActive = false;
                index = 1;
                alege.SetActive(false);
                progres.text=" ";
                play_hidden_chord.SetActive(false);
                choose.SetActive(false);
            }
            isCorrect = true;
            correct.SetActive(true);

        }
         else
        {
            ///print("ACORD GRESIT");
            isWrong = true;
            wrong.SetActive(true);
        }
    }
    public void PlayGuessingChord()
    {
        for(int i=0;  i < Chords.instance.myList.Count;i++)
            if(Chords.instance.myList[i].name==selectedChords[index_chord_to_guess])
              Chords.instance.myList[i].GetComponent<AudioSource>().Play();
    }
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(isWarningActive==true)
        {
            time += Time.deltaTime;
            if(time>waitTime)
            {
                isWarningActive = false;
                warning.SetActive(false);
                time -= waitTime;
            }
        }
        if(isWrong==true)
        {
            time += Time.deltaTime;
            if(time>wait_answer_time)
            {
                isWrong = false;
                wrong.SetActive(false);
                time -= wait_answer_time;
            }
        }
        if(isCorrect==true)
        {
            time += Time.deltaTime;
            if (time > wait_answer_time)
            {
                isCorrect = false;
                correct.SetActive(false);
                time -= wait_answer_time;
            }
        }
    }
}
