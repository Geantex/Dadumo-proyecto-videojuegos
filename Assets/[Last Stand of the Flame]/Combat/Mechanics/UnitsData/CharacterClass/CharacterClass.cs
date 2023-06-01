using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.UI;

public class CharacterClass : MonoBehaviour
{
    [SerializeField] private string characterName;//Poner nombre de personaje
    [SerializeField] private string characterClassName;//Clase del personaje
    [SerializeField] private Image characterImage;//Sprite del personaje
    [SerializeField] private Material characterMaterial;//Material del personaje (en caso de ser necesario y no estar en el sprite para futuros cambios visuales)
    [SerializeField] private GameObject characterPrefab;//Prefab con los scripts necesarios para el control del personaje
    [SerializeField] private float healthPoints;//Puntos de vida del personaje
    [SerializeField] private float maxHealthPoints;//Puntos máximos de vida del personaje
    [SerializeField] private float manaPoints;//Puntos de maná del personaje
    [SerializeField] private float damagePoints;//Puntos de daño del personaje
    [SerializeField] private float rangeTiles;//Rango del personaje
    [SerializeField] private List<SpecialAttack> specialAttacks;//Lista de ataques especiales
    [SerializeField] private item characterWeapon;//Arma portada por el personaje
    [SerializeField] private item characterArmor;//Armadura portada por el personaje
    private bool weaponModified = false;
    private bool armorModified = false;

    public string CharacterName
    {
        get
        {
            return characterName;
        }
        set
        {
            characterName = value;
        }
    }
    public string CharacterClassName
    {
        get
        {
            return characterClassName;
        }
        set
        {
            characterClassName = value;
        }
    }
    public Image CharacterImage
    {
        get
        {
            return characterImage;
        }
        set
        {
            characterImage = value;
        }
    }
    public Material CharacterMaterial
    {
        get
        {
            return characterMaterial;
        }
        set
        {
            characterMaterial = value;
        }
    }
    public GameObject CharacterPrefab
    {
        get
        {
            return characterPrefab;
        }
        set
        {
            characterPrefab = value;
        }
    }
    public float MaxHealthPoints
    {
        get
        {
            return maxHealthPoints;
        }
        set
        {
            maxHealthPoints = value;
        }
    }
    public float HealthPoints
    {
        get
        {
            return healthPoints;
        }
        set
        {
            /*if (value < 0)
            {
                value = 0;
            }
            else if (value > MaxHealthPoints)
            {
                value = MaxHealthPoints;
            }*/
            healthPoints = value;
        }
    }
    public float ManaPoints
    {
        get
        {
            return manaPoints;
        }
        set
        {
            manaPoints = value;
        }
    }
    public float DamagePoints
    {
        get
        {
            return damagePoints;
        }
        set
        {
            damagePoints = value;
        }
    }
    public float RangeTiles
    {
        get
        {
            return rangeTiles;
        }
        set
        {
            rangeTiles = value;
        }
    }
    public List<SpecialAttack> SpecialAttacks
    {
        get
        {
            return specialAttacks;
        }
        set
        {
            specialAttacks = value;
        }
    }
    public item CharacterWeapon
    {
        get
        {
            return characterWeapon;
        }
        set
        {
            if (value.itemSlot == "weapon" && value.itemTier > characterWeapon.itemTier && value.characterTag == characterClassName)
            {
                //Modifica el valor del arma añadiendo una y modificando el ataque del personaje
                if (weaponModified == false)
                {
                    characterWeapon = value;
                    damagePoints += value.itemDamageModifier;
                    weaponModified = true;
                }
                else if (weaponModified == true)
                {
                    damagePoints -= characterWeapon.itemDamageModifier;
                    characterWeapon = value;
                    damagePoints += value.itemDamageModifier;
                }
            }
        }
    }
    public item CharacterArmor
    {
        get
        {
            return characterArmor;
        }
        set
        {
            if (value.itemSlot == "armor" && value.itemTier > characterArmor.itemTier && value.characterTag == characterClassName)
            {
                //Modifica el valor de la armadura añadiendo una y modificando la vida del personaje
                if (armorModified == false)
                {
                    characterArmor = value;
                    healthPoints += value.itemHealthModifier;
                    armorModified = true;
                }
                else if (armorModified == true)
                {
                    damagePoints -= characterArmor.itemHealthModifier;
                    characterArmor = value;
                    healthPoints += value.itemHealthModifier;
                }

            }
        }
    }

}