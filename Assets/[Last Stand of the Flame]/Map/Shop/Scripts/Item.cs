using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
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
    public int itemDamageModifier; // esto modificara el da�o del personaje
    public int itemHealthModifier; // esto modificara la salud del personaje
    public int itemTier; // esto lo usaremos para saber c�mo de fuerte es un objeto, y para que no salgan de menor calidad (1)*
    public string characterTag; // Esto lo usaremos para que solo salgan objetos de personajes que hayan en el juego
    public string itemSlot; // esto solo puede ser o "weapon" o "armor"
    public Sprite characterImage; // podemos poner una imagen en el canvas que se�ale quien puede equiparse el objeto
    public GameObject itemPrefab; //item prefab

    // (1)* Si un objeto est� equipado, no deber�a volver a salir en esta partida. Tampoco deber�an de salir objetos de menor tier
    // Esto lo haremos guardandolo en una lista, y comparando los tiers (puede?)

    public item equipItem(item itemConseguido)
    {
        List<CharacterCreator> CharactersList = GameController.Instancia.CharactersParty;
        foreach (CharacterCreator character in CharactersList)
        {
            if (itemConseguido.characterTag == character.CharacterClass && itemConseguido.itemSlot == "armor")
            {
                character.CharacterArmor = itemConseguido;
            }
            else if(itemConseguido.characterTag == character.CharacterClass && itemConseguido.itemSlot == "weapon")
            {
                character.CharacterWeapon = itemConseguido;
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
