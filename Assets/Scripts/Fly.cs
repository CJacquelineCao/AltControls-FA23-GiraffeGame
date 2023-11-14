using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public AudioSource buzzingSound;
    public TaskManager taskref;
    // Start is called before the first frame update
    void Start()
    {
        
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
        gameObject.SetActive(false);
    }
}
