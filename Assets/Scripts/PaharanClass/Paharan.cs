using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paharan
{
    public Color paharanColor;
    public List<Darak> darakList;

    public Paharan(Color color)
    {
        darakList = new List<Darak>();
        this.paharanColor = color;
    }
}
