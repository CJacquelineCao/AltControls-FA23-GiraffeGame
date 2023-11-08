using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public TaskManager taskref;
    int dingCounter;
    // Start is called before the first frame update
    void Start()
    {
        taskref = GameObject.FindObjectOfType<TaskManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dingCounter == 5)
        {
            taskref.CompleteSecretTask("Bell");
        }
    }

    public void Ring()
    {
        //audio plays
        dingCounter += 1;
        Debug.Log("Dinged");
    }
}
