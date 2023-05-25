using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    private float speed;

    public void SetTarget(Transform target, float speed)
    {
        this.target = target;
        this.speed = speed;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);

            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget <= speed * Time.deltaTime)
            {
                // Projectile reached the target, destroy it
                Destroy(gameObject);
            }
        }
    }
}
