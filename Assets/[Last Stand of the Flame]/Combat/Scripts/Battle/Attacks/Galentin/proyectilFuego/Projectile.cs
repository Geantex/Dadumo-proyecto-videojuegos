using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float speed;
    private float rampUpDuration = 0.35f;
    private float rampUpPower = 8f; // Exponential ramp-up power
    private float delayDuration = 0.2f; // Delay duration before speed ramp-up
    private float delayTimer = 0f;
    private float elapsedTime = 0f;

    public GameObject explosionPrefab;
    public GameObject particlePrefab;
    private ParticleSystem particleSystem;

    public void SetTarget(Transform target, float speed)
    {
        this.target = target;
        this.speed = speed;
    }

    private void Start()
    {
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.isKinematic = false;
        particleSystem = Instantiate(particlePrefab, transform.position, Quaternion.identity, transform).GetComponent<ParticleSystem>();

        if (target != null)
        {
            // Rotate particle system towards the target
            particleSystem.transform.LookAt(target);
        }
    }

    private void Update()
    {
        if (target != null)
        {
            if (delayTimer < delayDuration)
            {
                delayTimer += Time.deltaTime;
                return; // Wait for the delay to complete before moving
            }

            elapsedTime += Time.deltaTime;

            Vector3 direction = (target.position - transform.position).normalized;
            float currentSpeed = GetRampedUpSpeed();
            transform.Translate(direction * currentSpeed * Time.deltaTime);

            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget <= currentSpeed * Time.deltaTime)
            {
                // Spawn explosion prefab at current position
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                // Destroy the projectile
                Destroy(gameObject);
            }

            // Rotate particle system towards the target
            particleSystem.transform.LookAt(target);
        }
    }

    private float GetRampedUpSpeed()
    {
        float rampFactor = Mathf.Pow(elapsedTime / rampUpDuration, rampUpPower);
        return Mathf.Lerp(0f, speed, rampFactor);
    }
}
