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
        public string fileName = "data.plum";
        public string tempFileName = "data.txt";
        public string pathToData;
        public string tempPathtoData;
        public List<string> cfgContents;

        private CfgHandler cfgHandler;

        public static CustomFileHandler Instance;



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
            Instance = this;
            cfgHandler = new CfgHandler(cfgContents);

        }

       
        public void SaveData(string id, string name, string grav, string aD, string c0, string c1, string c2, string c3, string c4)
        {
            FileInfo fileInfo = new FileInfo(pathToData);
            fileInfo.MoveTo(tempPathtoData);

            cfgContents = new List<string>(File.ReadAllLines(tempPathtoData));

            int cfCount = cfgContents.Count();

            if (cfCount != 0)
            {
                for (int x = 0; x < cfCount - 1; x++)
                {
                    if (cfgContents[x].Contains("id"))
                    {
                        if (cfgContents[x].Contains(id))
                        {
                            int scPos = cfgContents[x + 1].IndexOf(";");
                            int eqPos = cfgContents[x + 1].IndexOf("=") + 1;
                            string selection = cfgContents[x + 1].Substring(eqPos, scPos - eqPos);
                            cfgContents[x + 1].Replace(selection, name);

                            scPos = cfgContents[x + 2].IndexOf(";");
                            eqPos = cfgContents[x + 2].IndexOf("=") + 1;
                            selection = cfgContents[x + 2].Substring(eqPos, scPos - eqPos);
                            cfgContents[x + 2].Replace(selection, grav);

                            scPos = cfgContents[x + 3].IndexOf(";");
                            eqPos = cfgContents[x + 3].IndexOf("=") + 1;
                            selection = cfgContents[x + 3].Substring(eqPos, scPos - eqPos);
                            cfgContents[x + 3].Replace(selection, aD);

                            scPos = cfgContents[x + 4].IndexOf(";");
                            eqPos = cfgContents[x + 4].IndexOf("=") + 1;
                            selection = cfgContents[x + 4].Substring(eqPos, scPos - eqPos);
                            cfgContents[x + 4].Replace(selection, c0);

                            scPos = cfgContents[x + 5].IndexOf(";");
                            eqPos = cfgContents[x + 5].IndexOf("=") + 1;
                            selection = cfgContents[x + 5].Substring(eqPos, scPos - eqPos);
                            cfgContents[x + 5].Replace(selection, c1);

                            scPos = cfgContents[x + 6].IndexOf(";");
                            eqPos = cfgContents[x + 6].IndexOf("=") + 1;
                            selection = cfgContents[x + 6].Substring(eqPos, scPos - eqPos);
                            cfgContents[x + 6].Replace(selection, c2);

                            scPos = cfgContents[x + 7].IndexOf(";");
                            eqPos = cfgContents[x + 7].IndexOf("=") + 1;
                            selection = cfgContents[x + 7].Substring(eqPos, scPos - eqPos);
                            cfgContents[x + 7].Replace(selection, c3);

                            scPos = cfgContents[x + 8].IndexOf(";");
                            eqPos = cfgContents[x + 8].IndexOf("=") + 1;
                            selection = cfgContents[x + 8].Substring(eqPos, scPos - eqPos);
                            cfgContents[x + 8].Replace(selection, c4);

                            break;





                        }

                    }





                }


                fileInfo.MoveTo(pathToData);




            }
            





        }

        


        

    }
}
