using UnityEngine;
using System;

public static class ColorStringCast 
{
    public static  int MinShadeValue =120;

    public static Vector3 StringToColorVector(this string colorString)
    {
        switch (colorString)
        {
            case "R":
                return new Vector3(1, 0, 0);
            case "G":
                return new Vector3(0, 1, 0);
            case "B":
                return new Vector3(0, 0, 1);
            default:
                Debug.LogError("Vrong Color " + colorString);
                return Vector3.zero;
        }
    }


    public static Vector3 StringToShadeVector(this string colorString,int orderNumber)
    {
        switch (colorString)
        {

            case "R":
                return new Vector3(ColorShadeInt(orderNumber), 0, 0);
            case "G":
                return new Vector3(0,ColorShadeInt(orderNumber), 0);
            case "B":
                return new Vector3(0,0,ColorShadeInt(orderNumber));
            default:
                Debug.LogError("Vrong Color " + colorString);
                return Vector3.zero;
        }
    }

    public static string ColorToString(this Color color)
    {
        if (color.r > 0)
            return "R";
        else if (color.g > 0)
            return "G";
        else return "B";
    }

    static Func<int, float> ColorShadeInt = order => (MinShadeValue + order * 50)/256f;

    public static Color StringToColor(this Vector3 colorVector)
    {
        return new Color(colorVector.x, colorVector.y, colorVector.z);
    }
}
