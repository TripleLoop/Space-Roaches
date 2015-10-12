using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable 618

namespace EditorPlus
{
    public class EditorPlusHotbar : EditorWindow
    {
        private static EditorPlusHotbar window;

        private static bool init = false;

        private static Vector2 StartMargin = new Vector2(6f, 6f);

        private static Vector2 ButtonMargin = new Vector2(5f, 5f);

        private static Vector2 ButtonSize = new Vector2(55f, 55f);

        private static Object selectedObj;

        private const float minDistToDrag = 10f;

        private static GUISkin skin;


        [SerializeField]
        public List<Object> hotbarObjects = new List<Object>();


        [MenuItem("Window/EditorPlus/Hotbar")]
        static public void Init()
        {
            init = true;
            window = (EditorPlusHotbar)EditorWindow.GetWindow(typeof(EditorPlusHotbar));
            window.title = "Hotbar";
            window.minSize = new Vector2(StartMargin.x + ButtonSize.x + ButtonMargin.x, StartMargin.y + ButtonSize.y + ButtonMargin.y);
            skin = Resources.Load("HotbarSkin") as GUISkin;

        }

        void OnInspectorUpdate()
        {
            Repaint();
        }


        void OnGUI()
        {
            if (init == false)
                Init();

            if (GUI.skin != skin)
                GUI.skin = skin;

            Event e = Event.current;

            bool inside = false;

            if (e.mousePosition.x > 0f && e.mousePosition.x < window.position.width && e.mousePosition.y > 0f && e.mousePosition.y < window.position.height)
            {
                inside = true;
                DragAndDrop.visualMode = DragAndDropVisualMode.Link;

                if (e.rawType == EventType.DragPerform)
                {
                    foreach (Object obj in DragAndDrop.objectReferences)
                    {
                        if (!hotbarObjects.Contains(obj) && AssetDatabase.GetAssetPath(obj) != "")
                        {
                            hotbarObjects.Add(obj);
                        }
                        else
                        {
                            Selection.activeObject = selectedObj;
                        }
                    }
                }
            }

            if (e.isKey && e.keyCode == KeyCode.Delete && selectedObj != null)
            {
                hotbarObjects.Remove(selectedObj);
            }


            //reset
            if (e.rawType == EventType.MouseDown)
            {
                selectedObj = null;
            }

            Vector2 posCur = StartMargin;

            bool selectedThisFrame = false;

            for (int i = 0; i < hotbarObjects.Count; ++i)
            {
                if (hotbarObjects[i] == null)
                {
                    hotbarObjects.RemoveAt(i);
                    --i;
                    continue;
                }
                GUIContent cnt = new GUIContent(AssetPreview.GetAssetPreview(hotbarObjects[i]));

                if (cnt.image == null)
                    cnt.image = AssetDatabase.GetCachedIcon(AssetDatabase.GetAssetPath(hotbarObjects[i]));

                Rect r = EditorPlus.GetButtonRectByPos(ref posCur, ButtonSize, ButtonMargin, StartMargin, window);
                //Drag object
                if (e.rawType == EventType.MouseDown)
                {
                    if (r.Contains(e.mousePosition))
                    {
                        if (e.button == 0)
                        {
                            selectedObj = hotbarObjects[i];
                            selectedThisFrame = true;

                            DragAndDrop.PrepareStartDrag();
                            DragAndDrop.paths = new string[] { AssetDatabase.GetAssetPath(selectedObj) };
                            DragAndDrop.objectReferences = new Object[] { selectedObj };
                            DragAndDrop.StartDrag(selectedObj.ToString());
                        }
                        else if (e.button == 1)
                        {
                            hotbarObjects.RemoveAt(i);
                            --i;
                            continue;
                        }
                    }
                }
                GUI.Label(r, cnt, (selectedObj != hotbarObjects[i]) ? new GUIStyle(GUI.skin.button) : new GUIStyle(GUI.skin.box));
                cnt = new GUIContent(hotbarObjects[i].name);
                r.height = 20f;

                //drop shadow
                GUIStyle st = new GUIStyle(GUI.skin.label);
                st.normal.textColor = new Color(0.26f, 0.26f, 0.26f); //new Color(76f,76f,76f);
                r.x += 1f;
                r.y += 1f;
                GUI.Label(r, cnt, st);

                //reset
                r.x -= 1f;
                r.y -= 1f;

                //name
                GUI.Label(r, cnt);

            }

            if (inside && !selectedThisFrame && e.rawType == EventType.MouseUp)
            {
                selectedObj = null;
                Selection.activeObject = null;
            }

            if (e.isMouse && e.clickCount == 2 && selectedObj != null)
            {
                AssetDatabase.OpenAsset(selectedObj);
            }

        }
    }
}