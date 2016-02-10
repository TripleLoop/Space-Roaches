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
            StopCoroutine(_countUp);
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

    private IEnumerator CountUp()
    {
        _isInCountUp = true;
        int scoreCount = 0;
        var numDeathRoaches = _roachCount.GetScore();
        Messenger.Publish(new NewScoreMessage(numDeathRoaches));
        while (true)
        {
            if (scoreCount == numDeathRoaches)
            {
                yield return new WaitForSeconds(0.5f);
                _isInCountUp = false;
                break;
            }
            yield return new WaitForSeconds(LocalConfig.TimeCountUp);
            scoreCount++;
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

    private bool _isInCountUp;
    private IEnumerator _countUp;

    private bool _astronautDead = false;

    private bool _popupClosed;
    private ChildrenControllerComponent _childrenController;
    private BasePopupComponent _basePopupComponent;
    private Action _onCloseEndedDelegate;
}
