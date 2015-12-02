using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class SpaceRoaches : MonoBehaviourEx, IHandle<AstronautDeathMessage>
{
    private Camera _mainCamera;
    private GameObject _astronaut;

    private UserInput _userInput;
    private Smooth_Follow _smoothFollow;
    private Canvas _canvas;
    private WaveManager _waveManager;

    private int _secondsToNextWave;
    private int _waveCount;
    private bool _astronautDead;

    void Start()
    {
        this.InitializeCamera()
            .InitializeUserInput()
            .InitializeBackgorund()
            .InitializeForeGround()
            .InitializeAstronaut()
            .InitializeCanvas()
            .InitializeWaveManager()
            .SetReferences()
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
        StartCoroutine(WaveCycle());
        return this;
    }

    private SpaceRoaches SetReferences()
    {
        _smoothFollow.SetCameraTarget(_astronaut);
        _userInput.SetCamera(_mainCamera);
        _waveManager.SetSpaceRoaches(this);
        _canvas.worldCamera = _mainCamera;
        return this;
    }

    private SpaceRoaches InitializeCamera()
    {
        GameObject mainCamera = SRResources.Base.BaseCamera.Instantiate();
        mainCamera.name = "mainCamera";
        mainCamera.transform.parent = this.gameObject.transform;
        _mainCamera = mainCamera.GetComponent<Camera>();
        _smoothFollow = mainCamera.GetComponent<Smooth_Follow>();
        return this;
    }

    private SpaceRoaches InitializeUserInput()
    {
        GameObject userInput = SRResources.Base.UserInput.Instantiate();
        userInput.name = "userInput";
        userInput.transform.parent = this.gameObject.transform;
        _userInput = userInput.GetComponent<UserInput>();
        return this;
    }

    private SpaceRoaches InitializeBackgorund()
    {
        GameObject background = SRResources.Environment.background.Instantiate();
        background.name = "background";
        background.transform.parent = this.gameObject.transform;
        return this;
    }

    private SpaceRoaches InitializeForeGround()
    {
        GameObject gameWalls = SRResources.Environment.gameWalls.Instantiate();
        gameWalls.name = "gameWalls";
        gameWalls.transform.parent = this.gameObject.transform;
        return this;
    }

    private SpaceRoaches InitializeAstronaut()
    {
        GameObject astronaut = SRResources.Characters.Astronaut.Instantiate();
        astronaut.name = "Astronaut";
        astronaut.transform.parent = this.gameObject.transform;
        _astronaut = astronaut;
        return this;
    }

    private SpaceRoaches InitializeCanvas()
    {
        GameObject canvas = SRResources.Base.Canvas.Instantiate();
        canvas.name = "Canvas";
        canvas.transform.SetParent(this.gameObject.transform, false);;
        _canvas = canvas.GetComponent<Canvas>();
        return this;
    }

    private SpaceRoaches InitializeWaveManager()
    {
        GameObject waveManager = SRResources.Base.WaveManager.Instantiate();
        waveManager.name = "WaveManager";
        waveManager.transform.SetParent(this.gameObject.transform, false); ;
        _waveManager = waveManager.GetComponent<WaveManager>();
        _waveManager.InitializeWaveManager();
        return this;
    }
}
