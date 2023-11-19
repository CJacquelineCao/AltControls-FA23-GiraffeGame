using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public AudioSource buzzingSound;
    public TaskManager taskref;
    public NPC myNPC;
    public float happinessIncrease;

    // Start is called before the first frame update
    void Start()
    {
        myNPC = FindObjectOfType<NPC>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFlying()
    {
        buzzingSound.Play();
        //lerp or something that allows the gameobject the move around

    }

    public void Die()
    {
        buzzingSound.Stop();
        taskref.CompleteSecretTask("Fly");
        if (myNPC != null)
        {
            myNPC.changeMood(happinessIncrease); // happinessIncrease is a float variable indicating how much happiness should increase
        }

        gameObject.SetActive(false);
    }
}
