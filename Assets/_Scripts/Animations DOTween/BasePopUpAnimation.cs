using System;
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

    private RectTransform _popUpRectTransform;
    private Image _popUpImage;

    private Sequence _animationSequence;

    private Action _onCloseAnimationEnded;

    public void Initialize()
    {
        DOTween.Init();
        _animationSequence = DOTween.Sequence();
    }

    public BasePopUpAnimation PlayAnimation(bool exit = true, Action onCloseEnded = null)
    {
        _popUpRectTransform = _popUp.GetComponent<RectTransform>();
        _popUpImage = _backgroundPopUp.GetComponent<Image>();

        if (exit)
        {
            _animationSequence.SmoothRewind();
            return this;
        }
        _onCloseAnimationEnded = onCloseEnded;
        _animationSequence
            .Append(CreatePopUpAnimation())
            .Join(CreateBackgroundPopUpAnimation())
            .OnRewind(OnRewind);
        _animationSequence.Play();
        return this;
    }

    private Sequence CreatePopUpAnimation()
    {
        Sequence popUpSequence = DOTween.Sequence();
        popUpSequence.Append(_popUpRectTransform.DOAnchorPosY(600, 1f, true).From().SetEase(Ease.Linear));
        popUpSequence.Append(_popUpRectTransform.DOPunchAnchorPos(new Vector2(0, -50), 1f, 0, 0f));
        return popUpSequence;
    }

    private Sequence CreateBackgroundPopUpAnimation()
    {
        Sequence backgroundPopUpSequence = DOTween.Sequence();
        backgroundPopUpSequence.Append(_popUpImage.DOFade(0f, 1f).From());
        return backgroundPopUpSequence;
    }

    private void OnRewind()
    {
        _onCloseAnimationEnded();
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
