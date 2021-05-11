using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

namespace ParachutesLetsUseMaths
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class PLUM : MonoBehaviour
    {

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
