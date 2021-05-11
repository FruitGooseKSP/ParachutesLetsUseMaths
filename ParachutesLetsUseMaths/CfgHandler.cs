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

            int lineCount = cfgData.Count;

            for (int x = 0; x < lineCount; x++)
            {
                cfgData[x] = cfgData[x].Trim();
                cfgData[x] = cfgData[x].Replace(" ", "");
            }

            for (int y = 0; y < lineCount; y++)
            {
                Debug.LogError("cfConfig[y] = " + cfgData[y]);

                if (cfgData[y].Contains("id"))
                {
                    Debug.LogError("contains id");

                    
                    int posOfE = cfgData[y].IndexOf("=") + 1;
                    string buildStr1 = cfgData[y].Substring(posOfE, 1);
                    string string1 = buildStr1.Trim();


                    posOfE = cfgData[y + 1].IndexOf("=") + 1;
                    int lengthOS = cfgData[y + 1].Length;
                    Debug.LogError("lenthOS = " + lengthOS);
                    buildStr1 = cfgData[y + 1].Substring(posOfE, lengthOS);
                    string string2 = buildStr1.Trim();

                    
                    posOfE = cfgData[y + 2].IndexOf("=") + 1;
                    buildStr1 = cfgData[y + 2].Substring(posOfE, 7);
                    string string3 = buildStr1.Trim();

                   
                    posOfE = cfgData[y + 3].IndexOf("=") + 1;
                    buildStr1 = cfgData[y + 3].Substring(posOfE, 7);
                    string string4 = buildStr1.Trim();

                    
                    posOfE = cfgData[y + 4].IndexOf("=") + 1;
                    buildStr1 = cfgData[y + 4].Substring(posOfE, 7);
                    string string5 = buildStr1.Trim();

                   
                    posOfE = cfgData[y + 5].IndexOf("=") + 1;
                    buildStr1 = cfgData[y + 5].Substring(posOfE, 7);
                    string string6 = buildStr1.Trim();

                   
                    posOfE = cfgData[y + 6].IndexOf("=") + 1;
                    buildStr1 = cfgData[y + 6].Substring(posOfE, 7);
                    string string7 = buildStr1.Trim();

                   
                    posOfE = cfgData[y + 7].IndexOf("=") + 1;
                    buildStr1 = cfgData[y + 7].Substring(posOfE, 7);
                    string string8 = buildStr1.Trim();

                    
                    posOfE = cfgData[y + 8].IndexOf("=") + 1;
                    buildStr1 = cfgData[y + 8].Substring(posOfE, 7);
                    string string9 = buildStr1.Trim();

                    Debug.LogError(string1);
                    Debug.LogError(string2);
                    Debug.LogError(string3);
                    Debug.LogError(string4);
                    Debug.LogError(string5);
                    Debug.LogError(string6);
                    Debug.LogError(string7);
                    Debug.LogError(string8);
                    Debug.LogError(string9);


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

                    switch (string1)
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

            Debug.Log("cust1 count = " + custom1Entries.Count);
            Debug.Log("cust2 count = " + custom2Entries.Count);
            Debug.Log("cust3 count = " + custom3Entries.Count);
            Debug.Log("cust4 count = " + custom4Entries.Count);
            Debug.Log("cust5 count = " + custom5Entries.Count);
            Debug.Log("cust6 count = " + custom6Entries.Count);
            Debug.Log("cust7 count = " + custom7Entries.Count);
            Debug.Log("cust8 count = " + custom8Entries.Count);
            Debug.Log("cust9 count = " + custom9Entries.Count);

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
