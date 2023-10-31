using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public Color drycolor;
    public Color wetcolor;

    float wetspeed;
    public Renderer myrenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void turnWet()
    {
        float t = wetspeed;
        myrenderer.material.color = Color.Lerp(drycolor, wetcolor, t);
    }
    private void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "Tea")
        {
            Debug.Log("Collided");
            wetspeed += 0.001f;
            Destroy(other.gameObject);
            turnWet();
        }


    }
}
