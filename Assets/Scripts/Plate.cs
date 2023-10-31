using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
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
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "cup")
        {
            if (other.GetComponent<Cup>().Filled == true)
            {
                taskref.CompleteTask("Serve");

            }
        }
        if (other.tag == "cake")
        {
            taskref.CompleteTask("Cake");

        }
    }
}
