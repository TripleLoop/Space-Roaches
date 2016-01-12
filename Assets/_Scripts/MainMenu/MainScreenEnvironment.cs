using UnityEngine;

public class MainScreenEnvironment : MonoBehaviour
{
    private FakeAstronaut _fakeAstronaut;
    
    public MainScreenEnvironment Initialize()
    {
        this.InitializeBackground()
            .InitializeAstronaut()
            .StartEvents();
        return this;
    }

    private MainScreenEnvironment StartEvents()
    {
        _fakeAstronaut.SetPosition(new Vector3(-4, -4, -5))
            .Push(0.1f, new Vector2(2, 2));
        return this;
    }

    private MainScreenEnvironment InitializeAstronaut()
    {
        GameObject fakeAstronaut = SRResources.Menu.Entities.MenuAstronaut.Instantiate();
        fakeAstronaut.name = "fakeAstronaut";
        fakeAstronaut.transform.SetParent(transform);
        fakeAstronaut.transform.position = new Vector3(0, 0, -5f);
        _fakeAstronaut = fakeAstronaut.GetComponent<FakeAstronaut>().Initialize();
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
