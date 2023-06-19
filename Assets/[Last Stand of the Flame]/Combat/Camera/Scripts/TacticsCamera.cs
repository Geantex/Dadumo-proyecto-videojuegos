using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsCamera : MonoBehaviour
{
    public void RotateLeft()
    {
        transform.Rotate(Vector3.up, 90, Space.Self);
        //Camera.main.transform.Translate(-686,-256,6);
    }

    public void RotateRight()
    {
        transform.Rotate(Vector3.up, -90, Space.Self);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateRight();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateLeft();
        }
    }
}
