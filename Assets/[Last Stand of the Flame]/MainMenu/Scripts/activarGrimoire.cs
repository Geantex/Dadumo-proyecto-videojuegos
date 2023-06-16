using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarGrimoire : MonoBehaviour
{
    public GameObject prefabGrimoire;

    public void ActivarGrimoirePrefab()
    {
        prefabGrimoire.SetActive(true);
    }

    public void DesactivarGrimoirePrefab()
    {
        prefabGrimoire.SetActive(false);
    }
}
