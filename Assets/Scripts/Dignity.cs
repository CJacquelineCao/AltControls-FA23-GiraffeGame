using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dignity : MonoBehaviour
{
    public int totalDignityPoints;
    public GameObject dignityPanel;
    public TMP_Text pointsDisplay;
    [System.Serializable]
    public class DignityItems
    {
        public string name;
        public string desc;
        public GameObject ItemObject;
        public KeyCode keytoSpawn;
        public int DignityPointsNeeded;
        public bool enabled;
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
            allCommands[i].ItemObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "You need " + allCommands[i].DignityPointsNeeded + "dignity points to unlock this";

        }
    }

    void checkAvailable()
    {
        for (int i = 0; i < allCommands.Count; i++)
        {
            if(totalDignityPoints >= allCommands[i].DignityPointsNeeded)
            {
                if (allCommands[i].enabled == false)
                {
                    allCommands[i].enabled = true;

                }
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(dignityPanel.activeSelf == true)
            {
                dignityPanel.SetActive(false);
            }
            else
            {
                dignityPanel.SetActive(true);
            }
        }
        //if(Input.GetKeyDown(KeyCode.Space) && allCommands[i].enabled == true)
        //{

        //}

        pointsDisplay.text = "Current dignity points: " + totalDignityPoints;

    }
}
