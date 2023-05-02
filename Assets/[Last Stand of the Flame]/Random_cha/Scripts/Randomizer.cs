using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Randomizer : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> characters = new List<string>();

    public string firstCharacter;
    public int firstCharacterIndex;
    public string secondCharacter;
    public int secondCharacterIndex;
    public string thirdCharacter;
    public int thirdCharacterIndex;

    public Button reroll1;
    public Button reroll2;
    public Button reroll3;

    public Image imageCharacter1;
    public Image imageCharacter2;
    public Image imageCharacter3;

    public bool rerollUsed = false;
    void Start()
    {
        characters.Add("Clerigo");
        characters.Add("Barbaro");
        characters.Add("Bardo");
        characters.Add("Mago");
        characters.Add("Monje");
        characters.Add("Paladin");
        characters.Add("Asesino");

        firstCharacterIndex = Random.Range(1, 8);

        firstCharacter = characters[firstCharacterIndex-1];

        secondCharacterIndex = Random.Range(1, 8);

        while (secondCharacterIndex == firstCharacterIndex)
        {
            secondCharacterIndex = Random.Range(1, 8);
        }

        secondCharacter = characters[secondCharacterIndex - 1];

        thirdCharacterIndex = Random.Range(1, 8);

        while (thirdCharacterIndex == firstCharacterIndex || thirdCharacterIndex == secondCharacterIndex)
        {
            thirdCharacterIndex = Random.Range(1, 8);
        }

        thirdCharacter = characters[thirdCharacterIndex-1];

        changeSprint(firstCharacter, 1);
        
        changeSprint(secondCharacter, 2);
        
        changeSprint(thirdCharacter, 3);

        reroll1.onClick.AddListener(RerollFirst);
        reroll2.onClick.AddListener(RerollSecond);
        reroll3.onClick.AddListener(RerollThird);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RerollFirst()
    {
        int firstLast = firstCharacterIndex;
        if(!rerollUsed)
        {
            firstCharacterIndex = Random.Range(1, 8);

            while (firstCharacterIndex == secondCharacterIndex || firstCharacterIndex == thirdCharacterIndex || firstLast == firstCharacterIndex)
            {
                firstCharacterIndex = Random.Range(1, 8);
            }

            firstCharacter = characters[firstCharacterIndex - 1];

            changeSprint(firstCharacter, 1);

            rerollUsed = true;
        }
    }

    public void RerollSecond()
    {
        int secondLast = secondCharacterIndex;
        if (!rerollUsed)
        {
            secondCharacterIndex = Random.Range(1, 8);

            while (secondCharacterIndex == firstCharacterIndex || secondCharacterIndex == thirdCharacterIndex || secondLast == secondCharacterIndex)
            {
                secondCharacterIndex = Random.Range(1, 8);
            }

            secondCharacter = characters[secondCharacterIndex - 1];

            changeSprint(secondCharacter, 2);

            rerollUsed = true;
        }
    }

    public void RerollThird()
    {
        int thirdLast = thirdCharacterIndex;
        if (!rerollUsed)
        {
            thirdCharacterIndex = Random.Range(1, 8);

            while (thirdCharacterIndex == firstCharacterIndex || thirdCharacterIndex == secondCharacterIndex || thirdLast == thirdCharacterIndex)
            {
                thirdCharacterIndex = Random.Range(1, 8);
            }

            thirdCharacter = characters[thirdCharacterIndex - 1];

            changeSprint(thirdCharacter, 3);

            rerollUsed = true;
        }
    }

    public void changeSprint(string tipe, int orden)
    {
        switch (tipe)
        {
            case "Clerigo":
                switch (orden)
                {
                    case 1:
                        imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/JM_pose_rework_png.png");
                        break;
                    case 2:
                        imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/JM_pose_rework_png.png");
                        break;
                    case 3:
                        imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/JM_pose_rework_png.png");
                        break;
                }

                break;
            case "Barbaro":
                switch (orden)
                {
                    case 1:
                        imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/barbaro_ani.png");
                        break;
                    case 2:
                        imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/barbaro_ani.png");
                        break;
                    case 3:
                        imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/barbaro_ani.png");
                        break;
                }

                break;
            case "Bardo":
                switch (orden)
                {
                    case 1:
                        imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/Romero_Macbeth_ani.png");
                        break;
                    case 2:
                        imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/Romero_Macbeth_ani.png");
                        break;
                    case 3:
                        imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/Romero_Macbeth_ani.png");
                        break;
                }

                break;
            case "Mago":
                switch (orden)
                {
                    case 1:
                        imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/Galentin_pose_png.png");
                        break;
                    case 2:
                        imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/Galentin_pose_png.png");
                        break;
                    case 3:
                        imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/Galentin_pose_png.png");
                        break;
                }

                break;
            case "Monje":
                switch (orden)
                {
                    case 1:
                        imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/KAKA_animacion_azul.png");
                        break;
                    case 2:
                        imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/KAKA_animacion_azul.png");
                        break;
                    case 3:
                        imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/KAKA_animacion_azul.png");
                        break;
                }

                break;
            case "Paladin":
                switch (orden)
                {
                    case 1:
                        imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/animacion_Deenecan.png");
                        break;
                    case 2:
                        imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/animacion_Deenecan.png");
                        break;
                    case 3:
                        imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/animacion_Deenecan.png");
                        break;
                }

                break;
            case "Asesino":
                switch (orden)
                {
                    case 1:
                        imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/kazuro_animacion_png.png");
                        break;
                    case 2:
                        imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/kazuro_animacion_png.png");
                        break;
                    case 3:
                        imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/kazuro_animacion_png.png");
                        break;
                }

                break;
        }
    }
}
