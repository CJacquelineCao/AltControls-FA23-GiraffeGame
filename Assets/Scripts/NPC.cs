using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Animator animator;
    public bool Gameon;
    public Material[] material;
    Renderer rend;

    public bool paused;

    public float totalMoodValue;
    public float currentMoodValue;
    public Slider happinessSlider;
    // Start is called before the first frame update


    // Use this for initialization
    void Start()
    {
       rend = GetComponent<Renderer>();
        currentMoodValue = totalMoodValue;
       
    }

    public void changeMood(float mood)
    {
        currentMoodValue += mood;
    }
     

    // Update is called once per frame
    void Update()
    {

        happinessSlider.maxValue = totalMoodValue;
        happinessSlider.value = currentMoodValue;
        if (paused == false)
        {
            if (currentMoodValue < 30)
            {
                setState(2);
            }
            else if (currentMoodValue > 30 && currentMoodValue < 70)
            {
                setState(1);
            }
            else
            { setState(0); }

        }

    }

    public void setState(int state)
    {
        rend.sharedMaterial = material[state];
    }

    
}
