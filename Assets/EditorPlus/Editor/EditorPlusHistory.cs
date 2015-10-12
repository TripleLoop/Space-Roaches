using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

#pragma warning disable 618

namespace EditorPlus
{
    public class EditorPlusHistory : EditorWindow
    {
        private static EditorPlusHistory window;

        private static Vector2 StartMargin = new Vector2(0f, 10f);

        private static Vector2 ButtonMargin = new Vector2(5f, 3f);

        private static Vector2 ButtonSize = new Vector2(130f, 20f);

        private static Vector2 LockButtonSize = new Vector2(25f, 20f);

        private static GUISkin IconsSkin;
        private static GUISkin IconsSkinFav;
        private static GUISkin IconsSkinLock;

        private static Texture LockOpen;
        private static Texture LockClosed;

        private static bool init = false;

        private static int historySize = 50;

        private static float notifyHistoryTimer = 0.5f;

        private static float notifyHistoryTime = 0f;

        [SerializeField]
        public List<Object> history = new List<Object>();

        [SerializeField]
        public List<Object> favorites = new List<Object>();

        void OnEnable()
        {
            Load();
        }


        [MenuItem("Window/EditorPlus/History")]
        static public void Init()
        {
            init = true;
            window = (EditorPlusHistory)EditorWindow.GetWindow(typeof(EditorPlusHistory));
            window.title = "History & Favs";
            window.minSize = new Vector2(window.minSize.x, 57);

			EditorPlus.OnSkinSwitched += Load;
        }

        static public void Load()
        {
            IconsSkin = Resources.Load(EditorPlus.SelectedSkinFolder + "UnityPlusSkinHistory") as GUISkin;
            IconsSkinFav = Resources.Load(EditorPlus.SelectedSkinFolder + "UnityPlusSkinHistoryFav") as GUISkin;
            IconsSkinLock = Resources.Load(EditorPlus.SelectedSkinFolder + "UnityPlusSkinHistoryLock") as GUISkin;

            LockOpen = Resources.Load("EditorPlusLockOpen") as Texture;
            LockClosed = Resources.Load("EditorPlusLockClosed") as Texture;

            if (window != null)
                window.Repaint();

        }


        void OnSelectionChange()
        {
            if (Selection.activeObject != null)
            {
                if (history.Contains(Selection.activeObject))
                    history.Remove(Selection.activeObject);

                history.Insert(0, Selection.activeObject);
                while (history.Count > historySize)
                    history.RemoveAt(historySize);

                notifyHistoryTime = Time.realtimeSinceStartup + notifyHistoryTimer;

                Repaint();
            }
        }

        void OnInspectorUpdate()
        {
            Repaint();
        }

        void OnGUI()
        {
            if (!init)
                Init();

            Vector2 posCur = StartMargin;
            bool selected = false;
            Event e = Event.current;

            //-----------------------------------------------
            //draw favorites
            for (int i = 0; i < favorites.Count; ++i)
            {
                if (GUI.skin != IconsSkinFav)
                    GUI.skin = IconsSkinFav;

                if (favorites[i] == null)
                {
                    favorites.RemoveAt(i);
                    --i;
                    continue;
                }

                GUIContent cnt = new GUIContent(favorites[i].name);

                cnt.image = AssetPreview.GetAssetPreview(favorites[i]);
                if (cnt.image == null)
                {
                    cnt.image = AssetDatabase.GetCachedIcon(AssetDatabase.GetAssetPath(favorites[i]));
                    
                }
                Rect lockButton = new Rect(0f, 0f, 0f, 0f);

				LockButtonSize.x = LockClosed.width;

                if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window, LockButtonSize, ref lockButton), cnt))
                {
                    Selection.activeObject = favorites[i];

                    selected = true;

                    if (Selection.activeObject.GetType() != typeof(UnityEngine.GameObject))
                        EditorGUIUtility.PingObject(Selection.activeObject);
                }
                lockButton.width = LockClosed.width;
                lockButton.height = LockClosed.height;
                lockButton.y += 5;

                if (GUI.skin != IconsSkinLock)
                    GUI.skin = IconsSkinLock;

                if (GUI.Button(lockButton, LockClosed))
                {
                    favorites.RemoveAt(i);
                    --i;
                    selected = true;
                    continue;
                }
            }


            if (favorites.Count != 0)
            {
                if (posCur.x != StartMargin.x)
                {
                    posCur.x = StartMargin.x;
                    posCur.y += ButtonSize.y + ButtonMargin.y;
                }
            }


            if (GUI.skin != IconsSkin)
                GUI.skin = IconsSkin;



            //-----------------------------------------------
            //draw history
            for (int i = 0; i < history.Count; ++i)
            {
                if (GUI.skin != IconsSkin)
                    GUI.skin = IconsSkin;

                if (history[i] == null || favorites.Contains(history[i]))
                {
                    history.RemoveAt(i);
                    --i;
                    continue;
                }

                GUIContent cnt = new GUIContent(history[i].name);
                cnt.image = AssetPreview.GetAssetPreview(history[i]);
                if (cnt.image == null)
                {
                    cnt.image = AssetDatabase.GetCachedIcon(AssetDatabase.GetAssetPath(history[i]));
                }

                Rect lockButton = new Rect(0f, 0f, 0f, 0f);

                LockButtonSize.x = LockOpen.width;

                if (GUI.Button(EditorPlus.GetScaledButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window, LockButtonSize, ref lockButton), cnt, ((i == 0 && notifyHistoryTime > Time.realtimeSinceStartup) ? new GUIStyle(GUI.skin.box) : new GUIStyle(GUI.skin.button))))
                {
                    if (e.button == 1 || e.button == 2)
                    {
                        if(e.button == 2)
                            favorites.Add(history[i]);
                        history.RemoveAt(i);
                        --i;
                        selected = true;
                        continue;
                    }
                    else
                    {
                        Selection.activeObject = history[i];
                        selected = true;

                        if (Selection.activeObject.GetType() != typeof(UnityEngine.GameObject))
                            EditorGUIUtility.PingObject(Selection.activeObject);
                    }

                }

                lockButton.width = LockOpen.width;
                lockButton.height = LockOpen.height;
                lockButton.y += 5;

                if (GUI.skin != IconsSkinLock)
                    GUI.skin = IconsSkinLock;


                if (GUI.Button(lockButton, LockOpen))
                {
                    favorites.Add(history[i]);
                    history.RemoveAt(i);
                    --i;
                    selected = true;
                    continue;
                }
            }
            //Reset Inspector if mouse up inside the window but not on button
            
            bool inside = false;
            if (e.mousePosition.x > 0f && e.mousePosition.x < window.position.width && e.mousePosition.y > 0f && e.mousePosition.y < window.position.height)
            {
                inside = true;
            }
            if (inside && !selected && e.rawType == EventType.MouseUp)
            {
                Selection.activeObject = null;
                e.Use();
            }
        }
    }
}