using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Esta es la clase padre de itemTienda e itemTesoro
[CreateAssetMenu()]
public class item : ScriptableObject
{
    public string itemName;
    public int itemPrice; // los objetos de la tienda reduciran el dinero del jugador (para comprarlo)
    // los objetos de cofres de tesoros
    public Sprite itemImage;
    public int itemDamageModifier; // esto modificara el daño del personaje
    public int itemHealthModifier; // esto modificara la salud del personaje
    public int itemTier; // esto lo usaremos para saber cómo de fuerte es un objeto, y para que no salgan de menor calidad (1)*
    public string characterTag; // Esto lo usaremos para que solo salgan objetos de personajes que hayan en el juego
    public string itemSlot; // esto solo puede ser o "weapon" o "armor"
    public Sprite characterImage; // podemos poner una imagen en el canvas que señale quien puede equiparse el objeto
    public GameObject itemPrefab; //item prefab

    // (1)* Si un objeto está equipado, no debería volver a salir en esta partida. Tampoco deberían de salir objetos de menor tier
    // Esto lo haremos guardandolo en una lista, y comparando los tiers (puede?)

    public item equipItem(item itemConseguido)
    {
        foreach (CharacterCreator character in GameController.Instancia.CharactersParty)
        {
            if (itemConseguido.characterTag == character.CharacterClass)
            {
                Debug.Log(itemConseguido.itemName);
                Debug.Log(itemConseguido.itemSlot);
                Debug.Log(itemConseguido.itemTier);
                Debug.Log(itemConseguido.characterTag);
                Debug.Log(character.CharacterClass);
                if(itemConseguido.itemSlot == "armor")
                {
                    character.CharacterArmor = itemConseguido;
                    Debug.Log(character.CharacterArmor);
                }
                else if (itemConseguido.itemSlot == "weapon")
                {
                    character.CharacterWeapon = itemConseguido;
                    Debug.Log(character.CharacterWeapon);
                }
            }
            
            // esta funcion equipara un objeto en el personaje que llame a la funcion si!!!
        }
        return itemConseguido;
    }

    // Esta funcion deberia llamarse cada vez de que el personaje que tenga equipado el objeto golpea a un enemigo YIPIE!!!
    // Reservar para objetos legendarios -> Tier 3
    public void onHitExtraEffect()
    {
        // nothing lol :)
    }
}
