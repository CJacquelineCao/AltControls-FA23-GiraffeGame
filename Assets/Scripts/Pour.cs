using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    public GameObject teaPrefab;

    public GameObject nozzle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

   public void PourTea()
    {
        Instantiate(teaPrefab, nozzle.transform.position, Quaternion.identity);
    }
}
