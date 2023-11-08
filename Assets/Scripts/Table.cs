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
    public Renderer myrenderer;

    public NPC myNPC;

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
       //if( Input.GetKey(KeyCode.Space))
       // {
       //     wetspeed += 0.001f;
       // }
        if(wetspeed<0.3)
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

    void turnWet()
    {
        float t = wetspeed;
        myrenderer.material.color = Color.Lerp(drycolor, wetcolor, t);
    }
    void UpdateDirtinessSlider()
    {
         if (dirtinessSlider != null)
         {
                dirtinessSlider.value = wetspeed; // Update the slider with the current dirtiness
         }
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
