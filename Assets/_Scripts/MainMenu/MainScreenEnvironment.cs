using System;
using System.Collections;
using UnityEngine;
using LocalConfig = Config.MainMenu.Environment;
using Random = UnityEngine.Random;

public class MainScreenEnvironment : MonoBehaviour
{
    private FakeAstronaut _fakeAstronaut;
    private Action _astronautDelegate;
    private bool _activated = true;
    private bool _inWaitandMove = false;

    public MainScreenEnvironment Initialize()
    {
        this.InitializeBackground()
            .InitializeAstronaut()
            .MoveAstronaut();
        return this;
    }

    private MainScreenEnvironment MoveAstronaut()
    {
        int index = Random.Range(0, LocalConfig.Sides.Length);
        SideThrower choosenSide = LocalConfig.Sides[index];
        Vector2 randomPosition = choosenSide.RandomPosition();
        _fakeAstronaut.SetPosition(randomPosition)
            .Push(LocalConfig.Astronaut.PushForce, choosenSide.RandomDirection(randomPosition))
            .Torque(LocalConfig.Astronaut.TorqueForce);
        return this;
    }

    private void AstronautDissapears()
    {
        if (_activated && !_inWaitandMove)
        {
            StartCoroutine(WaitAndMoveAstronaut());
        }
    }

    private IEnumerator WaitAndMoveAstronaut()
    {
        _inWaitandMove = true;
        _fakeAstronaut.Stop();
        yield return new WaitForSeconds(Random.Range(LocalConfig.Astronaut.MinTimeBetweenExit,LocalConfig.Astronaut.MaxTimeBetweenExit));
        MoveAstronaut();
        _inWaitandMove = false;
    }

    private MainScreenEnvironment InitializeAstronaut()
    {
        GameObject fakeAstronaut = SRResources.Menu.Entities.MenuAstronaut.Instantiate();
        fakeAstronaut.name = "fakeAstronaut";
        fakeAstronaut.transform.SetParent(transform);
        fakeAstronaut.transform.position = new Vector3(0, 0, -5f);
        _astronautDelegate = AstronautDissapears;
        _fakeAstronaut = fakeAstronaut.GetComponent<FakeAstronaut>().Initialize(_astronautDelegate);
        return this;
    }

    private MainScreenEnvironment InitializeBackground()
    {
        GameObject background = SRResources.Menu.Environment.MainScreenBG.Instantiate();
        background.name = "background";
        background.transform.SetParent(transform);
        background.transform.position = new Vector3(0, 0, -3.5f);
        return this;
    }

    void OnApplicationQuit()
    {
        _activated = false;
    }

}
