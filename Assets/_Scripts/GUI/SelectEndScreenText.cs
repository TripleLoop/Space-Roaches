using System;
using UnityEngine;
using System.Collections;
using LocalConfig = Config.Text.EndScreen;
using Random = UnityEngine.Random;

public class SelectEndScreenText : MonoBehaviourEx, IHandle<ScoreCountFinished>
{
    private SelectEndScreenText SelectText(String[] textArray)
    {
        var text = textArray[Random.Range(0, textArray.Length)];
        Messenger.Publish(new EndScreenTextSelected(text));
        return this;
    }

    public void Handle(ScoreCountFinished message)
    {
        var score = message.Score;
        String[] textRange = new string[] { };
        if (score == 0)
        {
            textRange = LocalConfig.FirstRange;
            SelectText(textRange);
        }
        if (score > 0 && score <= 20)
        {
            textRange = LocalConfig.SecondRange;
            SelectText(textRange);
        }
        if (score > 20 && score <= 40)
        {
            textRange = LocalConfig.ThirdRange;
            SelectText(textRange);
        }
        if (score > 40)
        {
            textRange = LocalConfig.FourthRange;
            SelectText(textRange);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
