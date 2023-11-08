using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duchess : MonoBehaviour
{
    public TaskManager taskref;
    // Start is called before the first frame update 
    void Start()
    {
        taskref = GameObject.FindObjectOfType<TaskManager>();
    }

    // Update is called once per frame 
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            taskref.CompleteSecretTask("Ball");
        }
    }
}
