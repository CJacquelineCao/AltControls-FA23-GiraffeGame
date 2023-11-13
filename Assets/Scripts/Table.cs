using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Slider dirtinessSlider;



    // Start is called before the first frame update
    void Start()
    {
        if (dirtinessSlider != null)
        {
            dirtinessSlider.value = 0; // Assuming the table starts clean
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(t <=0)
        {
            turnDry();
        }
        else
        {
            t = maxTime - elapsedTime;
        }
        if (wetspeed<0.3)
        {
            myNPC.setState(0);
        }
        else if(wetspeed>0.3 && wetspeed < 0.7 )
        {
            myNPC.setState(1);
        }
        else
        { myNPC.setState(2);}

        UpdateDirtinessSlider();

        if (wetspeed >= 1)
        {
            SceneManager.LoadScene("BadEnding");
        }

    }
    void turnDry()
    {
        float t = wetspeed;
        myrenderer.material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, drycolor, t);
    }
    void turnWet()
    {
        float t = wetspeed;
        myrenderer.material.color = Color.Lerp(drycolor, wetcolor, t);
    }
    void UpdateDirtinessSlider()
    {
         if (dirtinessSlider != null)
         {
            dirtinessSlider.value = 1-wetspeed;
  
               // dirtinessSlider.value = wetspeed; // Update the slider with the current dirtiness
         }
    }
        private void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "Tea")
        {
            t = maxTime;
            elapsedTime = 0;
            Debug.Log("Collided");
            wetspeed += 0.001f;
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
