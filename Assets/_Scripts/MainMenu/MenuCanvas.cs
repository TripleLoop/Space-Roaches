using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour {

    public MenuCanvas Initialize(Camera mainCamera)
    {
        GetComponent<Canvas>().worldCamera = mainCamera;
        return this;
    }

    public void Play()
    {
        SceneManager.LoadScene(SRScenes.MainGame);
    }
}
