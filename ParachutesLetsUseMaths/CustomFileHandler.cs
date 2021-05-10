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
        public int fileCount;
        public List<string> fileNames = new List<string>();



        public void Start()
        {
            if (HighLogic.LoadedSceneIsEditor)
            {
                dataDirectory = KSPUtil.ApplicationRootPath + "/GameData/FruitKocktail/PLUM/PluginData/";

                fileCount = Directory.GetFiles(dataDirectory).Length - 1;

                if (fileCount != 0)
                {
                    for (int x = 0; x < fileCount; x++)
                    {
                        fileNames.Add(Directory.GetFiles(dataDirectory)[x].ToString());
                    }
                    
                }
                



            }
            else return;
        }


        public string CustomNameDefiner()
        {
            return fileCount == 0 ? "Custom 1" : fileNames[0];

        }

    }
}
