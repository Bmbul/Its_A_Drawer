using UnityEngine;

public class DarakController : Darak
{
    [Range(-5, 5)]
    [SerializeField]
    float openingSize = 0;

    public void ManageDarak()
    {
        switch (darakState)
        {
            case (DarakState.Closed):
                transform.Translate(new Vector3(0, 0, openingSize), Space.World);
                darakState = DarakState.Opened;
                TouchHandler.hasSelected = true;
                TransformHandler.SelectedGameObject = this.gameObject;
                break;
            case (DarakState.Opened):
                transform.Translate(new Vector3(0, 0, -openingSize), Space.World);
                darakState = DarakState.Closed;
                if(Table.isEmpty)
                    GameManager.CheckGameState();
                TouchHandler.hasSelected = false;
                break;
            case (DarakState.NoKey):
                Debug.Log("Darak has no Key");
                break;

            case DarakState.IsOnTable:
                TransformHandler.SelectedGameObject = this.gameObject;
                TouchHandler.hasSelected = true;
                break;
        }

    }


    public Darak TempKeepData(string _color, int _order)
    {
        this.colorString = _color;
        this.order = _order;
        return this as Darak;
    }

    public void Initialize(string _color, int _order)
    {
        this.color = _color.StringToShadeVector(_order).StringToColor();
        this.order = _order;
        this.GenerateID(_color, _order);
        Recolor();
    }
    public void Recolor()
    {
        GetComponent<MeshRenderer>().materials[1].color = this.color;
        GetComponent<MeshRenderer>().materials[0].color = this.color;

    }
}
