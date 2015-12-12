using UnityEngine;
using UnityEditor;
 
 public class Hider : EditorWindow
{

    [MenuItem("Window/GameObject_Hider&Destroyer/Start")]
    public static void Create()
    {
        GetWindow<Hider>();
    }

    void OnGUI()
    {

        if (GUILayout.Button("Create hidden GO"))
        {
            GameObject h = new GameObject("hidden");
            h.hideFlags = HideFlags.HideInHierarchy;
        }
        if (GUILayout.Button("Select hidden GO"))
        {
            Selection.activeGameObject = GameObject.Find("hidden");
        }

        if (GUILayout.Button("Destroy Selected Object"))
        {
            DestroyImmediate(Selection.activeObject);
        }
    }
}
