using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cup : MonoBehaviour
{
    Vector3 Changeheight = new Vector3(0, 0.005f, 0);
    Vector3 Minusheight = new Vector3(0, -0.005f, 0);
    public GameObject Teafill;

    public bool Filled;
    public bool Empty;

    public GameObject steamParticles;
    public GameObject toxicParticles;
    public bool isPoisoned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Teafill.transform.localScale.y > 0.8)
        {
            Filled = true;
        }
        else
        {
           // Filled = false;
        }
        if(Teafill.transform.localScale.y < 0.015)
        {
            Empty = true;
            Filled = false;
        }
        else
        {
            Empty = false;

        }

        if(Filled == true)
        {
            if(isPoisoned == true)
            {
                toxicParticles.SetActive(true);
            }
            else
            {
                steamParticles.SetActive(true);
            }

        }
        else
        {
            steamParticles.SetActive(false);
            toxicParticles.SetActive(false);

        }
    }

    public void fillCup()
    {
        if(Teafill.transform.localScale.y < 0.9)
        {
            Teafill.transform.localScale += Changeheight;
        }

    }

    public void emptyCup()
    {
        if (Teafill.transform.localScale.y > 0.01)
        {
            Debug.Log("drinking");
            Teafill.transform.localScale += Minusheight;
            if(isPoisoned == true)
            {
                isPoisoned = false;
                //die;
                StartCoroutine(Die());
            }
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(5);
    }

}
