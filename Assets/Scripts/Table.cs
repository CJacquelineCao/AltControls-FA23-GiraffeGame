using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Table : MonoBehaviour
{
    public Color drycolor;
    public Color wetcolor;

    public float wetspeed;
    public float dryspeed;
    public Renderer myrenderer;

    public NPC myNPC;


    public float elapsedTime;
    public float maxTime;
    public float t;

 



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(t <=0)
        {
            turnDry();
            wetspeed = 0;
        }
        else
        {
            t = maxTime - elapsedTime;
        }



        if (wetspeed >= 1)
        {
            SceneManager.LoadScene("BadEnding");
        }

    }
    void turnDry()
    {
        dryspeed += 0.001f;
        float t = dryspeed;
        myrenderer.material.color = Color.Lerp(myrenderer.material.color, drycolor, t);
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
            dryspeed = 0;
            t = maxTime;
            elapsedTime = 0;
            Debug.Log("Collided");
            wetspeed += 0.001f;
            myNPC.changeMood(-0.1f);
            Destroy(other.gameObject);
            turnWet();
        }
        else if(other.tag == "ball")
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        else if(other.tag == "poison")
        {
            Destroy(other.gameObject);
        }


    }

}
