using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject darakPref;
    Vector3 OriginTransform;

    static public List<GameObject> levelDarakList;


    private void Start()
    {
        darakPref = Resources.Load("Prefabs/DarakPrefab") as GameObject;
        OriginTransform = darakPref.transform.position;
    }



    #region Level Loader 
    public void LevelLoad(int level)
    {
        levelDarakList = new List<GameObject>();
        var LevelList = XmlFileReader.levelArray[level - 1];
        int levelEachPaharaniDarakCount = LevelList[0].darakList.Count;
        for (int i = 0; i < LevelList.Count; i++)
        {
            for (int j = 0; j < levelEachPaharaniDarakCount; j++)
            {
                #region setting up daraks to add LevelDarakList
                GameObject darakTmp = Instantiate
                    (darakPref, new Vector3(OriginTransform.x + i * 5f, OriginTransform.y + j * .9f, OriginTransform.z),
                    Quaternion.Euler(0, 180, 0));

                darakTmp.GetComponentInChildren<DarakController>().
                    Initialize(LevelList[i].darakList[j].colorString, LevelList[i].darakList[j].order);

                darakTmp.GetComponentInChildren<OpshiDarak>().
                    Initialize(LevelList[i].paharanColor.ColorToString(), j + 1);

                darakTmp.GetComponentInChildren<PaharanController>().
                    Recolor(LevelList[i].paharanColor);

                levelDarakList.Add(darakTmp);

                #endregion
            }
        }
    }



    #endregion

    public static void CheckGameState()
    {
        Debug.LogError("checking");
        foreach (var element in levelDarakList)
        {
            if (element.GetComponentInChildren<Darak>().ID != element.GetComponentInChildren<OpshiDarak>().ID)
                return;
        }
        Debug.Log("level Passed");
    }
}
