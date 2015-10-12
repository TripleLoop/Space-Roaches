using UnityEngine;
using UnityEditor;
using System.Collections;


namespace EditorPlus
{
    public static class EditorPlus
    {

        public static string[] skinfolder = { "Skin_1/", "Skin_2/", "Skin_3/", "Skin_4/", "Skin_5/" };


        private static int selectedId = 0;


        public static int SelectedSkinId
        {
            set
            {
                SwitchSkin(value);
            }
            get
            {
                return selectedId;
            }
        }

        public static string SelectedSkinFolder = skinfolder[0];


        public delegate void ReloadResources();


        public static ReloadResources OnSkinSwitched;



        static EditorPlus()
        {
            SwitchSkin(EditorPrefs.GetInt("SelectedSkin", 0));
        }


        public static bool SwitchSkin(int skinId)
        {
            if (skinId < 0 || skinId >= skinfolder.Length || skinId == selectedId)
            {
                return false;
            }

            selectedId = skinId;
            SelectedSkinFolder = skinfolder[selectedId];

            EditorPrefs.SetInt("SelectedSkin", skinId);

            if (OnSkinSwitched != null)
            {
                OnSkinSwitched();
            }

            return true;
        }


        [MenuItem("Window/EditorPlus/Skins/Light 1")]
        static public void Skin1()
        {
            SwitchSkin(0);
        }


        [MenuItem("Window/EditorPlus/Skins/Light 2")]
        static public void Skin2()
        {
            SwitchSkin(1);
        }


        [MenuItem("Window/EditorPlus/Skins/Light 3")]
        static public void Skin3()
        {
            SwitchSkin(2);
        }

        [MenuItem("Window/EditorPlus/Skins/Dark 1")]
        static public void Skin4()
        {
            SwitchSkin(3);
        }

        [MenuItem("Window/EditorPlus/Skins/Dark 2")]
        static public void Skin5()
        {
            SwitchSkin(4);
        }



        public static Rect GetScaledButtonRectByPos(ref Vector2 posCur, Vector2 buttonSize, Vector2 buttonMargin, Vector2 startMargin, EditorWindow window)
        {
            float widthMinMarg = window.position.width - startMargin.x;
            float buttonSizeWithMarg = buttonSize.x + buttonMargin.x;
            float buttonsPerRow = Mathf.Floor(widthMinMarg / buttonSizeWithMarg);
            float modWidth = widthMinMarg % buttonSizeWithMarg;
            float newWidth = Mathf.Floor(buttonSize.x + modWidth / buttonsPerRow);


            if (buttonsPerRow > 0)
                buttonSize.x = newWidth;

            Rect res = new Rect(posCur.x, posCur.y, buttonSize.x, buttonSize.y);

            posCur.x += buttonSize.x + buttonMargin.x;

            if (posCur.x + buttonSize.x + buttonMargin.x > window.position.width)
            {
                posCur.x = startMargin.x;
                posCur.y += buttonSize.y + buttonMargin.y;
            }

            return res;
        }


        public static Rect GetScaledButtonRectByPos(ref Vector2 posCur, Vector2 buttonSize, Vector2 buttonMargin, Vector2 startMargin, EditorWindow window, Vector2 lockButtonSize, ref Rect lockButton)
        {
            float widthMinMarg = window.position.width - startMargin.x;
            float buttonSizeWithMarg = buttonSize.x + lockButtonSize.x + buttonMargin.x;
            float buttonsPerRow = Mathf.Floor(widthMinMarg / buttonSizeWithMarg);
            float modWidth = widthMinMarg % buttonSizeWithMarg;
            float newWidth = Mathf.Floor(buttonSize.x + modWidth / buttonsPerRow);


            if (buttonsPerRow > 0)
                buttonSize.x = newWidth;

            Rect res = new Rect(posCur.x, posCur.y, buttonSize.x, buttonSize.y);

            posCur.x += buttonSize.x;

            lockButton.x = posCur.x;
            lockButton.y = posCur.y;
            lockButton.width = lockButtonSize.x;
            lockButton.height = lockButtonSize.y;

            posCur.x += lockButton.width + buttonMargin.x;
            if (posCur.x + buttonSize.x + buttonMargin.x > window.position.width)
            {
                posCur.x = startMargin.x;
                posCur.y += buttonSize.y + buttonMargin.y;
            }

            return res;
        }


        public static Rect GetButtonRectByPos(ref Vector2 posCur, Vector2 buttonSize, Vector2 buttonMargin, Vector2 startMargin, EditorWindow window)
        {
            Rect res = new Rect(posCur.x, posCur.y, buttonSize.x, buttonSize.y);

            posCur.x += buttonSize.x + buttonMargin.x;
            if (posCur.x + buttonSize.x + buttonMargin.x > window.position.width)
            {
                posCur.x = startMargin.x;
                posCur.y += buttonSize.y + buttonMargin.y;
            }

            return res;
        }


        public static Rect GetButtonRectByPos(ref Vector2 posCur, Vector2 buttonSize, Vector2 buttonMargin, Vector2 startMargin, EditorWindow window, Vector2 lockButtonSize, ref Rect lockButton)
        {
            Rect res = new Rect(posCur.x, posCur.y, buttonSize.x, buttonSize.y);

            posCur.x += buttonSize.x;

            lockButton.x = posCur.x;
            lockButton.y = posCur.y;
            lockButton.width = lockButtonSize.x;
            lockButton.height = lockButtonSize.y;

            posCur.x += lockButton.width + buttonMargin.x;
            if (posCur.x + buttonSize.x + buttonMargin.x > window.position.width)
            {
                posCur.x = startMargin.x;
                posCur.y += buttonSize.y + buttonMargin.y;
            }

            return res;
        }
    }
}