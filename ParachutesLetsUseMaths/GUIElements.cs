using KSP.UI.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ParachutesLetsUseMaths
{
    [KSPAddon(KSPAddon.Startup.EveryScene, false)]
    public class GUIElements : MonoBehaviour
    {

        public Texture btnTxtOn;
        public Texture btnTxtOff;

        public static ApplicationLauncherButton plumBtn;
        public static bool btnIsPressed;
        public static bool btnIsPresent;
        public static bool closeBtn;
        public static Rect guiPos;
        public Vector2 menuPosition;
        public Vector2 menuSize;





        public void Start()
        {
            if (HighLogic.LoadedSceneIsEditor)
            {
                if (plumBtn != null)
                {
                    onDestroy();
                    plumBtn = null;
                }

                btnTxtOff = GameDatabase.Instance.GetTexture("FruitKocktail/VertikalSpeedIndicator/Icons/vsioff", false);
                btnTxtOn = GameDatabase.Instance.GetTexture("FruitKocktail/VertikalSpeedIndicator/Icons/vsioff", false);

                menuSize = new Vector2(800, 600);
                menuPosition = new Vector2((Screen.width / 2) - (menuSize.x / 2), (Screen.height / 2 ) - (menuSize.y / 2));
                guiPos = new Rect(menuPosition, menuSize);
                btnIsPressed = false;
                closeBtn = false;

                plumBtn = ApplicationLauncher.Instance.AddModApplication(onTrue, onFalse, onHover, onHoverOut, null, null,
                    ApplicationLauncher.AppScenes.FLIGHT, btnTxtOff);
                
                btnIsPresent = true;









            }






        }

        public void Update()
        {


        }

        public void MenuWindow(int WindowID)
        {





        }

        public void ItsPlumTime()
        {
            guiPos = GUI.Window(123458, guiPos, MenuWindow,
               "", new GUIStyle(HighLogic.Skin.window));



            plumBtn.SetTrue();
            btnIsPresent = true;

            if (btnIsPressed)
            {
                plumBtn.SetTrue();
            }
            else plumBtn.SetFalse();
        }



        public void OnGUI()
        {
            if (btnIsPressed)
            {
                ItsPlumTime();
            }
        }


        // button callbacks

        public void onTrue()
        {
            btnIsPressed = true;
            plumBtn.SetTexture(btnTxtOn);

        }

        public void onFalse()
        {
            // ie when clicked off
            if (btnIsPressed)
            {
                plumBtn.SetTexture(btnTxtOff);
                btnIsPressed = false;
            }
        }

        public void onHover()
        {
            // ie on hover
        }

        public void onHoverOut()
        {
            // ie when leave
        }

        public void onDestroy()
        {
            // when destroyed
            ApplicationLauncher.Instance.RemoveModApplication(plumBtn);
            plumBtn = null;
            btnIsPresent = false;
            
        }








    }
}
