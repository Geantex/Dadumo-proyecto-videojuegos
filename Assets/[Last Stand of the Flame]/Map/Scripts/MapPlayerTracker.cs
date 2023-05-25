using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Map
{
    public class MapPlayerTracker : MonoBehaviour
    {
        public bool lockAfterSelecting = true;
        public float enterNodeDelay = 0.6f;
        public MapManager mapManager;
        public MapView view;

        public static MapPlayerTracker Instance;

        public bool Locked { get; set; }

        private void Awake()
        {
            Instance = this;
        }

        public void SelectNode(MapNode mapNode)
        {
            if (Locked) return;

            // Debug.Log("Selected node: " + mapNode.Node.point);

            if (mapManager.CurrentMap.path.Count == 0)
            {
                // player has not selected the node yet, he can select any of the nodes with y = 0
                if (mapNode.Node.point.y == 0)
                    SendPlayerToNode(mapNode);
                else
                    PlayWarningThatNodeCannotBeAccessed();
            }
            else
            {
                var currentPoint = mapManager.CurrentMap.path[mapManager.CurrentMap.path.Count - 1];
                var currentNode = mapManager.CurrentMap.GetNode(currentPoint);

                if (currentNode != null && currentNode.outgoing.Any(point => point.Equals(mapNode.Node.point)))
                    SendPlayerToNode(mapNode);
                else
                    PlayWarningThatNodeCannotBeAccessed();
            }
        }

        private void SendPlayerToNode(MapNode mapNode)
        {
            Locked = lockAfterSelecting;
            mapManager.CurrentMap.path.Add(mapNode.Node.point);
            mapManager.SaveMap();
            view.SetAttainableNodes();
            view.SetLineColors();
            // Aqui hacemos el fundido a negro cuando haces click en una parte del mapa
            FadeToBlack.StartFade(false, 0.5f);
            mapNode.ShowSwirlAnimation();

            DOTween.Sequence().AppendInterval(enterNodeDelay).OnComplete(() => EnterNode(mapNode));
        }

        private static void EnterNode(MapNode mapNode)
        {
            // we have access to blueprint name here as well
            Debug.Log("Entering node: " + mapNode.Node.blueprintName + " of type: " + mapNode.Node.nodeType);
            // load appropriate scene with context based on nodeType:
            // or show appropriate GUI over the map: 
            // if you choose to show GUI in some of these cases, do not forget to set "Locked" in MapPlayerTracker back to false
            GameObject encounterManager = GameObject.FindWithTag("EncounterManager");
            switch (mapNode.Node.nodeType)
            {
                case NodeType.MinorEnemy:
                    // Aqui cargamos la escena de batalla!
                    GameController.Instancia.SetStateByType(typeof(GameState));
                    switch (mapNode.Node.mapPosition)
                    {
                        case 0:
                            SceneManager.LoadScene("BosqueCombate");
                            break;

                        case 1:
                            SceneManager.LoadScene("BosqueCombate");
                            break;

                        case 2:
                            SceneManager.LoadScene("BosqueCombate");
                            break;

                        case 3:
                            SceneManager.LoadScene("PuebloCombate");
                            break;

                        case 4:
                            SceneManager.LoadScene("PuebloCombate");
                            break;

                        case 5:
                            SceneManager.LoadScene("PuebloCombate");
                            break;

                        case 6:
                            SceneManager.LoadScene("PuebloCombate");
                            break;

                        case 7:
                            SceneManager.LoadScene("MontanaCombate");
                            break;

                        case 8:
                            SceneManager.LoadScene("MontanaCombate");
                            break;

                        case 9:
                            SceneManager.LoadScene("MontanaCombate");
                            break;

                        case 10:
                            SceneManager.LoadScene("MontanaCombate");
                            break;

                    }
                    break;
                    // !! Esto seria si queremos meter minijefes
                    //case NodeType.EliteEnemy:
                    //    break;
                case NodeType.RestSite:
                    // Aqui es un descanso y recuperas salud
                    SceneManager.LoadScene("Hoguera");

                    break;
                case NodeType.Treasure:
                    // Aqui consigues una mejora de ataque o de salud
                    encounterManager.GetComponent<EncounterManager>().StartTreasureEncounter();

                    break;
                case NodeType.Store:
                    // Tienda para comprar objetos
                    GameController.Instancia.SetStateByType(typeof(ShopState));
                    
                    break;
                case NodeType.Boss:
                    // El señor de la ceniza (plin plin plon!)
                    // Aqui solo puede salir el volcan!
                    // Hay que meter esta escena en el scene manager
                    SceneManager.LoadScene("VolcanCombate");

                    break;
                case NodeType.Mystery:
                    // encuentro aleatorio!!!
                    encounterManager.GetComponent<EncounterManager>().StartRandomEncounter(0);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void PlayWarningThatNodeCannotBeAccessed()
        {
            Debug.Log("Selected node cannot be accessed");
        }
    }
}