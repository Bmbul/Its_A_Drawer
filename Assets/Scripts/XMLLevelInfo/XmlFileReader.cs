using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Linq;
public class XmlFileReader : MonoBehaviour
{
    XmlDocument levelDoc;
    static public List<List<Paharan>> levelArray;

    //used in Start function, could not put in start
    string darakColor;
    int ordernumber;

    void Start()
    {
        #region Fields
        levelDoc = new XmlDocument();
        levelArray = new List<List<Paharan>>();
        List<Paharan> paharanList;
        #endregion

        #region Xml logic 
        TextAsset xmlFile = Resources.Load("GameData/GameData") as TextAsset;
        levelDoc.LoadXml(xmlFile.text);
        XmlNodeList levelList = levelDoc.GetElementsByTagName("level");
        foreach (XmlNode levelData in levelList)
        {
            XmlNodeList levelInfo = levelData.ChildNodes;
            paharanList = new List<Paharan>();

            foreach (XmlNode data in levelInfo)
            {
                if (data.Name == "paharan")
                {
                    XmlNodeList paharanInfo = data.ChildNodes;
                    foreach (XmlNode element in paharanInfo)
                    {
                        if (element.Name == "color")
                        {
                            Color PaharanColor = element.InnerText.StringToColorVector().StringToColor();
                            paharanList.Add(new Paharan(PaharanColor));
                        }
                        else if(element.Name == "darak")
                        {
                            XmlNodeList darakInfo = element.ChildNodes;
                            foreach(XmlNode darakElement in darakInfo)
                            {

                                if(darakElement.Name == "color")
                                {
                                    darakColor = darakElement.InnerText;
                                }
                                else if(darakElement.Name == "order")
                                {
                                    ordernumber = int.Parse(darakElement.InnerText);
                                }
                            }
                            using (DarakController tempDarak = new GameObject().AddComponent<DarakController>())
                            {
                                paharanList[paharanList.Count - 1].darakList.Add((Darak)tempDarak.TempKeepData(darakColor, ordernumber));
                            }         
                        }
                    }
                }
            }
            levelArray.Add(paharanList);
        }
        #endregion
    }
}

