using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ParachutesLetsUseMaths
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class PLUM : MonoBehaviour
    {

        // this Class isn't technically needed now as everything is being handled inside GUIElements but kept for
        // future use

        public static PLUM Instance;
        public static GUIElements guiPlum = new GUIElements();
        public PlumUtilities utils;

        public void Start()
        {
            if (HighLogic.LoadedSceneIsEditor)
            {
                Instance = this;
                utils = new PlumUtilities();

            }
            else return;


        }


    }
}
