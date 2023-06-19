using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewCharacterCreator", menuName = "Character Creator")]
public class CharacterCreator : ScriptableObject
{
    [SerializeField] private string characterName;//Poner nombre de personaje
    [SerializeField] private string characterClass;//Clase del personaje
    [SerializeField] private Sprite characterImage;//Sprite del personaje
    [SerializeField] private GameObject characterPrefab;//Prefab con los scripts necesarios para el control del personaje
    [SerializeField] private float healthPoints;//Puntos de vida del personaje
    [SerializeField] private float maxHealthPoints;//Puntos máximos de vida del personaje
    [SerializeField] private float manaPoints;//Puntos de maná del personaje
    [SerializeField] private float maxManaPoints;//Puntos máximos de mana del personaje
    [SerializeField] private float damagePoints;//Puntos de daño del personaje
    [SerializeField] private float rangeTiles;//Rango del personaje
    [SerializeField] private float speed;//Rango del personaje
    [SerializeField] private List<SpecialAttack> specialAttacks;//Lista de ataques especiales
    [SerializeField] private item characterWeapon;//Arma portada por el personaje
    [SerializeField] private item characterArmor;//Armadura portada por el personaje
    private bool weaponModified = false;
    private bool armorModified = false;

    public void SetUpCharacters()
    {
        CharacterPrefab.GetComponent<Unit>().Name = CharacterName;
        CharacterPrefab.GetComponent<Unit>().imagen = CharacterImage;
        CharacterPrefab.GetComponent<Unit>().Life = (int)HealthPoints;
        CharacterPrefab.GetComponent<Unit>().MaxLife = (int)MaxHealthPoints;
        CharacterPrefab.GetComponent<Unit>().Mana = (int)ManaPoints;
        CharacterPrefab.GetComponent<Unit>().MaxMana = (int)MaxManaPoints;
        CharacterPrefab.GetComponent<PlayerAttack>().Damage = (int)DamagePoints;
        CharacterPrefab.GetComponent<PlayerAttack>().Range = (int)RangeTiles;
        CharacterPrefab.GetComponent<PlayerSpecialAttack>().AllSpecialAttacks = SpecialAttacks;
    }

    public void SetUpEnemies()
    {
        CharacterPrefab.GetComponent<Unit>().Name = CharacterName;
        CharacterPrefab.GetComponent<Unit>().imagen = CharacterImage;
        CharacterPrefab.GetComponent<Unit>().Life = (int)HealthPoints;
        CharacterPrefab.GetComponent<Unit>().MaxLife = (int)MaxHealthPoints;
        CharacterPrefab.GetComponent<Unit>().Mana = (int)ManaPoints;
        CharacterPrefab.GetComponent<Unit>().MaxMana = (int)MaxManaPoints;
        CharacterPrefab.GetComponent<NPCAttack>().Damage = (int)DamagePoints;
        CharacterPrefab.GetComponent<NPCAttack>().Range = (int)RangeTiles;
    }

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
    public string CharacterClass
    {
        get
        {
            return characterClass;
        }
        set
        {
            characterClass = value;
        }
    }
    public Sprite CharacterImage
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
            if (value < 0)
            {
                value = 0;
            }
            else if (value > MaxHealthPoints)
            {
                value = MaxHealthPoints;
            }
            healthPoints = value;
        }
    }

    public float MaxManaPoints
    {
        get
        {
            return maxManaPoints;
        }
        set
        {

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
            if (characterWeapon == null)
            {
                characterWeapon = value;
                DamagePoints += value.itemDamageModifier;
                weaponModified = true;
            }
            else if (value.itemTier > characterWeapon.itemTier)
            {
                //Modifica el valor de daño añadiendo una y modificando el daño del personaje
                if (armorModified == false)
                {
                    characterWeapon = value;
                    DamagePoints += value.itemDamageModifier;
                    weaponModified = true;
                }
                else if (armorModified == true)
                {
                    DamagePoints -= characterWeapon.itemDamageModifier;
                    characterWeapon = value;
                    DamagePoints += value.itemDamageModifier;
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
            if (characterArmor == null)
            {
                characterArmor = value;
                maxHealthPoints += value.itemHealthModifier;
                HealthPoints += value.itemHealthModifier;
                armorModified = true;
            }
            else if (value.itemTier > characterArmor.itemTier)
            {
                //Modifica el valor de la armadura añadiendo una y modificando la vida del personaje
                if (armorModified == false)
                {
                    characterArmor = value;
                    maxHealthPoints += value.itemHealthModifier;
                    HealthPoints += value.itemHealthModifier;
                    armorModified = true;
                }
                else if (armorModified == true)
                {
                    HealthPoints -= characterArmor.itemHealthModifier;
                    maxHealthPoints -= value.itemHealthModifier;
                    characterArmor = value;
                    maxHealthPoints += value.itemHealthModifier;
                    HealthPoints += value.itemHealthModifier;
                }
            }
        }
    }
}