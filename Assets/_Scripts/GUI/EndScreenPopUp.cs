using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LocalConfig = Config.EndScreen;

public class EndScreenPopUp : MonoBehaviourEx, IHandle<AstronautDeathMessage>
{

    public EndScreenPopUp Initialize(RoachCount roachCount, SpaceRoaches spaceRoaches)
    {
        if (roachCount == null) return this;
        _roachCount = roachCount;
        _spaceRoaches = spaceRoaches;
        return this;
    }

    public EndScreenPopUp Initialize()
    {
        _childrenController = gameObject.AddComponent<ChildrenControllerComponent>();
        _basePopupComponent = gameObject.GetComponent<BasePopupComponent>();
        _onCloseEndedDelegate = OnCloseEnded;
        _basePopupComponent.Initialize(_onCloseEndedDelegate);
        return this;
    }

    public IEnumerator OpenPopUp()
    {
        _childrenController.EnableChildren();
        _basePopupComponent.ShowPopUp();

        _highScore = PlayerPrefs.GetInt("_ownHighScore");
        _highScore_Points.text = _highScore.ToString();

        _countUpPoints = CountUpPoints();
        StartCoroutine(_countUpPoints);

        _popupClosed = false;
        while (!_popupClosed)
        {
            yield return null;
        }
    }

    public void ClosePopUp()
    {
        if (_popupClosed) return;
        Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.BasicButton));
        _basePopupComponent.ClosePopUp();
        _popupClosed = true;
    }

    public void OnCloseEnded()
    {
        _childrenController.DisableChildren();
        _score_Points.text = "0";
        _highScore_Points.text = "0";
        _totalSP_Points.text = "0";
    }

    public void Menu()
    {
        Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.BasicButton));
        _spaceRoaches.TransitionToMenu();
    }

    public void Restart()
    {
        ClosePopUp();
        Messenger.Publish(new RestartGameMessage());
    }

    public EndScreenPopUp Reset()
    {
        _astronautDead = false;
        if (_isInCountUp)
        {
            StopCoroutine(_countUpPoints);
        }
        return this;
    }

    public void Handle(AstronautDeathMessage message)
    {
        if (!_astronautDead)
        {
            StartCoroutine(OpenPopUp());
            _astronautDead = true;
        }
    }

    private IEnumerator CountUpPoints()
    {
        _isInCountUp = true;
        int scoreCount = 0;
        _numDeathRoaches = _roachCount.GetScore();
        Messenger.Publish(new NewScoreMessage(_numDeathRoaches));
        while (true)
        {
            if (scoreCount == _numDeathRoaches)
            {
                yield return new WaitForSeconds(0.5f);
                _isInCountUp = false;
                _countUpSP = CountUpSP();
                StartCoroutine(_countUpSP);
                break;
            }
            yield return new WaitForSeconds(LocalConfig.TimeCountUp);
            scoreCount++;
            _score_Points.text = scoreCount.ToString();
            if (_highScore <= scoreCount)
            {
                _highScore_Points.text = scoreCount.ToString();
            }
            Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects._tick));
        }
    }

    private IEnumerator CountUpSP()
    {
        _isInCountUp = true;
        int spCount = 0;
        while (true)
        {
            if (spCount == _numDeathRoaches)
            {
                yield return new WaitForSeconds(0.5f);
                _isInCountUp = false;
                break;
            }
            yield return new WaitForSeconds(LocalConfig.TimeCountUp);
            spCount++;
            _totalSP_Points.text = spCount.ToString();
            Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects._tick));
        }

    }

    void Start ()
    {
        Initialize();
    }

    [SerializeField]
    private Text _score_Points;
    [SerializeField]
    private Text _highScore_Points;
    [SerializeField]
    private Text _totalSP_Points;

    private RoachCount _roachCount;
    private SpaceRoaches _spaceRoaches;

    private int _numDeathRoaches;

    private bool _isInCountUp;
    private IEnumerator _countUpPoints;
    private IEnumerator _countUpSP;

    private bool _astronautDead = false;

    private bool _popupClosed;
    private ChildrenControllerComponent _childrenController;
    private BasePopupComponent _basePopupComponent;
    private Action _onCloseEndedDelegate;

    private int _highScore;
}
