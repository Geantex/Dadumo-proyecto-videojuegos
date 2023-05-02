using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class itemManager : MonoBehaviour
{

    // RECUERDA METER ESTO A ALGUN OBJETO EN LA ESCENA, o algo no se xd
   
    public List<item> allItemsList;
    // Start is called before the first frame update
    void Start()
    {
        string[] assetPaths = AssetDatabase.FindAssets("t: item", new string[] { "Assets/[Last Stand of the Flame]/Map/Shop/Scripts/itemsCreated" });
        item[] arrayItem = new item[assetPaths.Length];
        for (int i = 0; i < assetPaths.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(assetPaths[i]);
            arrayItem[i] = AssetDatabase.LoadAssetAtPath<item>(path);
            //Debug.Log("Loaded asset " + i + " with name: " + arrayItem[i].itemName);
        }
        allItemsList = new List<item>(arrayItem);
    }


    // Update is called once per frame
    void Update()
    {

    }

    void DeleteItemFromList(item itemToDelete)
    {
        allItemsList.Remove(itemToDelete);
    }

    public void OnEquip(item equippedItem)
    {
        DeleteItemFromList(equippedItem);
        foreach (item item in allItemsList) 
        { 
            // Esto borrar� los objetos que sean del mismo personaje, que tengan un tier igual o menor, y que ocupen el mismo espacio (arma == arma o armadura == armadura)
            if (item.characterTag == equippedItem.characterTag && item.itemTier <= equippedItem.itemTier && item.itemSlot == equippedItem.itemSlot)
            {
                DeleteItemFromList(item);
            }
        }
    }
}
