using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulaExplosionMagica : MonoBehaviour
{
    // Start is called before the first frame update
    Transform lugarSplash1;
    Transform lugarSplash2;
    Transform lugarSplash3;
    Transform lugarSplash4;
    Transform lugarSplash5;

    public GameObject splashPrefab; // "splash" (la particula/efecto de agua haciendo splash)
    public GameObject expMagicaPrefab; // explosion magica prefab
    void Start()
    {
        lugarSplash1 = new GameObject().transform;
        lugarSplash2 = new GameObject().transform;
        lugarSplash3 = new GameObject().transform;
        lugarSplash4 = new GameObject().transform;
        lugarSplash5 = new GameObject().transform;

        float distanciaDeVictima = 1f;
        Vector3 vectorSplash1 = new Vector3(distanciaDeVictima, 0f, distanciaDeVictima);
        Vector3 vectorSplash2 = new Vector3(-distanciaDeVictima, 0f, -distanciaDeVictima);
        Vector3 vectorSplash3 = new Vector3(-distanciaDeVictima, 0f, distanciaDeVictima);
        Vector3 vectorSplash4 = new Vector3(distanciaDeVictima, 0f, -distanciaDeVictima);
        Vector3 vectorSplash5 = new Vector3(0f, distanciaDeVictima, 0f);

        lugarSplash1.position = vectorSplash1;
        lugarSplash2.position = vectorSplash2;
        lugarSplash3.position = vectorSplash3;
        lugarSplash4.position = vectorSplash4;
        lugarSplash5.position = vectorSplash5;
        
    }

    public void ExplosionMagica(GameObject target)
    {
        StartCoroutine(EsperaEntreSplashes(target));
    }

    // El plan es hacer aparecer como 5 particulas de "splash" de agua, y después una explosión azul, todo esto en un plazo de 1.5f
    IEnumerator EsperaEntreSplashes(GameObject target)
    {
        float delay = 0.1f;
            // splash 1
            Debug.Log("Splash 1");
            splashPrefab.transform.SetPositionAndRotation(lugarSplash1.position, Quaternion.identity);
            Instantiate(splashPrefab, target.transform);
            yield return new WaitForSeconds(delay+0.15f);

            // splash 2
            Debug.Log("Splash 2");

            splashPrefab.transform.SetPositionAndRotation(lugarSplash2.position, Quaternion.identity);
            Instantiate(splashPrefab, target.transform);
            yield return new WaitForSeconds(delay);

            // splash 3
            Debug.Log("Splash 3");

            splashPrefab.transform.SetPositionAndRotation(lugarSplash3.position, Quaternion.identity);
            Instantiate(splashPrefab, target.transform);
            yield return new WaitForSeconds(delay);

            // splash 4
            Debug.Log("Splash 4");

            splashPrefab.transform.SetPositionAndRotation(lugarSplash4.position, Quaternion.identity);
            Instantiate(splashPrefab, target.transform);
            yield return new WaitForSeconds(delay);

            // splash 5
            Debug.Log("Splash 5");

            splashPrefab.transform.SetPositionAndRotation(lugarSplash5.position, Quaternion.identity);
            Instantiate(splashPrefab, target.transform);
            Debug.Log("EXPLOSION!");

            yield return new WaitForSeconds(delay);
            Instantiate(expMagicaPrefab, target.transform);

        

    }
    

}
