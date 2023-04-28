using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    public List<item> allItemsList;
    // Start is called before the first frame update
    void Start()
    {
        // Este me da error
        item[] arrayItems;
        arrayItems = (item[])AssetDatabase.LoadAllAssetsAtPath("Assets/Map/Tienda/Scripts/createdItems");
        allItemsList = new List<item>(arrayItems);
        Debug.Log(allItemsList.ElementAt(0).itemName);

        // Este me va
        item prueba = ScriptableObject.CreateInstance<item>();
        prueba = AssetDatabase.LoadAssetAtPath<item>("Assets/Map/Tienda/Scripts/itemsCreated/ataqueGalentin+.asset");
        Debug.Log(prueba.itemName);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
