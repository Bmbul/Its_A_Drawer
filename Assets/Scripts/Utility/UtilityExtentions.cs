using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilityExtentions
{
    public static void GenerateID<T>(this T element, string color, int order)
        where T:AbstractGenerator
    {
        element.ID = color + order;
    }
}
