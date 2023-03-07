public class OpshiDarak : AbstractGenerator
{
    public bool isEmpty;



    private void Awake()
    {
        isEmpty = false;
    }
    public void Initialize(string _color, int _order)
    {
        this.GenerateID(_color, _order);
    }


}
