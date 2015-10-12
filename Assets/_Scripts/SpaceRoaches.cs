using UnityEngine;
using System.Collections;

public class SpaceRoaches : MonoBehaviour {

    // Use this for initialization
    void Start ()
    {
        this.InitalizeCamera()
            .InitalizeBackgorund()
            .InitalizeForeGround();
    }

    private SpaceRoaches InitalizeCamera()
    {
        GameObject mainCamera = SRResources.Base.BaseCamera.Instantiate();
        mainCamera.name = "mainCamera";
        mainCamera.transform.parent = this.gameObject.transform;
        return this;
    }

    private SpaceRoaches InitalizeBackgorund()
    {
        GameObject background = SRResources.Environment.background.Instantiate();
        background.name = "background";
        background.transform.parent = this.gameObject.transform;
        return this;
    }

    private SpaceRoaches InitalizeForeGround()
    {
        GameObject gameWalls = SRResources.Environment.gameWalls.Instantiate();
        gameWalls.name = "gameWalls";
        gameWalls.transform.parent = this.gameObject.transform;
        return this;
    }

}
