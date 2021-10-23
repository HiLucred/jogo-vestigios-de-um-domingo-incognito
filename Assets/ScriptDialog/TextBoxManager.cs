using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TextBoxManager : MonoBehaviour
{

    public GameObject textBox;

    public TextMeshProUGUI theText;


    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public Controller player;

    public bool isActive;

    public bool stopPlayerMovement;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;

    public Animator animPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Controller>();
            
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));

        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if(isActive)
        {
            EnableTextBox();

        }
        else
        {
            DisableTextBox();
        }

    }

    void Update()
    {
        if(!isActive)
        {
            return;
        }

        //theText.text = textLines[currentLine];

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {

                currentLine += 1;

                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                }

                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));

                }
            }

            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }

 
    }

    private IEnumerator TextScroll (string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
            
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;


    }
    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if(stopPlayerMovement)
        {
            animPlayer.SetBool("podeCorrer", false);
            player.podeMover = false;
            player.podePular = false;
        }

        StartCoroutine(TextScroll(textLines[currentLine]));
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;

        player.podeMover = true;
        player.podePular = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }

    }



}
