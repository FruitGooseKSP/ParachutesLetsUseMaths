using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

namespace ParachutesLetsUseMaths
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class CustomFileHandler : MonoBehaviour
    {
        public string dataDirectory;
        public string fileName = "plumdata.cfg";
        public List<string> cfgContents;

        private CfgHandler cfgHandler;



        public void Start()
        {
            if (HighLogic.LoadedSceneIsEditor)
            {
                try
                {
                    dataDirectory = KSPUtil.ApplicationRootPath + "/GameData/FruitKocktail/PLUM/PluginData/";
                }
                catch (Exception e)
                {
                    Debug.LogError("ERROR - PLUM: Unable to detect PluginData directory!");
                }
                

                if (File.Exists(dataDirectory + fileName))
                {
                    cfgContents = new List<string>(File.ReadAllLines(dataDirectory + fileName));
                }
                else
                {
                    Debug.LogError("ERROR - PLUM: Unable to find plumdata.cfg!");
                }

                Debug.LogError("list = " + cfgContents.Count);
                
                if (cfgContents.Count != 0)
                {
                    ProcessCfg();
                }


            }
            else return;
        }

        public void ProcessCfg()
        {
            cfgHandler = new CfgHandler(cfgContents);

        }

        public string CustomNameDefiner(int index)
        {
            List<string> grabbedList = cfgHandler.ReturnData(index);

            return grabbedList[1];

        }

        public List<string> PopulationGetter(int index)
        {
            List<string> grabbedList = cfgHandler.ReturnData(index);

            return grabbedList;
        }


        

    }
}
