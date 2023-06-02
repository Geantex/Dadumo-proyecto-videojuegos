using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class GuitarraSpin : MonoBehaviour
{
    public GameObject Guitarra;
    public GameObject manoIzquierda;
    public GameObject manoDerecha;
    public bool ItsSpinninTime = false;
    public float timerDuration = 0.5f; // Duration of the timer in seconds
    private float timer; // Current timer value
    private Transform previousParent; // Previous parent of the Guitarra GameObject
    public bool reverseSpinStarted = false; // Flag to check if the reverse spin has started

    public Rotate guitarRotation;

    private void Update()
    {
        if (ItsSpinninTime)
        {
            ItsTimeToSpin();
        }

        if (reverseSpinStarted)
        {
            ReverseSpin();
        }
    }

    public void ItsTimeToSpin()
    {
        if (timer <= timerDuration)
        {
            timer += Time.deltaTime; // Increment the timer

            // Calculate the normalized time value
            float normalizedTime = timer / timerDuration;

            // Move the Guitarra towards manoIzquierda using Lerp
            Guitarra.transform.position = Vector3.Lerp(Guitarra.transform.position, manoIzquierda.transform.position, normalizedTime);
            // Check if the guitar has reached the hand
            if (normalizedTime >= 1f)
            {
                // Detach from the previous parent and attach to manoIzquierda
                previousParent = Guitarra.transform.parent;
                Guitarra.transform.SetParent(manoIzquierda.transform, true);

                // Start the reverse spin
                reverseSpinStarted = true;
                timer = 0f; // Reset the timer for the reverse spin
            }

            // Your custom logic here that runs every frame
        }
        else
        {
            // Timer has reached its duration, do something when the timer is complete
            Debug.Log("Timer complete!");

            // Reset the timer and any other necessary variables
            timer = 0f;
            ItsSpinninTime = false;
        }
    }

    public void ReverseSpin()
    {
        // Move the Guitarra towards manoDerecha using Lerp
        float normalizedTime = timer / timerDuration;
        Guitarra.transform.position = Vector3.Lerp(Guitarra.transform.position, manoDerecha.transform.position, normalizedTime);

        // Check if the guitar has reached the hand
        if (normalizedTime >= 1f)
        {
            // Detach from manoIzquierda and attach back to previous parent (manoDerecha)
            Guitarra.transform.SetParent(previousParent, true);

            // Reset the reverse spin variables
            reverseSpinStarted = false;
        }

        // Your custom logic here that runs during the reverse spin
    }
    public void CallTheGuitarBack()
    {
        StartCoroutine(SetSpinningBackTrue());
    }
    private IEnumerator SetSpinningBackTrue()
    {
        yield return new WaitForSeconds(1f);
        reverseSpinStarted=true;
    }
}
