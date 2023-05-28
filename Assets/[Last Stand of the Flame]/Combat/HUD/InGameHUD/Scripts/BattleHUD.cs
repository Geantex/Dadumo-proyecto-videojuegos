using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    // -----------------------------------------------------------------------------
    // En esta clase vamos a recibir el hud de cada personaje para poder modificarlo
    // -----------------------------------------------------------------------------

    //-------------------------------------------------------
    //---------------------ALIADO 1--------------------------
    //-------------------------------------------------------
    [Header("Aliado 1")]
    public GameObject A1;
    public TextMeshProUGUI nameTextA1;
    public Slider hpSliderA1;
    public Slider manaSliderA1;

    //-------------------------------------------------------
    //---------------------ALIADO 2--------------------------
    //-------------------------------------------------------
    [Header("Aliado 2")]
    public GameObject A2;
    public TextMeshProUGUI nameTextA2;
    public Slider hpSliderA2;
    public Slider manaSliderA2;

    //-------------------------------------------------------
    //---------------------ALIADO 3--------------------------
    //-------------------------------------------------------
    [Header("Aliado 3")]
    public GameObject A3;
    public TextMeshProUGUI nameTextA3;
    public Slider hpSliderA3;
    public Slider manaSliderA3;

    //-------------------------------------------------------
    //---------------------ALIADO 4--------------------------
    //-------------------------------------------------------
    [Header("Aliado 4")]
    public GameObject A4;
    public TextMeshProUGUI nameTextA4;
    public Slider hpSliderA4;
    public Slider manaSliderA4;

    //-------------------------------------------------------
    //---------------------ENEMIGO 1-------------------------
    //-------------------------------------------------------
    [Header("Enemigo 1")]
    public GameObject E1;
    public TextMeshProUGUI nameTextE1;
    public Slider hpSliderE1;
    public Slider manaSliderE1;

    //-------------------------------------------------------
    //---------------------ENEMIGO 2-------------------------
    //-------------------------------------------------------
    [Header("Enemigo 2")]
    public GameObject E2;
    public TextMeshProUGUI nameTextE2;
    public Slider hpSliderE2;
    public Slider manaSliderE2;

    //-------------------------------------------------------
    //---------------------ENEMIGO 3-------------------------
    //-------------------------------------------------------
    [Header("Enemigo 3")]
    public GameObject E3;
    public TextMeshProUGUI nameTextE3;
    public Slider hpSliderE3;
    public Slider manaSliderE3;

    //-------------------------------------------------------
    //---------------------ENEMIGO 4-------------------------
    //-------------------------------------------------------
    [Header("Enemigo 4")]
    public GameObject E4;
    public TextMeshProUGUI nameTextE4;
    public Slider hpSliderE4;
    public Slider manaSliderE4;

    //-------------------------------------------------------
    //-----------------MOVEMENT BUTTONS----------------------
    //-------------------------------------------------------
    [Header("Movement Buttons")]
    public Button buttonBasicAttack;
    public Button buttonSpecialAttack1;
    public Button buttonSpecialAttack2;
    public Button buttonSpecialAttack3;
    public Button buttonSpecialAttack4;
    public Button buttonFinishTurn;

    private void Awake()
    {
        A1.SetActive(false);
        A2.SetActive(false);
        A3.SetActive(false);
        A4.SetActive(false);
        E1.SetActive(false);
        E2.SetActive(false);
        E3.SetActive(false);
        E4.SetActive(false);
    }

    //-------------------------------------------------------
    //--------------FUNCIONES DEL ALIADO 1-------------------
    //-------------------------------------------------------
    public void SetHUDA1(string name, int maxhp, int currenthp, int maxmana, int currentmana)
    {
        A1.SetActive(true);
        nameTextA1.text = name;
        hpSliderA1.maxValue = maxhp;
        hpSliderA1.value = currenthp;
        manaSliderA1.maxValue = maxmana;
        manaSliderA1.value = currentmana;
    }

    public void SetNameA1(string name)
    {
        nameTextA1.text = name;
    }

    public void SetHPA1(int hp)
    {
        hpSliderA1.value = hp;
    }

    public void SetManaA1(int mana)
    {
        manaSliderA1.value = mana;
    }

    //-------------------------------------------------------
    //--------------FUNCIONES DEL ALIADO 2-------------------
    //-------------------------------------------------------
    public void SetHUDA2(string name, int maxhp, int currenthp, int maxmana, int currentmana)
    {
        A2.SetActive(true);
        nameTextA2.text = name;
        hpSliderA2.maxValue = maxhp;
        hpSliderA2.value = currenthp;
        manaSliderA2.maxValue = maxmana;
        manaSliderA2.value = currentmana;
    }

    public void SetNameA2(string name)
    {
        nameTextA2.text = name;
    }

    public void SetHPA2(int hp)
    {
        hpSliderA2.value = hp;
    }

    public void SetManaA2(int mana)
    {
        manaSliderA2.value = mana;
    }

    //-------------------------------------------------------
    //--------------FUNCIONES DEL ALIADO 3-------------------
    //-------------------------------------------------------
    public void SetHUDA3(string name, int maxhp, int currenthp, int maxmana, int currentmana)
    {
        A3.SetActive(true);
        nameTextA3.text = name;
        hpSliderA3.maxValue = maxhp;
        hpSliderA3.value = currenthp;
        manaSliderA3.maxValue = maxmana;
        manaSliderA3.value = currentmana;
    }

    public void SetNameA3(string name)
    {
        nameTextA3.text = name;
    }

    public void SetHPA3(int hp)
    {
        hpSliderA3.value = hp;
    }

    public void SetManaA3(int mana)
    {
        manaSliderA3.value = mana;
    }

    //-------------------------------------------------------
    //--------------FUNCIONES DEL ALIADO 4-------------------
    //-------------------------------------------------------
    public void SetHUDA4(string name, int maxhp, int currenthp, int maxmana, int currentmana)
    {
        A4.SetActive(true);
        nameTextA4.text = name;
        hpSliderA4.maxValue = maxhp;
        hpSliderA4.value = currenthp;
        manaSliderA4.maxValue = maxmana;
        manaSliderA4.value = currentmana;
    }

    public void SetNameA4(string name)
    {
        nameTextA4.text = name;
    }

    public void SetHPA4(int hp)
    {
        hpSliderA4.value = hp;
    }

    public void SetManaA4(int mana)
    {
        manaSliderA4.value = mana;
    }

    //-------------------------------------------------------
    //--------------FUNCIONES DEL ENEMIGO 1------------------
    //-------------------------------------------------------
    public void SetHUDE1(string name, int maxhp, int currenthp, int maxmana, int currentmana)
    {
        E1.SetActive(true);
        nameTextE1.text = name;
        hpSliderE1.maxValue = maxhp;
        hpSliderE1.value = currenthp;
        manaSliderE1.maxValue = maxmana;
        manaSliderE1.value = currentmana;
    }

    public void SetNameE1(string name)
    {
        nameTextE1.text = name;
    }

    public void SetHPE1(int hp)
    {
        hpSliderE1.value = hp;
    }

    public void SetManaE1(int mana)
    {
        manaSliderE1.value = mana;
    }

    //-------------------------------------------------------
    //--------------FUNCIONES DEL ENEMIGO 2------------------
    //-------------------------------------------------------
    public void SetHUDE2(string name, int maxhp, int currenthp, int maxmana, int currentmana)
    {
        E2.SetActive(true);
        nameTextE2.text = name;
        hpSliderE2.maxValue = maxhp;
        hpSliderE2.value = currenthp;
        manaSliderE2.maxValue = maxmana;
        manaSliderE2.value = currentmana;
    }

    public void SetNameE2(string name)
    {
        nameTextE2.text = name;
    }

    public void SetHPE2(int hp)
    {
        hpSliderE2.value = hp;
    }

    public void SetManaE2(int mana)
    {
        manaSliderE2.value = mana;
    }

    //-------------------------------------------------------
    //--------------FUNCIONES DEL ENEMIGO 3------------------
    //-------------------------------------------------------
    public void SetHUDE3(string name, int maxhp, int currenthp, int maxmana, int currentmana)
    {
        E3.SetActive(true);
        nameTextE3.text = name;
        hpSliderE3.maxValue = maxhp;
        hpSliderE3.value = currenthp;
        manaSliderE3.maxValue = maxmana;
        manaSliderE3.value = currentmana;
    }

    public void SetNameE3(string name)
    {
        nameTextE3.text = name;
    }

    public void SetHPE3(int hp)
    {
        hpSliderE3.value = hp;
    }

    public void SetManaE3(int mana)
    {
        manaSliderE3.value = mana;
    }

    //-------------------------------------------------------
    //--------------FUNCIONES DEL ENEMIGO 4------------------
    //-------------------------------------------------------
    public void SetHUDE4(string name, int maxhp, int currenthp, int maxmana, int currentmana)
    {
        E4.SetActive(true);
        nameTextE4.text = name;
        hpSliderE4.maxValue = maxhp;
        hpSliderE4.value = currenthp;
        manaSliderE4.maxValue = maxmana;
        manaSliderE4.value = currentmana;
    }

    public void SetNameE4(string name)
    {
        nameTextE4.text = name;
    }

    public void SetHPE4(int hp)
    {
        hpSliderE4.value = hp;
    }

    public void SetManaE4(int mana)
    {
        manaSliderE4.value = mana;
    }

    public void SetHUD(int party, bool myteam, string name, int maxhp, int currenthp, int maxmana, int currentmana)
    {
        switch(myteam)
        {
            case true:

                switch (party)
                {
                    case 1:
                        SetHUDA1(name, maxhp, currenthp, maxmana, currentmana);
                        break;
                    case 2:
                        SetHUDA2(name, maxhp, currenthp, maxmana, currentmana);
                        break;
                    case 3:
                        SetHUDA3(name, maxhp, currenthp, maxmana, currentmana);
                        break;
                    case 4:
                        SetHUDA4(name, maxhp, currenthp, maxmana, currentmana);
                        break;
                }

                break;

            case false:

                switch (party)
                {
                    case 1:
                        SetHUDE1(name, maxhp, currenthp, maxmana, currentmana);
                        break;
                    case 2:
                        SetHUDE2(name, maxhp, currenthp, maxmana, currentmana);
                        break;
                    case 3:
                        SetHUDE3(name, maxhp, currenthp, maxmana, currentmana);
                        break;
                    case 4:
                        SetHUDE4(name, maxhp, currenthp, maxmana, currentmana);
                        break;
                }

                break;
        }
    }

    public void SetName(int party, bool myteam, string name)
    {
        switch (myteam)
        {
            case true:

                switch (party)
                {
                    case 1:
                        SetNameA1(name);
                        break;
                    case 2:
                        SetNameA2(name);
                        break;
                    case 3:
                        SetNameA3(name);
                        break;
                    case 4:
                        SetNameA4(name);
                        break;
                }

                break;

            case false:

                switch (party)
                {
                    case 1:
                        SetNameE1(name);
                        break;
                    case 2:
                        SetNameE2(name);
                        break;
                    case 3:
                        SetNameE3(name);
                        break;
                    case 4:
                        SetNameE4(name);
                        break;
                }

                break;
        }
    }

    public void SetHP(int party, bool myteam, int hp)
    {
        switch (myteam)
        {
            case true:

                switch (party)
                {
                    case 1:
                        SetHPA1(hp);
                        break;
                    case 2:
                        SetHPA2(hp);
                        break;
                    case 3:
                        SetHPA3(hp);
                        break;
                    case 4:
                        SetHPA4(hp);
                        break;
                }

                break;

            case false:

                switch (party)
                {
                    case 1:
                        SetHPE1(hp);
                        break;
                    case 2:
                        SetHPE2(hp);
                        break;
                    case 3:
                        SetHPE3(hp);
                        break;
                    case 4:
                        SetHPE4(hp);
                        break;
                }

                break;
        }
    }

    public void SetMana(int party, bool myteam, int mana)
    {
        switch (myteam)
        {
            case true:

                switch (party)
                {
                    case 1:
                        SetManaA1(mana);
                        break;
                    case 2:
                        SetManaA2(mana);
                        break;
                    case 3:
                        SetManaA3(mana);
                        break;
                    case 4:
                        SetManaA4(mana);
                        break;
                }

                break;

            case false:

                switch (party)
                {
                    case 1:
                        SetManaE1(mana);
                        break;
                    case 2:
                        SetManaE2(mana);
                        break;
                    case 3:
                        SetManaE3(mana);
                        break;
                    case 4:
                        SetManaE4(mana);
                        break;
                }

                break;
        }
    }
}
