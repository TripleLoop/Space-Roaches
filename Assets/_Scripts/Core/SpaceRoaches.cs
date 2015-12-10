using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class SpaceRoaches : MonoBehaviourEx, IHandle<AstronautDeathMessage>, IHandle<RoachDeathMessage>, IHandle<RestartGameMessage>
{
    private Camera _mainCamera;
    private GameObject _astronautObject;
    private Canvas _canvasObject;

    private UserInput _userInput;
    private Smooth_Follow _smoothFollow;
    private Shake_Camera _shakeCamera;
    private WaveManager _waveManager;
    private Astronaut _astronaut;
    private CanvasManager _canvasManager;
    private SoundManager _soundManager;

    private IEnumerator _waveCycle;
    private int _secondsToNextWave;
    private int _waveCount;
    private int _roachDeathCount;
    private bool _astronautDead;
    private readonly int[] _speedMarks = new int[] { 15, 40, 100, 250, 600 };

    void Start()
    {
        this.InitializeCamera()
            .InitializeUserInput()
            .InitializePlayerPrefsManager()
            .InitializeParticlePool()
            .InitializeWaveManager()
            .InitializeSoundManager()
            .InitializeCanvas()
            .InitializeParticlePool()
            .InitializeBackground()
            .InitializeForeGround()
            .InitializeAstronaut()
            .SetReferences()
            .AudioSetUp()
            .StartGame();
    }

    public SpaceRoaches FasterWaveCycle()
    {
        if (_secondsToNextWave > 3)
        {
            _secondsToNextWave = 3;
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

    public void Handle(RestartGameMessage message)
    {
        if (_astronautDead)
        {
            this.Reset()
                .StartGame();
        }
        else
        {
            Debug.Log("Should not restart!");
        }
        
    }

    public void Handle(RoachDeathMessage message)
    {
        _roachDeathCount++;
        if (Time.timeScale >= 3f)
        {
            return;
        }
        if (Array.Exists(_speedMarks, element => element == _roachDeathCount))
        {
            Time.timeScale += 0.3f;
            Debug.Log("Speed increased, current speed: " + Time.timeScale);
        }
    }

    private IEnumerator WaveCycle()
    {
        yield return new WaitForSeconds(3f);
        _secondsToNextWave = 10;
        while (true)
        {
            if (_astronautDead)
            {
                break;
            }
            _waveCount++;
            _waveManager.EntitySpawn();
            while (_secondsToNextWave > 0)
            {
                yield return new WaitForSeconds(1f);
                _secondsToNextWave--;
            }
            _secondsToNextWave = 10;
        }
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
        StartGame();
        return this;
    }

    private SpaceRoaches SetReferences()
    {
        _smoothFollow.SetCameraTarget(_astronautObject);
        _shakeCamera.Initialize(_astronautObject);
        _userInput.SetCamera(_mainCamera);
        _waveManager.SetSpaceRoaches(this);
        _canvasObject.worldCamera = _mainCamera;
        return this;
    }

    private SpaceRoaches InitializeCamera()
    {
        GameObject mainCamera = SRResources.Core.Base.BaseCamera.Instantiate();
        mainCamera.name = "mainCamera";
        mainCamera.transform.parent = this.gameObject.transform;
        _smoothFollow = mainCamera.AddComponent<Smooth_Follow>();
        _mainCamera = mainCamera.GetComponent<Camera>();
        _smoothFollow.Initialize(0.2f);
        _shakeCamera = mainCamera.AddComponent<Shake_Camera>();
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

    private SpaceRoaches InitializeBackground()
    {
        GameObject background = SRResources.Core.Environment.background.Instantiate();
        background.name = "background";
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
        _canvasObject = canvas.GetComponent<Canvas>();
        _canvasManager = canvas.GetComponent<CanvasManager>();
        GameObject eventSystem = SRResources.Core.UI.EventSystem.Instantiate();
        eventSystem.name = "EventSystem";
        eventSystem.transform.SetParent(transform, false);
        return this;
    }

    private SpaceRoaches InitializeWaveManager()
    {
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
        return this;
    }

    private SpaceRoaches AudioSetUp()
    {
        _soundManager.SetAudioState();
        Messenger.Publish(new PlayMusicMessage(SRResources.Core.Audio.Clips.Music.MainGame));
        return this;
    }
}
