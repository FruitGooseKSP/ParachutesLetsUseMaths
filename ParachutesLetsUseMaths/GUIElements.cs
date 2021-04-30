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
        public PlumUtilities pUtils = new PlumUtilities();
        public bool chutesOnboard = false;

        public static ApplicationLauncherButton plumBtn;
        public static bool btnIsPressed;
        public static bool btnIsPresent;
        public static bool closeBtn;
        public static Rect guiPos;
        public Vector2 menuPosition;
        public Vector2 menuSize;
        public static int celPick;
        public static int calcPick;
        public static int storedCel;
        public static int storedCalc;
        public static string[] bodies =
        {
            "Kerbin",
            "Eve",
            "Duna",
            "Laythe",
        };
        public static string[] calcs =
        {
            "Current Touchdown Velocity",
            "Parachutes Required For Mass",
        };

        public GUIStyle styleBtn;
        public GUIStyle styleLabel;
        public GUIStyle styleLabel2;
        public GUIStyle styleLabel3;
        public GUIStyle styleToggle;
        public GUIStyle styleToggle2;
        public GUIStyle styleBox;





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

                menuSize = new Vector2(800, 550);
                menuPosition = new Vector2((Screen.width / 2) - (menuSize.x / 2), (Screen.height / 2 ) - (menuSize.y / 2));
                guiPos = new Rect(menuPosition, menuSize);
                btnIsPressed = false;
                closeBtn = false;

                plumBtn = ApplicationLauncher.Instance.AddModApplication(onTrue, onFalse, onHover, onHoverOut, null, null,
                    ApplicationLauncher.AppScenes.VAB | ApplicationLauncher.AppScenes.SPH, btnTxtOff);
                

                btnIsPresent = true;
                celPick = 0;
                storedCel = 0;
                calcPick = 0;
                storedCalc = 0;

                styleBtn = new GUIStyle(HighLogic.Skin.button);
                styleLabel = new GUIStyle(HighLogic.Skin.label);
                styleLabel2 = new GUIStyle(HighLogic.Skin.label)
                {
                    margin = new RectOffset(50, 50, 25,25),
                    
                
                };

                styleLabel2.normal.textColor = Color.white;

                styleLabel3 = new GUIStyle(HighLogic.Skin.label)
                {
                    margin = new RectOffset(50, 50, 25, 25),
                    fontStyle = FontStyle.Bold,
                    
                };
               
                
                styleToggle = new GUIStyle(HighLogic.Skin.toggle)
                {
                    
                    margin = new RectOffset(150, 150, 25, 25),
                    stretchWidth = true,
                   
                };

                styleToggle2 = new GUIStyle(HighLogic.Skin.toggle)
                {

                    margin = new RectOffset(250, 250, 25, 25),
                    stretchWidth = true,

                };

                styleBox = new GUIStyle(HighLogic.Skin.box)
                {
                    
                    border = new RectOffset(25, 25, 25, 25),


                };






            }
            else
            {
                if (plumBtn != null)
                {
                    onDestroy();
                    plumBtn = null;
                    btnIsPresent = false;
                }
            }





        }

        public void Update()
        {
            if (HighLogic.LoadedSceneIsEditor)
            {
                if (plumBtn != null)
                {
                    if (closeBtn)
                    {
                        plumBtn.SetFalse();
                        closeBtn = false;
                    }

                    else if (btnIsPresent)
                    {
                        
                    }




                }
            }
            else
            {
                if (plumBtn != null)
                {
                    onDestroy();
                    plumBtn = null;
                    btnIsPresent = false;
                }
            }

        }

        public string GetParachuteQty()
        {
            if (btnIsPressed)
            {

                int paraCount = 0;

                foreach (var part in EditorLogic.fetch.ship.parts)
                {
                    if (part.HasModuleImplementing<ModuleParachute>())
                    {
                        part.Highlight(true);
                        paraCount += 1;
                    }
                }

                if (paraCount == 0)
                {
                    chutesOnboard = false;
                    return "No Parachutes Onboard!";
                }
                else
                {
                    chutesOnboard = true;
                    return paraCount.ToString();
                }

            }

            else return null;



        }

        public string GetVesselMass()
        {
            if (btnIsPressed)
            {
                float vesDM;
                float vesWM;
                EditorLogic.fetch.ship.GetShipMass(out vesDM, out vesWM);

                float totalMass = (vesDM + vesWM) * 1000;

                return totalMass.ToString();
            }

            else return null;
        }

        public string GetATD()
        {
           
                return pUtils.FetchATD(celPick);
          
        }

        public string GetSurfaceGravity()
        {
           
                return pUtils.FetchSG(celPick);
            
            
        }

        public string GetBValue()
        {
            if (chutesOnboard)
            {
                double runningTotal = 0;

                foreach (var part in EditorLogic.fetch.ship.parts)
                {
                    if (part.HasModuleImplementing<ModuleParachute>())
                    {
                        string name = part.name;
                        int paraCode;

                        if (name == "parachuteSingle")
                        {
                            paraCode = 0;
                        }
                        else if (name == "parachuteRadial")
                        {
                            paraCode = 1;
                        }
                        else if (name == "parachuteLarge")
                        {
                            paraCode = 2;
                        }
                        else if (name == "parachuteDrogue")
                        {
                            paraCode = 3;
                        }
                        else if (name == "radialDrogue")
                        {
                            paraCode = 4;
                        }
                        else if (name == "tantares_parachute_s0_1")
                        {
                            paraCode = 0;
                        }
                        else paraCode = 0;

                        double tempVal = pUtils.BCodeBase(celPick, paraCode);

                        runningTotal += tempVal;


                    }


                }

                return runningTotal.ToString();
            }
            else return "";

        }


        public string GetTDVelocity()
        {
            if (chutesOnboard)
            {
                double m = Double.Parse(GetVesselMass());
                double b = Double.Parse(GetBValue());
                double p = Double.Parse(GetParachuteQty());

                double touchDownVelocity = Math.Sqrt(m * (b / p));

                if (touchDownVelocity > 8)
                {
                    styleLabel3.normal.textColor = Color.red;
                }
                else
                {
                    styleLabel3.normal.textColor = Color.green;
                }

                return touchDownVelocity.ToString();
            }
            else
            {
                styleLabel3.normal.textColor = Color.grey;
                return "";
            }
        }



        public void MenuWindow(int WindowID)
        {
            GUI.BeginGroup(new Rect(0, 0, menuSize.x, menuSize.y));
            GUI.Box(new Rect(0, 0, menuSize.x, menuSize.y), GUIContent.none);

            

            GUI.Label(new Rect(50, 35, menuSize.x - 100, 25), "Select Celestial Body:", styleLabel);

            celPick = GUI.SelectionGrid(new Rect(50, 70, menuSize.x - 100, 25), celPick, bodies, 4, styleToggle);

            GUI.Label(new Rect(50, 125, menuSize.x - 100, 25), "Choose Calculation Type:", styleLabel);

            calcPick = GUI.SelectionGrid(new Rect(50, 170, menuSize.x - 100, 25), calcPick, calcs, 2, styleToggle2);

            GUI.Label(new Rect(50, 225, menuSize.x - 100, 25), "Calculations", styleLabel);

            GUI.Box(new Rect(50, 250, menuSize.x - 100, 200), GUIContent.none, styleBox);

            GUI.Label(new Rect(75, 275, menuSize.x- 150, 25), "Parachute Quantity = " + GetParachuteQty(), styleLabel2);

            GUI.Label(new Rect(75, 300, menuSize.x - 150, 25), "Vessel (Wet) Mass, Kg = " + GetVesselMass(), styleLabel2);

            GUI.Label(new Rect(75, 325, menuSize.x - 150, 25), "Atomospheric Density, kPa = " + GetATD(), styleLabel2);

            GUI.Label(new Rect(75, 350, menuSize.x - 150, 25), "Surface Gravity, m/s2 = " + GetSurfaceGravity(), styleLabel2);

            GUI.Label(new Rect(75, 375, menuSize.x - 150, 25), "Combined Parachute Magnitude Factor, bPmf = " + GetBValue(), styleLabel2);

            GUI.Label(new Rect(75, 400, menuSize.x - 150, 25), "Predicted Touchdown Velocity, m/s = " + GetTDVelocity(), styleLabel3);

            closeBtn = GUI.Button(new Rect(menuSize.x - 150, menuSize.y - 75, 100, 50), "Close", styleBtn);

            GUI.DragWindow();

            GUI.EndGroup();

        }

        public void ItsPlumTime()
        {
            guiPos = GUI.Window(123458, guiPos, MenuWindow,
               "Parachute Information", new GUIStyle(HighLogic.Skin.window));



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
                
                foreach (var part in EditorLogic.fetch.ship.parts)
                {
                    if (part.HighlightActive)
                    {
                        part.Highlight(false);
                    }
                }
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
