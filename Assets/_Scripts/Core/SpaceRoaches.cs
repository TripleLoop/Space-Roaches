using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;
using UnityEngine.SceneManagement;
using LocalConfig = Config.SpaceRoaches;

public class SpaceRoaches : MonoBehaviourEx, IHandle<AstronautDeathMessage>, IHandle<RoachDeathMessage>, IHandle<RestartGameMessage>, IHandle<TutorialEndedMessage>
{
    void Start()
    {
        this.InitializeCanvas()
        .InitializeCamera();
        StartCoroutine(AsyncInitialization());
    }

    public SpaceRoaches FasterWaveCycle()
    {
        if (_secondsToNextWave > LocalConfig.SecondsBetweenFastWaves)
        {
            _secondsToNextWave = LocalConfig.SecondsBetweenFastWaves;
        }
        return this;
    }

    public void Handle(AstronautDeathMessage message)
    {
        _astronautDead = true;
        _userInput.DisableInput();
        Time.timeScale = 1f;
        Debug.Log("Speed normalized, current speed: " + Time.timeScale);
    }

    public void Handle(TutorialEndedMessage message)
    {
        StartGame();
        _astronaut.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Handle(RestartGameMessage message)
    {
        if (_astronautDead)
        {
            this.RestartGame();
        }
        else
        {
            Debug.Log("Should not restart!");
        }

    }

    public void Handle(RoachDeathMessage message)
    {
        _roachDeathCount++;
        if (Time.timeScale >= LocalConfig.MaxTimeScale)
        {
            return;
        }
        if (Array.Exists(LocalConfig.SpeedMarks, element => element == _roachDeathCount))
        {
            Time.timeScale += LocalConfig.AddedTimeScale;
            Debug.Log("Speed increased, current speed: " + Time.timeScale);
        }
    }

    public SpaceRoaches TransitionToMenu()
    {
        _canvasManager.LoadingToBlack(ChangeSceneMenu);
        return this;
    }

    private void ChangeSceneMenu()
    {
        SceneManager.LoadScene(SRScenes.MainMenu);
    }

    private IEnumerator WaveCycle()
    {
        //some magic to controll the waves sorry :(
        yield return new WaitForSeconds(LocalConfig.TimeBeforeFirstWave);
        _secondsToNextWave = LocalConfig.SecondsBetweenWaves;
        while (true)
        {
            if (_astronautDead)
            {
                break;
            }
            _waveCount++;
            _waveManager.SpawnWave(ChangeWave());
            while (_secondsToNextWave > 0)
            {
                yield return new WaitForSeconds(1f);
                _secondsToNextWave--;
            }
            _secondsToNextWave = LocalConfig.SecondsBetweenWaves;
        }
    }

    private Wave ChangeWave()
    {
        if (_waveCount == 1)
        {
            return _waveSequence.SequenceWave[0];
        }
        float tempWaveCount = _waveCount;
        int wave = Mathf.CeilToInt(tempWaveCount / 5);
        if (wave > 5)
        {
            return _waveSequence.SequenceWave[5];
        }
        return _waveSequence.SequenceWave[wave];
    }

    private SpaceRoaches TutorialShow()
    {
       if (!_playerPrefsManager.TutorialForced && _playerPrefsManager.TutorialSeen)
        {
            StartGame();
            _astronaut.GetComponent<SpriteRenderer>().enabled = true;
            return this;
        }
        _canvasManager.ShowTutorial();
        _playerPrefsManager.TutorialSeen = true;
        return this;
    }

    private SpaceRoaches RestartGame()
    {
        this.Reset()
            .StartGame();
        return this;
    }

    private SpaceRoaches StartGame()
    {
        _userInput.EnableInput();
        _waveCycle = WaveCycle();
        StartCoroutine(_waveCycle);
        return this;
    }

    private SpaceRoaches Reset()
    {
        _secondsToNextWave = 0;
        _waveCount = 0;
        _roachDeathCount = 0;
        _astronautDead = false;
        StopCoroutine(_waveCycle);
        _waveManager.Reset();
        _astronaut.Reset();
        _canvasManager.Reset();
        return this;
    }

    private IEnumerator AsyncInitialization()
    {
        yield return StartCoroutine(_canvasManager.ShowLoading());
        InitializeBackend()
            .InitializePlayerPrefsManager()
            .InitializeSoundManager()
            .InitializeUserInput();
        yield return null;
        InitializeParticlePool()
            .InitializeWaveManager()
            .InitializeMovingBackground()
            .Initialize3DBackground();
        yield return null;
        InitializeForeGround()
        .InitializeAstronaut()
        .SetReferences()
        .AudioSetUp()
        .TutorialShow();
        _canvasManager.HideLoading(false);
    }

    private SpaceRoaches SetReferences()
    {
        _smoothFollow.SetCameraTarget(_astronautObject);
        _userInput.SetCamera(_mainCamera);
        _waveManager.SetSpaceRoaches(this);
        return this;
    }

    private SpaceRoaches InitializeCamera()
    {
        GameObject mainCamera = SRResources.Core.Base.BaseCamera.Instantiate();
        mainCamera.name = "mainCamera";
        mainCamera.transform.parent = this.gameObject.transform;
        _smoothFollow = mainCamera.AddComponent<Smooth_Follow>();
        _mainCamera = mainCamera.GetComponent<Camera>();
        mainCamera.AddComponent<Shake_Camera>();
        return this;
    }

    private SpaceRoaches InitializeBackend()
    {
        GameObject backendProxy = SRResources.Core.Base.BackendProxy.Instantiate();
        backendProxy.name = "backendProxy";
        backendProxy.transform.SetParent(transform);
        _backendProxy = backendProxy.GetComponent<BackendProxy>();
        _backendProxy.Initialize();
        return this;
    }

    private SpaceRoaches InitializeUserInput()
    {
        GameObject userInput = SRResources.Core.Base.UserInput.Instantiate();
        userInput.name = "userInput";
        userInput.transform.parent = this.gameObject.transform;
        _userInput = userInput.GetComponent<UserInput>();
        return this;
    }

    private SpaceRoaches InitializeMovingBackground()
    {
        GameObject background = SRResources.Core.Environment.background.Instantiate();
        background.name = "background";
        background.transform.parent = this.gameObject.transform;
        return this;
    }

    private SpaceRoaches Initialize3DBackground()
    {
        GameObject background = SRResources.Core.Environment.background3D.Instantiate();
        background.name = "background3D";
        background.transform.parent = this.gameObject.transform;
        return this;
    }

    private SpaceRoaches InitializeForeGround()
    {
        GameObject gameWalls = SRResources.Core.Environment.gameWalls.Instantiate();
        gameWalls.name = "gameWalls";
        gameWalls.transform.parent = this.gameObject.transform;
        return this;
    }

    private SpaceRoaches InitializeAstronaut()
    {
        GameObject astronaut = SRResources.Core.Characters.Astronaut.Instantiate();
        astronaut.name = "Astronaut";
        astronaut.transform.parent = this.gameObject.transform;
        _astronaut = astronaut.GetComponent<Astronaut>();
        _astronautObject = astronaut;
        return this;
    }

    private SpaceRoaches InitializeCanvas()
    {
        GameObject canvas = SRResources.Core.UI.Canvas.Instantiate();
        canvas.name = "Canvas";
        canvas.transform.SetParent(this.gameObject.transform, false);
        _canvasManager = canvas.GetComponent<CanvasManager>();
        _canvasManager.Initialize(this, _mainCamera);
        GameObject eventSystem = SRResources.Core.UI.EventSystem.Instantiate();
        eventSystem.name = "EventSystem";
        eventSystem.transform.SetParent(transform, false);
        if (Debug.isDebugBuild && SRDebug.Instance == null)
        {
            SRDebug.Init();
        }
        return this;
    }

    private SpaceRoaches InitializeWaveManager()
    {
        _waveSequence = new WaveSequence();
        GameObject waveManager = SRResources.Core.Base.WaveManager.Instantiate();
        waveManager.name = "WaveManager";
        waveManager.transform.SetParent(this.gameObject.transform, false);
        _waveManager = waveManager.GetComponent<WaveManager>();
        _waveManager.InitializeWaveManager();
        return this;
    }

    private SpaceRoaches InitializeParticlePool()
    {
        GameObject waveManager = SRResources.Core.Pools.Particle_Pool.Instantiate();
        waveManager.name = "Particle_Pool";
        waveManager.transform.SetParent(this.gameObject.transform, false);
        return this;
    }

    private SpaceRoaches InitializeSoundManager()
    {
        GameObject waveManager = SRResources.Core.Base.SoundManager.Instantiate();
        waveManager.name = "SoundManager";
        waveManager.transform.SetParent(this.gameObject.transform, false);
        _soundManager = waveManager.GetComponent<SoundManager>().InitializeSources();
        return this;
    }

    private SpaceRoaches InitializePlayerPrefsManager()
    {
        GameObject playerPrefsManager = SRResources.Core.Base.PlayerPrefsManager.Instantiate();
        playerPrefsManager.name = "playerPrefsManager";
        playerPrefsManager.transform.SetParent(transform);
        _playerPrefsManager = playerPrefsManager.GetComponent<PlayerPrefsManager>();
        _playerPrefsManager.Initialize();
        return this;
    }

    private SpaceRoaches AudioSetUp()
    {
        _soundManager.SetAudioState();
        Messenger.Publish(new PlayMusicMessage(SRResources.Core.Audio.Clips.Music.MainGame));
        return this;
    }

    private Camera _mainCamera;
    private GameObject _astronautObject;

    private UserInput _userInput;
    private Smooth_Follow _smoothFollow;

    private WaveManager _waveManager;
    private WaveSequence _waveSequence;

    private Astronaut _astronaut;
    private CanvasManager _canvasManager;
    private SoundManager _soundManager;
    private BackendProxy _backendProxy;
    private PlayerPrefsManager _playerPrefsManager;

    private IEnumerator _waveCycle;
    private int _secondsToNextWave;
    private int _waveCount;
    private int _roachDeathCount;
    private bool _astronautDead;
}
