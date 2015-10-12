using UnityEngine;
using UnityEditor;
using System.Collections;

#pragma warning disable 618

namespace EditorPlus
{

    public class EditorPlusShortcuts : EditorWindow
    {
        private static EditorPlusShortcuts window;

        private static Vector2 StartMargin = new Vector2(6, 6f);

        private static Vector2 ButtonMargin = new Vector2(6f, 4f);

        private static Vector2 ButtonSize = new Vector2(120f, 20f);

        private static bool init = false;


        private static GUISkin ShortcutsSkin;


        [MenuItem("Window/EditorPlus/Shortcuts")]
        static public void Init()
        {
            init = true;
            window = (EditorPlusShortcuts)EditorWindow.GetWindow(typeof(EditorPlusShortcuts));
            window.title = "Shortcuts";
            window.minSize = new Vector2(StartMargin.x + ButtonSize.x + ButtonMargin.x, StartMargin.y + ButtonSize.y + ButtonMargin.y);

            LoadResources();

            EditorPlus.OnSkinSwitched += LoadResources;
        }


        static public void LoadResources()
        {
            ShortcutsSkin = Resources.Load(EditorPlus.SelectedSkinFolder + "UnityPlusSkinShortcuts") as GUISkin;
            window.Repaint();
        }

        void OnGUI()
        {
            if (!init)
                Init();

            if (GUI.skin != ShortcutsSkin)
                GUI.skin = ShortcutsSkin;


            Vector2 posCur = StartMargin;

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Player settings"))
            {
                EditorApplication.ExecuteMenuItem("Edit/Project Settings/Player");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Quality settings"))
            {
                EditorApplication.ExecuteMenuItem("Edit/Project Settings/Quality");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Input settings"))
            {
                EditorApplication.ExecuteMenuItem("Edit/Project Settings/Input");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Snap settings"))
            {
                EditorApplication.ExecuteMenuItem("Edit/Snap Settings...");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Physics settings"))
            {
                EditorApplication.ExecuteMenuItem("Edit/Project Settings/Physics ");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Physics 2D"))
            {
                EditorApplication.ExecuteMenuItem("Edit/Project Settings/Physics 2D");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Asset Store"))
            {
                EditorApplication.ExecuteMenuItem("Window/Asset Store");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Occl. Culling"))
            {
                EditorApplication.ExecuteMenuItem("Window/Occlusion Culling");
            }

            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Lighting"))
            {
                EditorApplication.ExecuteMenuItem("Window/Lighting");
            }

            /// IF YOU WANT TO ADD A NEW SHORTCUT, JUST COPY THE FOLLOWING 4 LINES, CHANGE THE BUTTON NAME AND INPUT THE DIRECTORY, DONE!  // -------------------------------HERE !
            if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window), "Profiler"))
            {
                EditorApplication.ExecuteMenuItem("Window/Profiler");
            }


            /// YOU CAN ALSO DELETE THE ONES YOU DO NOT WANT - HAVE FUN!
            /// Save afterwards and keep line endings at best. (Note: Certain Menus seem to be locked by Unity (File/Build Settings...) per example)











        }
    }

}