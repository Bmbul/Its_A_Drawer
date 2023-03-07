using System;
using UnityEngine;

public class TransformHandler : MonoBehaviour
{
    public static GameObject SelectedGameObject;
    public static Vector3 Origin;
    public static Vector3 SpavnPosTransform;

    [SerializeField]
    Vector3 notStaticOffset;

    static Vector3 offset;


    private void Awake()
    {
       offset = MakeStaticVector3(notStaticOffset);
       Origin = (Resources.Load("Prefabs/TablePrefab") as GameObject).transform.position;
    }

    // Takes as an argument a Vector3 and returns a nev Vector3
    // This is being used to use inspector input of Vector3 and transfer the values to the static field 
    Func<Vector3, Vector3> MakeStaticVector3 = offsetNotStatic => new Vector3(offsetNotStatic.x, offsetNotStatic.y, offsetNotStatic.z);


    internal static void DarakToTable(GameObject collider)
    {
        if (SelectedGameObject == null)
            return;
        //read again
        SelectedTransformToTable();
        SelectedGameObject.transform.parent = collider.transform.parent;
        Table.isEmpty = false;
    }

    internal static void DarakToPaharan(GameObject collider)
    {
        if (SelectedGameObject.GetComponent<Darak>().darakState == DarakState.IsOnTable)
            Table.isEmpty = true;
        else SelectedGameObject.GetComponentInParent<OpshiDarak>().isEmpty = true;

        SelectedGameObject.GetComponent<Darak>().darakState = DarakState.Opened;
        collider.GetComponentInParent<OpshiDarak>().isEmpty = false;
        Vector3 TempVector = SelectedGameObject.transform.position;
        SelectedGameObject.transform.position = SpavnPosTransform;
        SelectedGameObject.transform.parent = collider.transform.parent;

        SpavnPosTransform = TempVector;
        TouchHandler.hasSelected = false;

    }

    static void SelectedTransformToTable()
    {
        SpavnPosTransform = SelectedGameObject.transform.position;
        SelectedGameObject.transform.position = Origin + offset;
        SelectedGameObject.GetComponent<Darak>().darakState = DarakState.IsOnTable;
        SelectedGameObject.GetComponentInParent<OpshiDarak>().isEmpty = true;
    }
}
