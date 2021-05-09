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
        // the selected body
        [KSPField(isPersistant = true)]
        public static int celPick;

        // the selected velocity
        [KSPField(isPersistant = true)]
        public static int calcPick;

        public static float customGravVal = 0.01f;

        // toolbar button textures
        public Texture btnTxtOn;
        public Texture btnTxtOff;

        // the utilities class
        public PlumUtilities pUtils = new PlumUtilities();

        // do we have chutes?
        public bool chutesOnboard;

        // how many?
        public int chuteCount;

        // the toolbar button
        public static ApplicationLauncherButton plumBtn;

        // has the button been pressed?
        public static bool btnIsPressed;

        // is the button visible?
        public static bool btnIsPresent;

        //close button for the menu
        public static bool closeBtn;

        // options button
        public static bool optionsBtn;
        public static bool optionsPressed;

        public static bool btnAdd1A;
        public static bool btnMinus1A;
     
        public string gravityCustom;

        // menu name holders
        public static Rect guiPos;
        public Vector2 menuPosition;
        public Vector2 menuSize;

        public static Rect optPos;
        public Vector2 optPosition;
        public Vector2 optSize;

        // the bodies to pick from
        public static string[] bodies =
        {
            "Kerbin",
            "Eve",
            "Duna",
            "Laythe",
            "Custom",
        };

        // the velocities to chose from
        public static string[] velChoices =
        {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
        };

        // custom GUIStyles
        public GUIStyle styleBtn;
        public GUIStyle styleLabel;
        public GUIStyle styleLabel2;
        public GUIStyle styleLabel3;
        public GUIStyle styleToggle;
        public GUIStyle styleToggle2;
        public GUIStyle styleBox;
        public GUIStyle styleOptionBtn;
        public GUIStyle styleTextField;


        public void Start()
        {
            if (HighLogic.LoadedSceneIsEditor)
            {
                if (plumBtn != null)
                {
                    onDestroy();
                    plumBtn = null;
                }

                // set the textures
                btnTxtOff = GameDatabase.Instance.GetTexture("FruitKocktail/PLUM/Icons/plumOn", false);
                btnTxtOn = GameDatabase.Instance.GetTexture("FruitKocktail/PLUM/Icons/plumOff", false);

                // define the menu particulars
                menuSize = new Vector2(800, 550);
                menuPosition = new Vector2((Screen.width / 2) - (menuSize.x / 2), (Screen.height / 2) - (menuSize.y / 2));
                guiPos = new Rect(menuPosition, menuSize);

                // define options menu particulars
                optSize = new Vector2(400, 550);
                optPosition = new Vector2(menuPosition.x + menuSize.x, menuPosition.y);
                optPos = new Rect(optPosition, optSize);

                btnIsPressed = false;
                closeBtn = false;
                optionsBtn = false;
                gravityCustom = "";

                // instantiate the button
                plumBtn = ApplicationLauncher.Instance.AddModApplication(onTrue, onFalse, onHover, onHoverOut, null, null,
                    ApplicationLauncher.AppScenes.VAB | ApplicationLauncher.AppScenes.SPH, btnTxtOff);

                btnIsPresent = true;


                if (calcPick == 0)
                {
                    calcPick = 8;
                }


                


                // define our custom styles

                styleBtn = new GUIStyle(HighLogic.Skin.button);

                styleLabel = new GUIStyle(HighLogic.Skin.label);

                styleLabel2 = new GUIStyle(HighLogic.Skin.label)
                {
                    margin = new RectOffset(50, 50, 25, 25),
                };

                styleLabel2.normal.textColor = Color.white;

                styleLabel3 = new GUIStyle(HighLogic.Skin.label)
                {
                    margin = new RectOffset(50, 50, 25, 25),
                    fontStyle = FontStyle.Bold,
                };

                styleToggle = new GUIStyle(HighLogic.Skin.toggle)
                {
                    margin = new RectOffset(75, 75, 25, 25),
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

                styleOptionBtn = new GUIStyle(HighLogic.Skin.button);

                styleTextField = new GUIStyle(HighLogic.Skin.textField);

                
                
                

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

                    if (optionsBtn && !optionsPressed)
                    {
                        optionsPressed = true;
                        optionsBtn = false;
                    }

                    if (optionsBtn && optionsPressed)
                    {
                        optionsPressed = false;
                        optionsBtn = false;
                    }

                    if (optionsPressed)
                    {
                        Vector2 newMenuPos = new Vector2(guiPos.x, guiPos.y);

                        optPos.x = newMenuPos.x + menuSize.x;
                        optPos.y = newMenuPos.y;


                        if (btnAdd1A)
                        {
                            customGravVal += 0.01f;
                            customGravVal = float.Parse(Math.Round(double.Parse(customGravVal.ToString()), 2).ToString());
                            btnAdd1A = false;
                        }
                        
                        if (btnMinus1A)
                        {
                            if (customGravVal > 0.01f)
                            {
                                customGravVal -= 0.01f;
                                customGravVal = float.Parse(Math.Round(double.Parse(customGravVal.ToString()), 2).ToString());
                                btnMinus1A = false;
                            }
                            else
                            {
                                btnMinus1A = false;
                            }
                        }

                        




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

        // Gets the amount of chutes currently on our vessel
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

        // Gets our ships mass. This figure differs from the Engineer's Report, but that figure seems locked out

        public static string GetVesselMass()
        {
            if (btnIsPressed)
            {
                EditorLogic.fetch.ship.GetShipMass(out float vesDM, out float vesWM);
                float totalMass = (vesDM + vesWM) * 1000;  // convert from tons to KG

                return totalMass.ToString();
            }

            else return null;
        }

        // Get atmospheric pressure for out chosen planet
        public string GetATD() => pUtils.FetchATD(celPick);

        // Get surface gravity
        public string GetSurfaceGravity() => pUtils.FetchSG(celPick);


        // Get chute power modifier
        public string GetBValue()
        {
            if (chutesOnboard)
            {
                chuteCount = int.Parse(GetParachuteQty());

                if (chuteCount == 1)
                {
                    double runningTotal = 0;

                    foreach (var part in EditorLogic.fetch.ship.parts)
                    {
                        if (part.HasModuleImplementing<ModuleParachute>())
                        {
                            string name = part.name;
                            int paraCode;

                            switch (name)
                            {
                                case "parachuteSingle":
                                    paraCode = 0;
                                    break;
                                case "parachuteRadial":
                                    paraCode = 1;
                                    break;
                                case "parachuteLarge":
                                    paraCode = 2;
                                    break;
                                case "parachuteDrogue":
                                    paraCode = 3;
                                    break;
                                case "radialDrogue":
                                    paraCode = 4;
                                    break;
                                case "tantares_parachute_s0_1":
                                    paraCode = 0;
                                    break;
                                default:
                                    paraCode = 0;
                                    break;
                            }

                            runningTotal = pUtils.BCodeBase(celPick, paraCode);
                        }
                    }

                    return runningTotal.ToString();
                }

                else
                {
                    return "Multiple Chutes";
                }
            }
            else return null;
        }

        // calculate the velocity
        public string GetTDVelocity()
        {
            if (chutesOnboard)
            {
                if (chuteCount == 1)
                {
                    double m = double.Parse(GetVesselMass());
                    double b = double.Parse(GetBValue());

                    double touchDownVelocity = Math.Sqrt(m * b);                                            // square root of mass * parachute power force
                    double tD2 = Math.Round((touchDownVelocity * 2), MidpointRounding.AwayFromZero);        // this to
                    touchDownVelocity = tD2 / 2;                                                            // round to nearest 0.5

                    // change the text colour depending on result

                    styleLabel3.normal.textColor = touchDownVelocity > calcPick ? Color.red : Color.green;

                    return touchDownVelocity.ToString();
                }
                else
                {
                    //  v = sqrt(m * (1 / (n(^?x) / b)) guide formula

                    double m = double.Parse(GetVesselMass());
                    int type0Count = 0;
                    int type1Count = 0;
                    int type2Count = 0;
                    int type3Count = 0;
                    int type4Count = 0;

                    // find how many of each type of parachute onboard

                    foreach (var part in EditorLogic.fetch.ship.parts)
                    {
                        if (part.HasModuleImplementing<ModuleParachute>())
                        {
                            string name = part.name;

                            switch (name)
                            {
                                case "parachuteSingle":
                                    type0Count += 1;
                                    break;
                                case "parachuteRadial":
                                    type1Count += 1;
                                    break;
                                case "parachuteLarge":
                                    type2Count += 1;
                                    break;
                                case "parachuteDrogue":
                                    type3Count += 1;
                                    break;
                                case "radialDrogue":
                                    type4Count += 1;
                                    break;
                                case "tantares_parachute_s0_1":
                                    type0Count += 1;
                                    break;
                                default:
                                    type0Count += 1;
                                    break;
                            }
                        }
                    }

                    double t0RT = pUtils.GetMulti(celPick, 0, type0Count);
                    double t1RT = pUtils.GetMulti(celPick, 1, type1Count);
                    double t2RT = pUtils.GetMulti(celPick, 2, type2Count);
                    double t3RT = pUtils.GetMulti(celPick, 3, type3Count);
                    double t4RT = pUtils.GetMulti(celPick, 4, type4Count);

                    double multiB = t0RT + t1RT + t2RT + t3RT + t4RT;

                    double vel = Math.Sqrt(m * (1 / multiB));                                   // sq root of mass * 1/multi parachute force
                    double vel2 = Math.Round((vel * 2), MidpointRounding.AwayFromZero);         // this to
                    vel = vel2 / 2;                                                             // round to nearest 0.5

                    styleLabel3.normal.textColor = vel > calcPick ? Color.red : Color.green;    // set text colour according to result

                    return vel.ToString();

                }
            }
            else
            {
                styleLabel3.normal.textColor = Color.grey;                              // if no chutes onboard, grey out the result line
                return "";
            }
        }



        // GUI Menu Window
        public void MenuWindow(int WindowID)
        {
            GUI.BeginGroup(new Rect(0, 0, menuSize.x, menuSize.y));

            GUI.Box(new Rect(0, 0, menuSize.x, menuSize.y), GUIContent.none);

            closeBtn = GUI.Button(new Rect(menuSize.x - 35, 0, 35, 35), "X", styleBtn);
            optionsBtn = GUI.Button(new Rect(menuSize.x - 70, 0, 35, 35), GameDatabase.Instance.GetTexture("FruitKocktail/PLUM/Icons/plumOn", false), styleOptionBtn);

                GUI.Label(new Rect(50, 35, menuSize.x - 100, 25), "Select Celestial Body:", styleLabel);
                celPick = GUI.SelectionGrid(new Rect(50, 70, menuSize.x - 100, 25), celPick, bodies, 5, styleToggle);

                GUI.Label(new Rect(50, 125, menuSize.x - 100, 25), "Choose Maximum Velocity: " + calcPick + " m/s", styleLabel);
                calcPick = (int)GUI.HorizontalSlider(new Rect(50, 170, menuSize.x - 100, 25), calcPick, 0, 10, new GUIStyle(HighLogic.Skin.horizontalSlider),
                    new GUIStyle(HighLogic.Skin.horizontalSliderThumb));

                GUI.Label(new Rect(50, 225, menuSize.x - 100, 25), "Calculations", styleLabel);
                GUI.Box(new Rect(50, 250, menuSize.x - 100, 200), GUIContent.none, styleBox);
                GUI.Label(new Rect(75, 275, menuSize.x - 150, 25), "Parachute Quantity = " + GetParachuteQty(), styleLabel2);
                GUI.Label(new Rect(75, 300, menuSize.x - 150, 25), "Vessel (Wet) Mass, Kg = " + GetVesselMass(), styleLabel2);
                GUI.Label(new Rect(75, 325, menuSize.x - 150, 25), "Atomospheric Pressure, kPa = " + GetATD(), styleLabel2);
                GUI.Label(new Rect(75, 350, menuSize.x - 150, 25), "Surface Gravity, m/s2 = " + GetSurfaceGravity(), styleLabel2);
                GUI.Label(new Rect(75, 375, menuSize.x - 150, 25), "Parachute Magnitude Factor, bPmf = " + GetBValue(), styleLabel2);
                GUI.Label(new Rect(75, 400, menuSize.x - 150, 25), "Approximate Touchdown Velocity, m/s = " + GetTDVelocity(), styleLabel3);

                //     closeBtn = GUI.Button(new Rect(menuSize.x - 150, menuSize.y - 75, 100, 50), "Close", styleBtn);
           

            GUI.DragWindow();

            GUI.EndGroup();

        }

        public void OptionsWindow(int _windowID)
        {
            GUI.BeginGroup(new Rect(0, 0, optSize.x, optSize.y));
            GUI.Box(new Rect(0, 0, optSize.x, optSize.y), GUIContent.none);

            GUI.Label(new Rect(50, 35, optSize.x - 100, 25), "Surface Gravity, m/s2 = " + customGravVal.ToString(), styleLabel);

            customGravVal = GUI.HorizontalSlider(new Rect(50, 80, optSize.x - 100, 25), customGravVal, 0, 30, new GUIStyle(HighLogic.Skin.horizontalSlider),
                    new GUIStyle(HighLogic.Skin.horizontalSliderThumb));

            if (GUI.changed)
            {
                customGravVal = float.Parse(Math.Round(double.Parse(customGravVal.ToString()), 2).ToString());
            }

            btnMinus1A = GUI.Button(new Rect(50, 115, 100, 25), "- 0.01");
            btnAdd1A = GUI.Button(new Rect(150, 115, 100, 25), "+ 0.01");


            GUI.DragWindow();

            GUI.EndGroup();
        }

     


        // show the menu
        public void ItsPlumTime()
        {
                guiPos = GUI.Window(123458, guiPos, MenuWindow,
                   "Parachutes? Let's Use Maths!", new GUIStyle(HighLogic.Skin.window));      

            plumBtn.SetTrue();
            btnIsPresent = true;

            if (btnIsPressed)
            {
                plumBtn.SetTrue();
            }
            else plumBtn.SetFalse();
        }

        public void ShowOptionsWindow()
        {
            if (optionsPressed)
            {
                optPos = GUI.Window(123459, optPos, OptionsWindow, "Custom Options", new GUIStyle(HighLogic.Skin.window));
            }
            else
            {
                optPos = new Rect(optPosition, optSize);
            }
        }
      

        // onGUI
        public void OnGUI()
        {
            if (btnIsPressed)
            {
                ItsPlumTime();
            }
            if (btnIsPressed && optionsPressed)
            {
                ShowOptionsWindow();
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
