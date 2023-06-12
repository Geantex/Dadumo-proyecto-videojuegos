using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tienda : MonoBehaviour
{

    private float dineraco = GameController.Instancia.GoldCoins; // dabloons!
    public GameObject dineroText;

    public List<item> itemsList;
    public List<int> noDuplicates = new List<int>();
    public item item1;
    public item item2;
    public item item3;
    public item item4;

    GameObject itemTienda1;
    GameObject itemTienda2;
    GameObject itemTienda3;
    GameObject itemTienda4;
    GameObject mercenarioTienda;
    GameObject canvasTienda;

    GameObject imagen1;
    GameObject empty1;
    GameObject nombre1;
    GameObject price1;

    GameObject imagen2;
    GameObject nombre2;
    GameObject price2;

    GameObject imagen3;
    GameObject nombre3;
    GameObject price3;

    GameObject imagen4;
    GameObject nombre4;
    GameObject price4;

    GameObject mercenarioImage;
    GameObject mercenarioNombre;
    GameObject mercenarioPrecioText;

    public string mercenarioName;
    public Sprite mercenarioImagen;

    public Button sanacionBoton;

    int mercenarioPrecio;

    void Start()
    {
        itemTienda1 = GameObject.FindWithTag("itemTienda1");
        itemTienda2 = GameObject.FindWithTag("itemTienda2");
        itemTienda3 = GameObject.FindWithTag("itemTienda3");
        itemTienda4 = GameObject.FindWithTag("itemTienda4");
        mercenarioTienda = GameObject.FindWithTag("mercenarioTienda");

        GameObject canvasTienda = GameObject.FindWithTag("canvas");
        dineroText = canvasTienda.transform.Find("DineroTotal").gameObject;
        sanacionBoton.onClick.AddListener(buySanacion);

        Debug.Log("ESTOY POR EJECUTARME");
        Invoke("itemTienda", 0f); //esto es una fix temporal, no debería de estar en la main build, el fichero carga más rápido que la lista
        //itemTienda();
    }

    void Update()
    {
        dineroText.GetComponent<Text>().text = dineraco.ToString();
    }
    public void itemTienda()
    {
        canvasTienda = GameObject.FindWithTag("canvas");
        itemsList = canvasTienda.GetComponent<itemManager>().allItemsList;
        //-------------------item1----------------------
        item1 = pickItemRandom(itemsList);
        empty1 = itemTienda1.transform.Find("Empty1").gameObject;
        imagen1 = itemTienda1.transform.Find("Image1").gameObject;
        nombre1 = itemTienda1.transform.Find("nombreDeItem1").gameObject;
        price1 = itemTienda1.transform.Find("Button1").gameObject.transform.Find("textoBoton1").gameObject;  //Frankestein anmorten inummicus

        empty1 = item1.itemPrefab;
        imagen1.GetComponent<Image>().sprite = item1.itemImage;
        nombre1.GetComponent<Text>().text = item1.itemName;
        price1.GetComponent<Text>().text = item1.itemPrice.ToString();

        //----------------item2------------------------
        item2 = pickItemRandom(itemsList);
        imagen2 = itemTienda2.transform.Find("Image2").gameObject;
        nombre2 = itemTienda2.transform.Find("nombreDeItem2").gameObject;
        price2 = itemTienda2.transform.Find("Button2").gameObject.transform.Find("textoBoton2").gameObject;

        imagen2.GetComponent<Image>().sprite = item2.itemImage;
        nombre2.GetComponent<Text>().text = item2.itemName;
        price2.GetComponent<Text>().text = item2.itemPrice.ToString();

        //---------------item3---------------------------
        item3 = pickItemRandom(itemsList);
        imagen3 = itemTienda3.transform.Find("Image3").gameObject;
        nombre3 = itemTienda3.transform.Find("nombreDeItem3").gameObject;
        price3 = itemTienda3.transform.Find("Button3").gameObject.transform.Find("textoBoton3").gameObject;

        imagen3.GetComponent<Image>().sprite = item3.itemImage;
        nombre3.GetComponent<Text>().text = item3.itemName;
        price3.GetComponent<Text>().text = item3.itemPrice.ToString();

        //---------------item4----------------------------
        item4 = pickItemRandom(itemsList);
        imagen4 = itemTienda4.transform.Find("Image4").gameObject;
        nombre4 = itemTienda4.transform.Find("nombreDeItem4").gameObject;
        price4 = itemTienda4.transform.Find("Button4").gameObject.transform.Find("textoBoton4").gameObject;

        imagen4.GetComponent<Image>().sprite = item4.itemImage;
        nombre4.GetComponent<Text>().text = item4.itemName;
        price4.GetComponent<Text>().text = item4.itemPrice.ToString();

        /*//------------mercenario(epic??)------------------
        // mercenarioAleatorio = pickPartyMemberRandom(partyMemberList);
        mercenarioImage = mercenarioTienda.transform.Find("imagenMercenario").gameObject;
        mercenarioNombre = mercenarioTienda.transform.Find("nombreMercenario").gameObject;
        mercenarioPrecioText = mercenarioTienda.transform.Find("botonMercenario").gameObject.transform.Find("precioMercenario").gameObject;


        // aqui definimos el precio de comprar un nuevo esclav- uhhh miembro del equipo
        mercenarioPrecio = 750;

        mercenarioImage.GetComponent<Image>().sprite = mercenarioImagen;
        mercenarioNombre.GetComponent<Text>().text = mercenarioName;
        mercenarioPrecioText.GetComponent<Text>().text = mercenarioPrecio.ToString();*/
    }
    public item pickItemRandom(List<item> itemList)
    {
        int index = Random.Range(0, itemList.Count);

        while (noDuplicates.Contains(index)) //joder que miedo
        {
            index = Random.Range(0, itemList.Count);
        }
        noDuplicates.Add(index);
        Debug.Log("index: " + index);
        Debug.Log("itemList count: " + itemList.Count);
        return itemList[index];
    }

    public void exitShop()
    {
        FadeToBlack.QuickFade();
        Invoke("exitShopAmbatakam", 0.25f);
    }

    public void exitShopAmbatakam()
    {
        SceneManager.LoadScene("Map");
        GameController.Instancia.SetStateByType(typeof(MapState));
    }
    public void buyItem1()
    {
        if (dineraco < item1.itemPrice)
        {
            Debug.Log("Die notas eres pobre!!");
            // TasearAlJugador(); No me dejan meter esta funcion #cringe?? me watching my mom shower
        }
        else
        {
            dineraco = dineraco - item1.itemPrice;
            GameController.Instancia.GoldCoins = dineraco;
            // comprar el objeto, equiparselo al jugador y descontarselo del dinero total
            item1.equipItem(item1);
            itemTienda1.transform.Find("Vendido").gameObject.SetActive(true);
            itemTienda1.transform.Find("Button1").gameObject.SetActive(false);
        }
    }
    public void buyItem2()
    {
        if (dineraco < item2.itemPrice)
        {
            Debug.Log("Die notas eres pobre!!");
            // TasearAlJugador(); No me dejan meter esta funcion #cringe?? me watching my mom shower
        }
        else
        {
            dineraco = dineraco - item2.itemPrice;
            GameController.Instancia.GoldCoins = dineraco;
            // comprar el objeto, equiparselo al jugador y descontarselo del dinero total
            item2.equipItem(item2);
            itemTienda2.transform.Find("Vendido").gameObject.SetActive(true);
            itemTienda2.transform.Find("Button2").gameObject.SetActive(false);


        }
    }
    public void buyItem3()
    {
        if (dineraco < item3.itemPrice)
        {
            Debug.Log("Die notas eres pobre!!");
            // TasearAlJugador(); No me dejan meter esta funcion #cringe?? me watching my mom shower
        }
        else
        {
            dineraco = dineraco - item3.itemPrice;
            GameController.Instancia.GoldCoins = dineraco;
            // comprar el objeto, equiparselo al jugador y descontarselo del dinero total
            item3.equipItem(item3);
            itemTienda3.transform.Find("Vendido").gameObject.SetActive(true);
            itemTienda3.transform.Find("Button3").gameObject.SetActive(false);
        }
    }
    public void buyItem4()
    {
        if (dineraco < item4.itemPrice)
        {
            Debug.Log("Die notas eres pobre!!");
            // TasearAlJugador(); No me dejan meter esta funcion #cringe?? me watching my mom shower
        }
        else
        {
            dineraco = dineraco - item4.itemPrice;
            GameController.Instancia.GoldCoins = dineraco;
            item4.equipItem(item4); // Hugo c:
            // comprar el objeto, equiparselo al jugador y descontarselo del dinero total
            itemTienda4.transform.Find("Vendido").gameObject.SetActive(true);
            itemTienda4.transform.Find("Button4").gameObject.SetActive(false);

        }
    }

    // En el futuro juntar todo en un solo buyItem() molon, que coja el itemTienda del gameObject uhh si :)

    public void buySanacion()
    {
        if (dineraco < 100)
        {
            Debug.Log("pobreton vives en America = no free healthcare!!!");

        }
        else
        {
            dineraco = dineraco - 100;
            GameController.Instancia.GoldCoins = dineraco;
            // curar a la party funcion Hugo vuelale los cojones a Gerad!! y a Maro! y a George! y a Miawses! y a Gabriel! espera soy yo!! a ese tambien !! mm
            GameController.Instancia.modifyPartyHealthPoints(40f);
            sanacionBoton.transform.Find("Vendido").gameObject.SetActive(true);
            sanacionBoton.onClick.RemoveAllListeners();
        }

    }

    // buySlave es un nombre mucho mejor!!
    public void buyMercenario()
    {

        if (dineraco < mercenarioPrecio)
        {
            Debug.Log("pobreton no te puedes comprar a un esclavo!");
        }
        else
        {
            dineraco = dineraco - mercenarioPrecio;
            GameController.Instancia.GoldCoins = dineraco;
            mercenarioTienda.transform.Find("Vendido").gameObject.SetActive(true);
            mercenarioTienda.transform.Find("botonMercenario").gameObject.SetActive(false);
        }

    }

}