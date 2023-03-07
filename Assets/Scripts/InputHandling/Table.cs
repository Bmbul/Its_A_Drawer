using UnityEngine;

public class Table : MonoBehaviour
{
    public static bool isEmpty;
    public static bool DarakOnTableisSelected;
    static GameObject TableGameObject;

    private void Awake()
    {
        isEmpty = true;
        TableGameObject = this.gameObject;
    }

    public static void SelectedOnTableTransform()
    {
        if (isEmpty)
            DarakOnTableisSelected = false;
        else if (DarakOnTableisSelected)
        {
            TableGameObject.transform.Find("Daraki_Marmin").transform.Translate(new Vector3(0, -1, 0), Space.World);
            DarakOnTableisSelected = false;
        }
    }
}