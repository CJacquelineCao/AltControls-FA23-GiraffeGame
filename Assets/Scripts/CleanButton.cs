using UnityEngine;

public class CleanButton : MonoBehaviour
{
    public void OnCleanButtonPressed()
    {
        // Find all objects with the tag "SpawnedObject" and delete them.
        GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("SpawnedObject");
        foreach (GameObject spawnedObj in spawnedObjects)
        {
            Destroy(spawnedObj);
        }

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }


    }


}

