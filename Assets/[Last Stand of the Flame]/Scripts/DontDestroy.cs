using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DontDestroy : MonoBehaviour
{
    
    void Awake()
    {

        string tagName = this.gameObject.tag;

        GameObject[] objs = GameObject.FindGameObjectsWithTag(tagName);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}