using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreen : MonoBehaviourEx, IHandle<AstronautDeathMessage>
{
    private Text _text;
    [SerializeField]
    private Text _roachesDeath;

    private bool _astronautDie = false;


	// Use this for initialization
	void Start ()
	{
	    _text = gameObject.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Handle(AstronautDeathMessage message)
    {
        if (!_astronautDie)
        {
            _astronautDie = true;
            gameObject.GetComponent<CanvasGroup>().alpha = 1;
            StartCoroutine(CountUp());
        }
    }

    private IEnumerator CountUp()
    {
        int scoreCount = 0;
        int numDeathRoaches = int.Parse(_roachesDeath.text);

        while (true)
        {
            if (scoreCount >= numDeathRoaches)
            {
                break;
            }
            yield return new WaitForSeconds(0.05f);
            scoreCount++;
            _text.text = ""+scoreCount;
        }
    }

    public void Restart()
    {
        Debug.Log("Restart");
    }

    public void Menu()
    {
        Debug.Log("Menu");
    }
}
