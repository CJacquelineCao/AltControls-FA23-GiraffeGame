using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");

    }

    public void QuitGame()
    {
        Application.Quit();

    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
