#if (UNITY_4_0 || UNITY_4_0_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_5 || UNITY_4_6)
#define EPlus_4
#else
#define EPlus_5
#endif

using UnityEngine;
using UnityEditor;
using System.Collections;

#pragma warning disable 618



namespace EditorPlus
{
    public class EditorPlusShortcutsUI : EditorWindow
    {
        private static EditorPlusShortcutsUI window;

        private static Vector2 StartMargin = new Vector2(6, 6);

        private static Vector2 ButtonMargin = new Vector2(6f, 4f);

        private static Vector2 ButtonSize = new Vector2(120f, 20f);

        private static bool init = false;

        private static GUISkin ShortcutsSkin;

#if EPlus_5
        [MenuItem("Window/EditorPlus/ShortcutsUI")]
#endif
        static public void Init()
        {
            init = true;
            window = (EditorPlusShortcutsUI)EditorWindow.GetWindow(typeof(EditorPlusShortcutsUI));
            window.title = "ShortcutsUI";
            window.minSize = new Vector2(StartMargin.x + ButtonSize.x + ButtonMargin.x, StartMargin.y + ButtonSize.y + ButtonMargin.y);
            LoadResources();

            EditorPlus.OnSkinSwitched += LoadResources;
        }

        static public void LoadResources()
        {
            ShortcutsSkin = Resources.Load(EditorPlus.SelectedSkinFolder + "UnityPlusSkinShortcuts") as GUISkin;

            if (window != null)
                window.Repaint();
        }



        void OnGUI()
        {
            if (!init)
                Init();

            if (GUI.skin != ShortcutsSkin)
                GUI.skin = ShortcutsSkin;


            Vector2 posCur = StartMargin;

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Panel"))
            {
                EditorApplication.ExecuteMenuItem("GameObject/UI/Panel");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Button"))
            {
                EditorApplication.ExecuteMenuItem("GameObject/UI/Button");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Text"))
            {
                EditorApplication.ExecuteMenuItem("GameObject/UI/Text");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Image"))
            {
                EditorApplication.ExecuteMenuItem("GameObject/UI/Image");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Raw Image"))
            {
                EditorApplication.ExecuteMenuItem("GameObject/UI/Raw Image");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Slider"))
            {
                EditorApplication.ExecuteMenuItem("GameObject/UI/Slider");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Scrollbar"))
            {
                EditorApplication.ExecuteMenuItem("GameObject/UI/Scrollbar");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Toggle"))
            {
                EditorApplication.ExecuteMenuItem("GameObject/UI/Toggle");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Input Field"))
            {
                EditorApplication.ExecuteMenuItem("GameObject/UI/Input Field");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Canvas"))
            {
                EditorApplication.ExecuteMenuItem("GameObject/UI/Canvas");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Event System"))
            {
                EditorApplication.ExecuteMenuItem("GameObject/UI/Event System");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "2D Sprite"))
            {
                EditorApplication.ExecuteMenuItem("GameObject/2D Object/Sprite");
            }

        }


    }
}