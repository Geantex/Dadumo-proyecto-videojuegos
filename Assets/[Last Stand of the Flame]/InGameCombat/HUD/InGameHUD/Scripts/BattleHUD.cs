using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;

    public BattleHUD()
    {
        GameObject textObjecto = GameObject.Find("NameText");
        nameText = textObjecto.GetComponent<Text>();

        GameObject textObjecto2 = GameObject.Find("VM");
        levelText = textObjecto2.GetComponent<Text>();

        GameObject sliderObjeto = GameObject.Find("NamePanel");
        hpSlider = sliderObjeto.GetComponent<Slider>();
    }

    public void SetHUD(string name, int level, int maxhp, int currenthp)
    {
        nameText.text = name;
        levelText.text = "Lvl " + level;
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
