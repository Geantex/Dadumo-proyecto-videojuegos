using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilidades
{
    public static void CambiarColor(GameObject gameObject, Color color, string nombreMaterial = "")
    {
        Material material = gameObject.GetComponent<Renderer>().material;

        if (nombreMaterial != "")
        {
            Material[] ms = gameObject.GetComponent<Renderer>().materials;
            foreach (var item in ms)
            {
                if (item.name.Contains(nombreMaterial))
                {
                    material = item;
                }
            }
        }
        material.color = color;
    }
}
