using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sip : MonoBehaviour
{
    public TaskManager taskref;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cup")
        {
            other.GetComponent<Cup>().emptyCup();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "cup")
        {
            other.GetComponent<Cup>().emptyCup();
            if (other.GetComponent<Cup>().Empty == true)
            {
                taskref.currentTasksFinished += 1;
            }
        }
    }
}
