using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DarakState { Closed, Opened, NoKey,IsOnTable }

public enum DarakCountains { Nothing, Key, Handle }

public class Darak : AbstractGenerator,IDisposable
{
    public bool isSelected;
    public Color color;
    public DarakState darakState;

    public void Dispose()
    {
        Destroy(this.gameObject);
    }    
}
