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
        public string tempFileName = "plumdata.txt";
        public string pathToData;
        public string tempPathtoData;
        public List<string> cfgContents;

        private CfgHandler cfgHandler;



        public void Start()
        {
            if (HighLogic.LoadedSceneIsEditor)
            {
                try
                {
                    dataDirectory = KSPUtil.ApplicationRootPath + "/GameData/FruitKocktail/PLUM/PluginData/";
                    pathToData = dataDirectory + fileName;
                    tempPathtoData = dataDirectory + tempFileName;
                    
                }
                catch (Exception e)
                {
                    Debug.LogError("ERROR - PLUM: Unable to detect PluginData directory!");
                }
                

                if (File.Exists(pathToData))
                {
                    FileInfo fileInfo = new FileInfo(pathToData);
                    fileInfo.MoveTo(tempPathtoData);

                    cfgContents = new List<string>(File.ReadAllLines(tempPathtoData));
                   
                }
                else
                {
                    Debug.LogError("ERROR - PLUM: Unable to find plumdata.cfg!");
                }

               
                
                if (cfgContents.Count != 0)
                {
                    FileInfo fileInfo2 = new FileInfo(tempPathtoData);
                    fileInfo2.MoveTo(pathToData);

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
