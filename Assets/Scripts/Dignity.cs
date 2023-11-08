using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dignity : MonoBehaviour
{
    public int totalDignityPoints;
    public GameObject dignityPanel;
    public TMP_Text pointsDisplay;
    public GameObject spawnlocation;
    [System.Serializable]
    public class DignityItems
    {
        public string name;
        public string desc;
        public GameObject ItemObject;
        public GameObject SpawnPrefab;
        public KeyCode keytoSpawn;
        public int DignityPointsNeeded;
        public bool enabled;
        public bool spawned;
    }
    public List<DignityItems> allCommands = new List<DignityItems>();
    // Start is called before the first frame update 
    void Start()
    {
        setCommands();
    }

    void setCommands()
    {
        for (int i = 0; i < allCommands.Count; i++)
        {
            allCommands[i].ItemObject.transform.GetChild(0).GetComponent<TMP_Text>().text = "???";
            allCommands[i].ItemObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "You need " + allCommands[i].DignityPointsNeeded + " dignity points to unlock this";

        }
    }

    void checkAvailable()
    {
        for (int i = 0; i < allCommands.Count; i++)
        {
            if (totalDignityPoints >= allCommands[i].DignityPointsNeeded)
            {
                if (allCommands[i].enabled == false)
                {
                    allCommands[i].enabled = true;
                    allCommands[i].ItemObject.transform.GetChild(0).GetComponent<TMP_Text>().text = allCommands[i].name;
                    allCommands[i].ItemObject.transform.GetChild(1).GetComponent<TMP_Text>().text = allCommands[i].desc;

                }
            }
        }

    }
    // Update is called once per frame 
    void Update()
    {
        checkAvailable();
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (dignityPanel.activeSelf == true)
            {
                dignityPanel.SetActive(false);
            }
            else
            {
                dignityPanel.SetActive(true);
            }
        }


        pointsDisplay.text = "Current dignity points: " + totalDignityPoints;
        for (KeyCode key = KeyCode.None; key < KeyCode.Joystick8Button19; key++)
        {
            if (Input.GetKey(key))
            {
                checkKey(key);
            }
        }
    }
    void checkKey(KeyCode keyPressed)
    {
        for (int i = 0; i < allCommands.Count; i++)
        {
            if (keyPressed == allCommands[i].keytoSpawn)
            {
                if (allCommands[i].enabled == true)
                {
                    if (allCommands[i].spawned == false)
                    {
                        Instantiate(allCommands[i].SpawnPrefab, spawnlocation.transform.position, Quaternion.identity);
                        Debug.Log("ItemSpawned");
                        allCommands[i].spawned = true;
                    }

                }
            }
        }
    }
}
