using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyManager : MonoBehaviour
{
    public GameObject Fly;
    public NPC myNPC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnFly();   
        if(Fly.activeSelf == true)
        {
            myNPC.changeMood(-0.02f);
        }
    }

    void SpawnFly()
    {
        if (Random.Range(0, 8000) == 1)
        {
            if(Fly.activeSelf == false)
            {
                Fly.SetActive(true);
                Fly.GetComponent<Fly>().startFlying();
            }
        }
    }
}
