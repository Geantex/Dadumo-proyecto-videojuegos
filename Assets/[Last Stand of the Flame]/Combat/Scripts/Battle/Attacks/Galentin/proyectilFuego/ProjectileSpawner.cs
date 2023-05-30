using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform target;

    public float speed = 30f;

    // La funcion de ataque tiene que mandarle un objetivo !
    public void SpawnProjectile(GameObject target)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.SetTarget(target.transform, speed);
    }
}
