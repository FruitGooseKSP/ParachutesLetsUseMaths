using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ParachutesLetsUseMaths
{
    public class CfgHandler
    {
        private List<string> cfgData;
        private List<string> custom1Entries = new List<string>();
        private List<string> custom2Entries = new List<string>();
        private List<string> custom3Entries = new List<string>();
        private List<string> custom4Entries = new List<string>();
        private List<string> custom5Entries = new List<string>();
        private List<string> custom6Entries = new List<string>();
        private List<string> custom7Entries = new List<string>();
        private List<string> custom8Entries = new List<string>();
        private List<string> custom9Entries = new List<string>();

        private string[] trimChars =
        {
            "name=",
            "gravity=",
            "airDensity=",
            "chute0=",
            "chute1=",
            "chute2=",
            "chute3=",
            "chute4=",
        


        };


        public CfgHandler(List<string> _cfgData)
        {

            cfgData = _cfgData;
            SortData();

        }


        private void SortData()
        {
            if (cfgData[0] != "DATA")
            {
                Debug.LogError("ERROR - PLUM : cfg file is not in the correct format!");
            }

            int lineCount = cfgData.Count - 1;

            for (int x = 0; x < lineCount; x++)
            {
                cfgData[x].Trim();
            }

            for (int y = 0; y < lineCount; y++)
            {
                if (cfgData[y].Contains("id=1") || cfgData[y].Contains("id=2") || cfgData[y].Contains("id=3") || cfgData[y].Contains("id=4") ||
                    cfgData[y].Contains("id=5") || cfgData[y].Contains("id=6") || cfgData[y].Contains("id=7") || cfgData[y].Contains("id=8") ||
                    cfgData[y].Contains("id=9"))
                { 
                    string idER = cfgData[y].Substring(cfgData[y].IndexOf("="), 1);

                    string string1 = idER;
                    string string2 = cfgData[y + 1].Substring(cfgData[y + 1].IndexOf("="), 10);
                    string string3 = cfgData[y + 2].Substring(cfgData[y + 2].IndexOf("="), 7);
                    string string4 = cfgData[y + 3].Substring(cfgData[y + 3].IndexOf("="), 7);
                    string string5 = cfgData[y + 4].Substring(cfgData[y + 4].IndexOf("="), 7);
                    string string6 = cfgData[y + 5].Substring(cfgData[y + 5].IndexOf("="), 7);
                    string string7 = cfgData[y + 6].Substring(cfgData[y + 6].IndexOf("="), 7);
                    string string8 = cfgData[y + 7].Substring(cfgData[y + 7].IndexOf("="), 7);
                    string string9 = cfgData[y + 8].Substring(cfgData[y + 8].IndexOf("="), 7);

                    string[] vals1 =
                    {
                        string1,
                        string2,
                        string3,
                        string4,
                        string5,
                        string6,
                        string7,
                        string8,
                        string9,
                    };

                    switch (idER)
                    {
                        case "1":
                            custom1Entries.AddRange(vals1);
                            break;
                        case "2":
                            custom2Entries.AddRange(vals1);
                            break;
                        case "3":
                            custom3Entries.AddRange(vals1);
                            break;
                        case "4":
                            custom4Entries.AddRange(vals1);
                            break;
                        case "5":
                            custom5Entries.AddRange(vals1);
                            break;
                        case "6":
                            custom6Entries.AddRange(vals1);
                            break;
                        case "7":
                            custom7Entries.AddRange(vals1);
                            break;
                        case "8":
                            custom8Entries.AddRange(vals1);
                            break;
                        case "9":
                            custom9Entries.AddRange(vals1);
                            break;
                        default:
                            Debug.LogError("ERROR - PLUM : Unable to assign cfg values to lists!");
                            break;
                    }




                }

            }

        }

        public List<string> ReturnData(int index)
        {
            switch (index)
            {
                case 0:
                    return custom1Entries;
                case 1:
                    return custom2Entries;
                case 2:
                    return custom3Entries;
                case 3:
                    return custom4Entries;
                case 4:
                    return custom5Entries;
                case 5:
                    return custom6Entries;
                case 6:
                    return custom7Entries;
                case 7:
                    return custom8Entries;
                case 8:
                    return custom9Entries;
                default:
                    return null;

               
            }



        }







    }
}
