using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleTimeout : MonoBehaviour
{
    public float timeoutDuration = 60.0f; // Set the idle time in seconds
    public float timer = 0.0f;

    void Update()
    {
        // Check for specific input events - key press or mouse button click
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            timer = 0.0f; // Reset the timer if there's input
        }
        else
        {
            timer += Time.deltaTime; // Increment the timer
        }

        // If the timer exceeds the timeout duration, load the Start scene
        if (timer > timeoutDuration)
        {
            SceneManager.LoadScene("Start"); // Make sure the scene name matches exactly
        }
    }
}
