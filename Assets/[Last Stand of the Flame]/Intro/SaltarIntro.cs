using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltarIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameController.Instancia.SetStateByType(typeof(Randomizer));
        }
    }
}
