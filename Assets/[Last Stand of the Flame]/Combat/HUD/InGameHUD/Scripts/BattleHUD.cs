using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public GameObject nameContainer;
    public GameObject levelContainer;
    public GameObject hpContainer;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public Slider hpSlider;

    public Button buttonBasicAttack;
    public Button buttonSpecialAttack1;
    public Button buttonSpecialAttack2;
    public Button buttonSpecialAttack3;
    public Button buttonSpecialAttack4;
    public Button buttonFinishTurn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHUD(string name, int level, int maxhp, int currenthp)
    {
        Debug.Log("El puto nombre::::: " + name);
        nameText.text = name;
        //levelText.text = "Lvl " + level;
        hpSlider.maxValue = maxhp;
        hpSlider.value = currenthp;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void SetName(string name)
    {
        nameText.text = name;
    }
}
