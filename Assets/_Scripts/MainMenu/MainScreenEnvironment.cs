using System;
using System.Collections;
using UnityEngine;
using LocalConfig = Config.MainMenu.Environment;
using Random = UnityEngine.Random;

public class MainScreenEnvironment : MonoBehaviour
{
    private FakeAstronaut _fakeAstronaut;
    private Action _astronautDelegate;

    public MainScreenEnvironment Initialize()
    {
        this.InitializeBackground()
            .InitializeAstronaut()
            .MoveAstronaut();
        return this;
    }

    private MainScreenEnvironment MoveAstronaut()
    {
        int index = Random.Range(0,LocalConfig.Sides.Length);
        SideThrower choosenSide = LocalConfig.Sides[index];
        Vector2 randomPosition = choosenSide.RandomPosition();
        _fakeAstronaut.SetPosition(randomPosition)
           .Push(0.1f, choosenSide.RandomDirection(randomPosition));
        return this;
    }

    private void AstronautDissapears()
    {
        StartCoroutine(WaitAndMoveAstronaut());
    }

    private IEnumerator WaitAndMoveAstronaut()
    {
        yield return new WaitForSeconds(5f);
        MoveAstronaut();
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

}
