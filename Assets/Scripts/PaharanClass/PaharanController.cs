using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaharanController : MonoBehaviour
{
    public void Recolor(Color _color)
    {
        GetComponent<MeshRenderer>().material.color = _color;
    }
}
