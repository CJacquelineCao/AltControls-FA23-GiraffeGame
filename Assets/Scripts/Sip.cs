using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sip : MonoBehaviour
{
    public TaskManager taskref;
    public AudioSource sipSound;

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
            if (other.GetComponent<Cup>().Filled == true)
            {
                other.GetComponent<Cup>().emptyCup();
                sipSound.Play();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "cup")
        {
            if(other.GetComponent<Cup>().Filled == true)
            {
                other.GetComponent<Cup>().emptyCup();
            }
            if (other.GetComponent<Cup>().Empty == true)
            {
                taskref.CompleteTask("Drink");
                sipSound.Stop();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "cup")
        {
            sipSound.Stop();
        }
    }
}
