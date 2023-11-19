using UnityEngine;

public class TableManager : MonoBehaviour
{
    public GameObject[] tableItemPrefabs; // Array to hold prefab references
    private GameObject[] tableItemInstances; // Array to hold instances of prefabs

    void Start()
    {
        tableItemInstances = new GameObject[tableItemPrefabs.Length];
        InstantiateTableItems(); // Instantiate items at the start
    }

    void InstantiateTableItems()
    {
        for (int i = 0; i < tableItemPrefabs.Length; i++)
        {
            // Check if an instance already exists, destroy it if so
            if (tableItemInstances[i] != null)
                Destroy(tableItemInstances[i]);

            // Instantiate the prefab and store the instance
            tableItemInstances[i] = Instantiate(tableItemPrefabs[i], tableItemPrefabs[i].transform.position, tableItemPrefabs[i].transform.rotation);
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
        // Re-instantiate table items to reset them
        InstantiateTableItems();
    }
}
