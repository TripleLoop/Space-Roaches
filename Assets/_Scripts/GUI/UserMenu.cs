using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserMenu : MonoBehaviour
{
    public UserMenu Initialize(PlayerPrefsManager playerPrefsManager)
    {
        _playerPrefsManager = playerPrefsManager;
        _childrenController = gameObject.AddComponent<ChildrenControllerComponent>();
        _childrenController.DisableChildren();
        return this;
    }

    public void Close()
    {
        _childrenController.DisableChildren();
        _enableDelegate();
    }

    public UserMenu Show(MenuCanvas.EnableDelegate enableDelegate)
    {
        _childrenController.EnableChildren();
        _enableDelegate = enableDelegate;
        _wallet.text = _playerPrefsManager.SpaceCoins.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("en-GB"));
        return this;
    }

    [SerializeField]
    private Text _wallet;

    private ChildrenControllerComponent _childrenController;
    private PlayerPrefsManager _playerPrefsManager;
    private MenuCanvas.EnableDelegate _enableDelegate;
}
