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
    public Texture2D itemImage; // (1)
    public int itemDamageModifier; // esto modificara el daño del personaje
    public int itemHealthModifier; // esto modificara la salud del personaje
    public int itemTier; 
    public string characterTag;
    public Texture2D characterImage; // podemos poner una imagen en el canvas que señale quien puede equiparse el objeto


    // (1) Si un objeto está equipado, no debería volver a salir en esta partida. Tampoco deberían de salir objetos de menor tier
    // Esto lo haremos guardandolo en una lista, y comparando los tiers (puede?)

    public item equipItem(item itemConseguido)
    {
        // esta funcion equipara un objeto en el personaje que llame a la funcion si!!!
        return itemConseguido;
    }

    public void buyItem()
    {
        item item = new item();
        equipItem(item);
    }

    // Esta funcion deberia llamarse cada vez de que el personaje que tenga equipado el objeto golpea a un enemigo YIPIE!!!
    // Reservar para objetos legendarios -> Tier 3
    public void onHitExtraEffect()
    {
        // nothing lol :)
    }
}
