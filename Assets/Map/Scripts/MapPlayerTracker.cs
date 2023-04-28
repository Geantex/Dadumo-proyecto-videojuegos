﻿using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Map
{
    public class MapPlayerTracker : MonoBehaviour
    {
        public bool lockAfterSelecting = false;
        public float enterNodeDelay = 1f;
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
                    //SceneManager:LoadScene(1);
                    break;
                    // !! Esto seria si queremos meter minijefes
                    //case NodeType.EliteEnemy:
                    //    break;
                case NodeType.RestSite:
                    // Aqui es un descanso y recuperas salud
                    encounterManager.GetComponent<EncounterManager>().startRandomEncounter(1001);

                    break;
                case NodeType.Treasure:
                    // Aqui consigues una mejora de ataque o de salud
                    encounterManager.GetComponent<EncounterManager>().startRandomEncounter(1002);

                    break;
                case NodeType.Store:
                    // Tienda para comprar objetos

                    break;
                case NodeType.Boss:
                    // El señor de la ceniza (plin plin plon!)

                    break;
                case NodeType.Mystery:
                    // encuentro aleatorio!!!
                    encounterManager.GetComponent<EncounterManager>().startRandomEncounter(0);

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