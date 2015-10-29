using UnityEngine;
using System.Collections;

public class SpaceRoaches : MonoBehaviour {

    // Use this for initialization
    void Start ()
    {
        this.InitializeCamera()
            .InitializeUserInput()
            .InitializeBackgorund()
            .InitializeForeGround();
    }

    private SpaceRoaches InitializeCamera()
    {
        GameObject mainCamera = SRResources.Base.BaseCamera.Instantiate();
        mainCamera.name = "mainCamera";
        mainCamera.transform.parent = this.gameObject.transform;
        return this;
    }

    private SpaceRoaches InitializeUserInput()
    {
        GameObject userInput = SRResources.Base.UserInput.Instantiate();
        userInput.name = "userInput";
        userInput.transform.parent = this.gameObject.transform;
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

}
