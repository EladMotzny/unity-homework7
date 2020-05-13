using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;


    public string[] sentences;
    public string[] violence;
    public string[] peace;
    public int option1Count = 0;
    public int option2Count = 0;
    //to know what was clicked on first
    public bool oneFirst = false;
    public bool secondFirst = false;
    //if option1Count == 1, display violence text, if its 2 play surrender
    //if option1count = 1 and option2Count = 1 in that order play boxing
    //if option2count = 1 and then 2 play hug (roommate)
    //if option2 = 1 and option1 = 1 in that order play wave (leave)


    private int index;
    public float typingSpeed = 0.02f;
    public GameObject option1Button;
    public GameObject option2Button;
    public static bool hug = false;
    public static bool wave = false;
    public static bool box = false;
    public static bool surrender = false;





    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()//Type the first sentence in the textbox above booba
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);//print next letter after a certain ammount of time

        }
    }

    public void NextSentence()//type the next sentence after clicking continue
    {
        
        option1Button.SetActive(false);//hide button while sentence is being typed
        option2Button.SetActive(false);

        if (index < sentences.Length -1)//check if the sentence is done
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            option1Button.SetActive(false);
            option2Button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index])//if true, sentence typing is done
        {
            option1Button.SetActive(true);//show the button again
            option2Button.SetActive(true);
        }
    }

    public void updateOne()//updated anything related to option1 and call next sentence
    {
        option1Count++;
        if (oneFirst == false && secondFirst == false)
        {
            oneFirst = true;
        }
        if (option1Count == 1 && option2Count == 0)//first violence option
        {
            sentences[index + 1] = violence[0];
        }
        else if (option1Count == 1 && option2Count ==1 && secondFirst == true)//roommate, hug
        {
            sentences[index + 1] = peace[2];
            hug = true;
        }
        else if (option1Count == 2)//box
        {
            sentences[index + 1] = violence[1];
            box = true;
        }
        
        NextSentence();
    }

    public void updateTwo()//updated anything related to option2 and call next sentence
    {
        
        option2Count++;
        if (oneFirst == false && secondFirst == false)
        {
            secondFirst = true;
        }
        if (option2Count == 1 && option1Count == 0)//first peace option, come in peace
        {
            sentences[index + 1] = peace[0];
        }
        else if (option2Count == 1 && option1Count == 1 && oneFirst == true)//option1->option2, surrender
        {
            sentences[index + 1] = violence[2];
            surrender = true;
            
        }
        else if (option2Count == 2)//Juan leaves
        {
            sentences[index + 1] = peace[2];
            wave = true;
        }
        
        NextSentence();
    }
}
