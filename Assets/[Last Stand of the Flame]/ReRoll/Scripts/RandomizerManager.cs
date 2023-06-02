using Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizerManager : MonoBehaviour
{
    [SerializeField] public Image Image1Scene;
    [SerializeField] public Image Image2Scene;
    [SerializeField] public Image Image3Scene;

    private Image image1;
    private Image image2;
    private Image image3;

    [SerializeField] private List<Button> rerollButtons;

    public bool rollUsed = false;



    // Start is called before the first frame update
    void Start()
    {
        /*image1 = GameController.Instancia.GetComponent<Randomizer>().imageCharacter1;
        image2 = GameController.Instancia.GetComponent<Randomizer>().imageCharacter2;
        image3 = GameController.Instancia.GetComponent<Randomizer>().imageCharacter3;*/
    }

    // Update is called once per frame
    void Update()
    {
        image1 = GameController.Instancia.GetComponent<Randomizer>().imageCharacter1;
        image2 = GameController.Instancia.GetComponent<Randomizer>().imageCharacter2;
        image3 = GameController.Instancia.GetComponent<Randomizer>().imageCharacter3;

        Image1Scene.sprite = image1.sprite;
        Image2Scene.sprite = image2.sprite;
        Image3Scene.sprite = image3.sprite;

        if (rollUsed == true)
        {
            foreach (Button b in rerollButtons)
            {
                b.interactable = false;
            }
        }
    }

    public void Reroll1()
    {
        Debug.Log("Rerol1");
        GameController.Instancia.GetComponent<Randomizer>().RerollFirst();
        rollUsed = true;
    }

    public void Reroll2()
    {
        Debug.Log("Rerol2");
        GameController.Instancia.GetComponent<Randomizer>().RerollSecond();
        rollUsed = true;
    }

    public void Reroll3()
    {
        Debug.Log("Rerol3");
        GameController.Instancia.GetComponent<Randomizer>().RerollThird();
        rollUsed = true;
    }

    public void exit()
    {
        GetComponent<Randomizer>().instantiateCharacters();
        GameController.Instancia.SetStateByType(typeof(MapState));
    }
}
