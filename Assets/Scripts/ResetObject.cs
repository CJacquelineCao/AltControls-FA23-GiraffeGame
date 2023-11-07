using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    public Transform OriginalPosition;
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
        other.transform.position = OriginalPosition.position;
        if (other.GetComponent<Rigidbody>() != null)
        {
            other.GetComponent<Rigidbody>().velocity = new Vector2(0,0);
        }
    }
}
