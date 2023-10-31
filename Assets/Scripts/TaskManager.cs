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
        public TMP_Text TextField;
        public Image checkbox;
        public bool completed;
    }

    public List<Tasks> allTasks = new List<Tasks>();

    public int MaxTaxCount;
    public int currentTasksFinished;
    public Sprite completedBox;
    // Start is called before the first frame update
    void Start()
    {
        setTasks();
    }

    // Update is called once per frame
    void Update()
    {
        MaxTaxCount = allTasks.Count;
        if(currentTasksFinished == MaxTaxCount)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void setTasks()
    {
        for (int i = 0; i < allTasks.Count; i++)
        {
            allTasks[i].TextField.text = allTasks[i].description;
        }

    }
    public void AddToCompleteTally()
    {
        currentTasksFinished += 1;
    }
    public void CompleteTask(string task)
    {
        for(int i= 0; i<allTasks.Count; i++)
        {
            if(allTasks[i].name == task)
            {
                allTasks[i].completed = true;
                allTasks[i].checkbox.sprite = completedBox;
               
            }
        }
        
    }


}
