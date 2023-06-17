using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class itemManager : MonoBehaviour
{

    // RECUERDA METER ESTO A ALGUN OBJETO EN LA ESCENA, o algo no se xd
   
    public List<item> allItemsList;
    // Start is called before the first frame update
    void Start()
    {
        /*string[] assetPaths = AssetDatabase.FindAssets("t: item", new string[] { "Assets/[Last Stand of the Flame]/Map/Shop/Scripts/itemsCreated" });
        item[] arrayItem = new item[assetPaths.Length];
        for (int i = 0; i < assetPaths.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(assetPaths[i]);
            arrayItem[i] = AssetDatabase.LoadAssetAtPath<item>(path);
            //Debug.Log("Loaded asset " + i + " with name: " + arrayItem[i].itemName);
        }
        allItemsList = new List<item>(arrayItem);*/
    }


    // Update is called once per frame
    void Update()
    {

    }

    
}
