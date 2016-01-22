using UnityEngine;
using Assets.Scripts.VersionEditor;
using UnityEngine.UI;

namespace Assets._Scripts.MainMenu
{
    public class VersionShower: MonoBehaviour
    {
        private Text _versionText;
        void Start()
        {
            _versionText = GetComponent<Text>();
            _versionText.text = VersionInformation.ToString();
        }
    }
}
