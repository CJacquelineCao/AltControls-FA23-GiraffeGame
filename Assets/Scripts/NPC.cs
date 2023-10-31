using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator animator;
    public bool Gameon;
    public Material[] material;
    Renderer rend;
    // Start is called before the first frame update
   

    // Use this for initialization
    void Start()
    {
       rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            rend.sharedMaterial = material[0];
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            rend.sharedMaterial = material[1];
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            rend.sharedMaterial = material[2];
        }
       
    }

    
}
