using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableReset : MonoBehaviour
{
    public GameObject[] tableItems; // Assign all items on the table that need to be reset

    private Vector3[] originalPositions;
    private Quaternion[] originalRotations;

    void Start()
    {
        // Store original positions and rotations of table items
        originalPositions = new Vector3[tableItems.Length];
        originalRotations = new Quaternion[tableItems.Length];
        for (int i = 0; i < tableItems.Length; i++)
        {
            originalPositions[i] = tableItems[i].transform.position;
            originalRotations[i] = tableItems[i].transform.rotation;
        }
    }

    public void ResetTable()
    {
        // Reset each item to its original position and rotation
        for (int i = 0; i < tableItems.Length; i++)
        {
            tableItems[i].transform.position = originalPositions[i];
            tableItems[i].transform.rotation = originalRotations[i];

            // Add any other reset logic needed for each item, like emptying cups
        }
    }
}
