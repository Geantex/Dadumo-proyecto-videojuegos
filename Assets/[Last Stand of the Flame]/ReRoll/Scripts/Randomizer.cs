using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Dapasa.FSM;
using UnityEngine.SceneManagement;

public class Randomizer : FSMState
{
    // Start is called before the first frame update
    //public List<string> characters = new List<string>();
    public List<CharacterCreator> characters;
    public List<CharacterCreator> electedCharacters;

    //public string firstCharacter;
    public CharacterCreator firstCharacter;
    public int firstCharacterIndex;
    //public string secondCharacter;
    public CharacterCreator secondCharacter;
    public int secondCharacterIndex;
    //public string thirdCharacter;
    public CharacterCreator thirdCharacter;
    public int thirdCharacterIndex;

    //[SerializeField] public Button reroll1;
    //public Button reroll2;
    //public Button reroll3;

    public GameObject prefabCharacter1;
    public GameObject prefabCharacter2;
    public GameObject prefabCharacter3;

    public bool rerollUsed = false;

    public GameObject Clerigo;
    public GameObject Asesino;
    public GameObject Paladin;
    public GameObject Luchador;
    public GameObject Mago;
    public GameObject Bardo;
    public GameObject Barbaro;

    private int characterNumber = 0;

    protected override void EnterState()
    {
        (machine as GameController).GoldCoins = 0f;
        GameController.Instancia.CharactersParty.Clear();
        SceneManager.LoadScene("Reroll");
        electedCharacters = new List<CharacterCreator>();
        characters = GameController.Instancia.AllPlayableCharacters;
        //characterNumber = characters.Count+1;
        characterNumber = 8;
        //Para el find el personaje esta creado o no funciona bien el script
        Paladin = GameController.Instancia.AllPlayableCharacters.Find(character => character.CharacterClass == "paladin").CharacterPrefab;
        Asesino = GameController.Instancia.AllPlayableCharacters.Find(character => character.CharacterClass == "asesino").CharacterPrefab;
        Mago = GameController.Instancia.AllPlayableCharacters.Find(character => character.CharacterClass == "mago").CharacterPrefab;
        Bardo = GameController.Instancia.AllPlayableCharacters.Find(character => character.CharacterClass == "bardo").CharacterPrefab;
        Barbaro = GameController.Instancia.AllPlayableCharacters.Find(character => character.CharacterClass == "barbaro").CharacterPrefab;
        Clerigo = GameController.Instancia.AllPlayableCharacters.Find(character => character.CharacterClass == "clerigo").CharacterPrefab;
        Luchador = GameController.Instancia.AllPlayableCharacters.Find(character => character.CharacterClass == "luchador").CharacterPrefab;

        firstCharacterIndex = Random.Range(1, characterNumber);

        firstCharacter = characters[firstCharacterIndex - 1];

        secondCharacterIndex = Random.Range(1, characterNumber);

        while (secondCharacterIndex == firstCharacterIndex)
        {
            secondCharacterIndex = Random.Range(1, characterNumber);
        }

        secondCharacter = characters[secondCharacterIndex - 1];

        thirdCharacterIndex = Random.Range(1, characterNumber);

        while (thirdCharacterIndex == firstCharacterIndex || thirdCharacterIndex == secondCharacterIndex)
        {
            thirdCharacterIndex = Random.Range(1, characterNumber);
        }

        thirdCharacter = characters[thirdCharacterIndex - 1];

        changeSprint(firstCharacter.CharacterClass, 1);

        changeSprint(secondCharacter.CharacterClass, 2);

        changeSprint(thirdCharacter.CharacterClass, 3);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RerollFirst()
    {
        electedCharacters.RemoveAt(0);

        int firstLast = firstCharacterIndex;
        if(!rerollUsed)
        {
            firstCharacterIndex = Random.Range(1, characterNumber);

            while (firstCharacterIndex == secondCharacterIndex || firstCharacterIndex == thirdCharacterIndex || firstLast == firstCharacterIndex)
            {
                firstCharacterIndex = Random.Range(1, characterNumber);
            }

            firstCharacter = characters[firstCharacterIndex - 1];

            changeSprint(firstCharacter.CharacterClass, 1);

            rerollUsed = true;
        }
        GameController.Instancia.CharactersParty.Clear();
        GameController.Instancia.CharactersParty = electedCharacters;
    }

    public void RerollSecond()
    {
        electedCharacters.RemoveAt(1);

        int secondLast = secondCharacterIndex;
        if (!rerollUsed)
        {
            secondCharacterIndex = Random.Range(1, characterNumber);

            while (secondCharacterIndex == firstCharacterIndex || secondCharacterIndex == thirdCharacterIndex || secondLast == secondCharacterIndex)
            {
                secondCharacterIndex = Random.Range(1, characterNumber);
            }

            secondCharacter = characters[secondCharacterIndex - 1];

            changeSprint(secondCharacter.CharacterClass, 2);

            rerollUsed = true;
        }
        GameController.Instancia.CharactersParty.Clear();
        GameController.Instancia.CharactersParty = electedCharacters;
    }

    public void RerollThird()
    {
        electedCharacters.RemoveAt(2);

        int thirdLast = thirdCharacterIndex;
        if (!rerollUsed)
        {
            thirdCharacterIndex = Random.Range(1, characterNumber);

            while (thirdCharacterIndex == firstCharacterIndex || thirdCharacterIndex == secondCharacterIndex || thirdLast == thirdCharacterIndex)
            {
                thirdCharacterIndex = Random.Range(1, characterNumber);
            }

            thirdCharacter = characters[thirdCharacterIndex - 1];

            changeSprint(thirdCharacter.CharacterClass, 3);

            rerollUsed = true;
        }
        GameController.Instancia.CharactersParty.Clear();
        GameController.Instancia.CharactersParty = electedCharacters;
    }

    public void changeSprint(string tipe, int orden)
    {
        switch (tipe)
        {
            case "clerigo":
                switch (orden)
                {
                    case 1:
                        Debug.Log(orden);
                        if (Clerigo != null)
                        {
                            Debug.Log(Clerigo);
                        }
                        //imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/JM_pose_rework_png.png");
                        prefabCharacter1 = Clerigo;

                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "clerigo"));
                        break;
                    case 2:
                        Debug.Log(orden);
                        if (Clerigo != null)
                        {
                            Debug.Log(Clerigo);
                        }
                        //imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/JM_pose_rework_png.png");
                        prefabCharacter2 = Clerigo;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "clerigo"));
                        break;
                    case 3:
                        Debug.Log(orden);
                        if (Clerigo != null)
                        {
                            Debug.Log(Clerigo);
                        }
                        //imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/JM_pose_rework_png.png");
                        prefabCharacter3 = Clerigo;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "clerigo"));
                        break;
                }

                break;
            case "barbaro":
                switch (orden)
                {
                    case 1:
                        Debug.Log(orden);
                        if (Barbaro != null)
                        {
                            Debug.Log(Barbaro);
                        }
                        //imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/barbaro_ani.png");
                        prefabCharacter1 = Barbaro;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "barbaro"));
                        break;
                    case 2:
                        Debug.Log(orden);
                        if (Barbaro != null)
                        {
                            Debug.Log(Barbaro);
                        }
                        //imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/barbaro_ani.png");
                        prefabCharacter2 = Barbaro;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "barbaro"));
                        break;
                    case 3:
                        Debug.Log(orden);
                        if (Barbaro != null)
                        {
                            Debug.Log(Barbaro);
                        }
                        //imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/barbaro_ani.png");
                        prefabCharacter3 = Barbaro;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "barbaro"));
                        break;
                }

                break;
            case "bardo":
                switch (orden)
                {
                    case 1:
                        Debug.Log(orden);
                        if (Bardo != null)
                        {
                            Debug.Log(Bardo);
                        }
                        //imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/Romero_Macbeth_ani.png");
                        prefabCharacter1 = Bardo;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "bardo"));
                        break;
                    case 2:
                        Debug.Log(orden);
                        if (Bardo != null)
                        {
                            Debug.Log(Bardo);
                        }
                        //imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/Romero_Macbeth_ani.png");
                        prefabCharacter2 = Bardo;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "bardo"));
                        break;
                    case 3:
                        Debug.Log(orden);
                        if (Bardo != null)
                        {
                            Debug.Log(Bardo);
                        }
                        //imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/Romero_Macbeth_ani.png");
                        prefabCharacter3 = Bardo;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "bardo"));
                        break;
                }

                break;
            case "mago":
                switch (orden)
                {
                    case 1:
                        Debug.Log(orden);
                        if (Mago != null)
                        {
                            Debug.Log(Mago);
                        }
                        //imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/Galentin_pose_png.png");
                        prefabCharacter1 = Mago;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "mago"));
                        break;
                    case 2:
                        Debug.Log(orden);
                        if (Mago != null)
                        {
                            Debug.Log(Mago);
                        }
                        //imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/Galentin_pose_png.png");
                        prefabCharacter2 = Mago;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "mago"));
                        break;
                    case 3:
                        Debug.Log(orden);
                        if (Mago != null)
                        {
                            Debug.Log(Mago);
                        }
                        //imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/Galentin_pose_png.png");
                        prefabCharacter3 = Mago;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "mago"));
                        break;
                }

                break;
            case "luchador":
                switch (orden)
                {
                    case 1:
                        Debug.Log(orden);
                        if (Luchador != null)
                        {
                            Debug.Log(Luchador);
                        }
                        //imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/KAKA_animacion_azul.png");
                        prefabCharacter1 = Luchador;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "luchador"));
                        break;
                    case 2:
                        Debug.Log(orden);
                        if (Luchador != null)
                        {
                            Debug.Log(Luchador);
                        }
                        //imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/KAKA_animacion_azul.png");
                        prefabCharacter2 = Luchador;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "luchador"));
                        break;
                    case 3:
                        Debug.Log(orden);
                        if (Luchador != null)
                        {
                            Debug.Log(Luchador);
                        }
                        //imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/KAKA_animacion_azul.png");
                        prefabCharacter3 = Luchador;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "luchador"));
                        break;
                }

                break;
            case "paladin":
                switch (orden)
                {
                    case 1:
                        Debug.Log(orden);
                        if (Paladin != null)
                        {
                            Debug.Log(Paladin);
                        }
                        //imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/animacion_Deenecan.png");
                        prefabCharacter1 = Paladin;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "paladin"));
                        break;
                    case 2:
                        Debug.Log(orden);
                        if (Paladin != null)
                        {
                            Debug.Log(Paladin);
                        }
                        //imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/animacion_Deenecan.png");
                        prefabCharacter2 = Paladin;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "paladin"));

                        break;
                        
                    case 3:
                        Debug.Log(orden);
                        //imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/animacion_Deenecan.png");
                        prefabCharacter3 = Paladin;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "paladin"));

                        break;
                }

                break;
            case "asesino":
                switch (orden)
                {
                    case 1:
                        Debug.Log(orden);
                        //imageCharacter1.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/kazuro_animacion_png.png");
                        if (Asesino != null)
                        {
                            Debug.Log(Asesino);
                        }
                        prefabCharacter1 = Asesino;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "asesino"));

                        break;
                    case 2:
                        Debug.Log(orden);
                        if (Asesino != null)
                        {
                            Debug.Log(Asesino);
                        }
                        //imageCharacter2.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/kazuro_animacion_png.png");
                        prefabCharacter2 = Asesino;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "asesino"));
                        break;
                    case 3:
                        Debug.Log(orden);
                        if (Asesino != null)
                        {
                            Debug.Log(Asesino);
                        }
                        //imageCharacter3.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/InGameCombat/Units/Allies/ImagenesCharacters/kazuro_animacion_png.png");
                        prefabCharacter3 = Asesino;
                        electedCharacters.Add(characters.Find(character => character.CharacterClass == "asesino"));
                        break;
                }

                break;
        }
    }
    protected override void ExitState()
    {
        instantiateCharacters();
        
    }

    public void instantiateCharacters()
    {
        foreach (CharacterCreator character in electedCharacters)
        {
            (machine as GameController).CharactersParty.Add(Instantiate(character));
        }
    }
}
