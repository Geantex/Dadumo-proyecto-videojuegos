using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AlienCustomData
{
    public static string nombre = "";

    public static bool armado = false;

    private static int colorIndex = 0;

    private static Color[] colores = { 
        new Color(1f, 0.814f, 0.487f), 
        new Color(1f, 0.24f, 0.254f), 
        new Color(0.239f, 0.448f, 1f)
    };

    public static int ColorIndex
    {
        get
        {
            return colorIndex;
        }

        set
        {
            if (value >= colores.Length || value < 0) return;
            colorIndex = value;
        }
    }
    public static Color Color
    {
        get
        {
            return colores[colorIndex];
        }
    }
}
