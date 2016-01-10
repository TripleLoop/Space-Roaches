using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriting : MonoBehaviour {
    private Text dialogueBox;
    //Image showAvailabeAction;
    private string[] currentDialogLines;
    private int currentLine;
    //private int _messageId;
    private bool _typing = false;
    
    // Use this for initialization
	/*void Start () {
        dialogueBox = transform.Find("dialogText").GetComponent<Text>();
	    dialogueBox.text ="";
	}*/

    public void StartWrite(string text, Text commentBox)
    {
        /*foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        //showAvailabeAction.gameObject.SetActive(false);
        currentDialogLines = message.DialogText;
        //_messageId = message.MessageId;
        currentLine = 0;*/
        //StartCoroutine(DetectInput());
        //NextLine();
        StartCoroutine(TypeText(text, commentBox));
    }

    /*public void NextLine()
    {
        if (_typing) return;
        if (currentDialogLines.Length > currentLine)
        {
            dialogueBox.text = "";
            StopCoroutine("TypeText");
            StartCoroutine(TypeText(currentDialogLines, currentLine));
        }
        else
        {
            StopAllCoroutines();
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            //Messenger.Publish(new DialogueEndMessage(_messageId));
        }
        currentLine++;
    }*/
    
    IEnumerator TypeText(string text, Text dialogueBox/*, int line*/)
    {
        _typing = true;
        //showAvailabeAction.gameObject.SetActive(false);
        foreach (char letter in text/*[line]*/.ToCharArray())
        {
            dialogueBox.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
        //showAvailabeAction.gameObject.SetActive(true);
        _typing = false;
    }

    /*IEnumerator DetectInput()
    {
        while (true)
        {
            if (Input.GetButtonDown("Action"))
            {
                NextLine();
            }
            yield return null;
        }
       
    }*/
}
