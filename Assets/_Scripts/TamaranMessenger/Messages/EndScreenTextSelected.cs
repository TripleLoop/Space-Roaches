using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreenTextSelected
{

    public String Text { get; set; }
    public Text TextBox;

    public EndScreenTextSelected(String text, Text textBox)
    {
        Text = text;
        TextBox = textBox;
    }
}
