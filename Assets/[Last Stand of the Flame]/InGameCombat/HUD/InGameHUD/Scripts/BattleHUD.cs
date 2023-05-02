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

    // Start is called before the first frame update
    void Start()
    {
        //nameText = nameContainer.GetComponent<TextMeshProUGUI>();
        //levelText = levelContainer.GetComponent<TextMeshProUGUI>();
        //hpSlider = hpContainer.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public BattleHUD()
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
