using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    public static bool hasSelected;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Darak":
                        hit.collider.gameObject.GetComponent<DarakController>().ManageDarak();
                        if (TransformHandler.SelectedGameObject.GetComponentInChildren<Darak>().darakState == DarakState.IsOnTable  && !Table.DarakOnTableisSelected)
                        {
                            TransformHandler.SelectedGameObject.transform.Translate(new Vector3(0, 1, 0), Space.World);
                            Table.DarakOnTableisSelected = true;
                        }
                        else Table.SelectedOnTableTransform();
                        break;
                    case "Table":
                        if (hasSelected && Table.isEmpty)
                            TransformHandler.DarakToTable(hit.collider.gameObject);
                        break;
                    case "OpshiDarak":
                        if (hit.collider.gameObject.GetComponentInParent<OpshiDarak>().isEmpty && hasSelected )
                        {
                            TransformHandler.DarakToPaharan(hit.collider.gameObject);
                            Debug.Log(hit.collider.gameObject.GetComponentInParent<OpshiDarak>().ID);
                        }
                        Table.SelectedOnTableTransform();
                        break;
                }

            }
        }
        
    }
}
