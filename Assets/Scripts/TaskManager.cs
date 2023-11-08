using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    [System.Serializable]
    public class Tasks
    {
        public string name;
        public string description;
        public string hiddenDesc;
        public GameObject TaskOBJ;
        public Image checkbox;
        public int dignityPoints;
        public bool completed;
    }

    public List<Tasks> allTasks = new List<Tasks>();
    public GameObject TaskPrefab;
    public Sprite completedBox;

    public GameObject TaskPanel;
    public Dignity Dignityref;

    public AudioSource completesound;
    // Start is called before the first frame update
    void Start()
    {
        setTasks();
        Dignityref = GameObject.FindObjectOfType<Dignity>();
    }

    // Update is called once per frame
    void Update()
    {
        bool allDone = true;


        for (int i = 0; i < allTasks.Count; i++)
        {
            if (allTasks[i].completed == false)
            {
                allDone = false;
                break;
            }
        }



        if (allDone)
        {
            SceneManager.LoadScene("GoodEnding");
        }

    }

    public void setTasks()
    {
        for (int i = 0; i < allTasks.Count; i++)
        {
            allTasks[i].TaskOBJ = Instantiate(TaskPrefab, TaskPanel.transform);

            allTasks[i].TaskOBJ.GetComponentInChildren<TMP_Text>().text = allTasks[i].description;


        }

    }

    public void CompleteTask(string task)
    {
        for (int i = 0; i < allTasks.Count; i++)
        {
            if (allTasks[i].name == task)
            {
                if(allTasks[i].completed == false)
                {
                    allTasks[i].completed = true;
                    allTasks[i].TaskOBJ.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = completedBox;
                    completesound.Play();
                    Dignityref.totalDignityPoints += allTasks[i].dignityPoints;
                }


            }
        }

    }

    public void CompleteSecretTask(string task)
    {
        for (int i = 0; i < allTasks.Count; i++)
        {
            if (allTasks[i].name == task)
            {
                if (allTasks[i].completed == false)
                {
                    allTasks[i].completed = true;
                    allTasks[i].TaskOBJ.GetComponentInChildren<TMP_Text>().text = allTasks[i].hiddenDesc;
                    allTasks[i].TaskOBJ.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = completedBox;
                    completesound.Play();
                    Dignityref.totalDignityPoints += allTasks[i].dignityPoints;
                }


            }


        }
    }
}
