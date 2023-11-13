using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public float maxExistenceTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxExistenceTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cup")
        {
            other.GetComponent<Cup>().fillCup();
            other.GetComponent<Cup>().isPoisoned = true;
            Destroy(gameObject);
        }
    }
}
