using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableReset : MonoBehaviour
{
    public GameObject[] tableItemPrefabs; // Assign all items on the table that need to be reset
    private GameObject[] tableItemInstances;

    private Vector3[] originalPositions;
    private Quaternion[] originalRotations;

    void Start()
    {
        tableItemInstances = new GameObject[tableItemPrefabs.Length];
        InstansiateTableItems();

        // Store original positions and rotations of table items
        originalPositions = new Vector3[tableItemPrefabs.Length];
        originalRotations = new Quaternion[tableItemPrefabs.Length];
        for (int i = 0; i < tableItemPrefabs.Length; i++)
        {
            originalPositions[i] = tableItemPrefabs[i].transform.position;
            originalRotations[i] = tableItemPrefabs[i].transform.rotation;
        }
    }

    public void InstansiateTableItems()
    {
        // Reset each item to its original position and rotation
        for (int i = 0; i < tableItemPrefabs.Length; i++)
        {
            tableItemPrefabs[i].transform.position = originalPositions[i];
            tableItemPrefabs[i].transform.rotation = originalRotations[i];

            // Add any other reset logic needed for each item, like emptying cups
        }
    }
    public void ResetTable()
    {
        // Destroy current instances
        foreach (var item in tableItemInstances)
        {
            if (item != null)
                Destroy(item);
        }
        
        InstansiateTableItems();
    }
}
