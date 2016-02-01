using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class BasePopUpAnimation : MonoBehaviour
{

    [SerializeField]
    private GameObject _popUp;
    [SerializeField]
    private GameObject _backgroundPopUp;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private BasePopUpAnimation CreatePopUpEnterAnimation()
    {
        RectTransform popUpRectTransform = _popUp.GetComponent<RectTransform>();
        Sequence popUpSequence = DOTween.Sequence();
        popUpSequence.Append(popUpRectTransform.DOAnchorPosY(0f, 1f));
        popUpSequence.Append(popUpRectTransform.DOPunchAnchorPos(new Vector2(0, 5), 1f, 10, 0f));
        return this;
    }

    private BasePopUpAnimation CreateBackgroundPopUpEnterAnimation()
    {
        Image popUpImage = _popUp.GetComponent<Image>();
        Sequence backgroundPopUpSequence = DOTween.Sequence();
        backgroundPopUpSequence.Append(popUpImage.DOFade(215f, 1f));
        return this;
    }

    private BasePopUpAnimation CreatePopUpExitAnimation()
    {
        RectTransform popUpRectTransform = _popUp.GetComponent<RectTransform>();
        Sequence popUpSequence = DOTween.Sequence();
        popUpSequence.Append(popUpRectTransform.DOAnchorPosY(0f, 1f));
        popUpSequence.Append(popUpRectTransform.DOPunchAnchorPos(new Vector2(0, 5), 1f, 10, 0f));
        return this;
    }

    private BasePopUpAnimation CreateBackgroundPopUpExitAnimation()
    {
        Image popUpImage = _popUp.GetComponent<Image>();
        Sequence backgroundPopUpSequence = DOTween.Sequence();
        backgroundPopUpSequence.Append(popUpImage.DOFade(0f, 1f));
        return this;
    }
}
