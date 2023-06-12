using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RayoBrujo : MonoBehaviour
{
    public ParticleSystem rayoParticula;
    public int cantidadDeRayos = 10;
    // Start is called before the first frame update

    public void DispararRayosAlObjetivo(GameObject target)
    {
        StartCoroutine(MultiplesRayos(target));
    }

    private IEnumerator MultiplesRayos(GameObject target)
    {
        int auxRayos = cantidadDeRayos;
        while (auxRayos > 0)
        {
            auxRayos--;
            ParticleSystem rayo = Instantiate(rayoParticula, transform.position, Quaternion.identity);
            rayo.transform.LookAt(target.transform);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
