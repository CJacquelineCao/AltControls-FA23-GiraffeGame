using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public enum DuchessState
{
    Approaching,
    Slapped,
    Happy,
    Angry
}

public class DuchessController : MonoBehaviour
{
    public DuchessState currentState = DuchessState.Approaching;
    public Transform targetTransform;
    public float lerpTime = 4f;
    private float currentLerpTime = 0;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool isLerpingForward = true;

    public Slider dignitySlider;
    public float dignityDecreaseRate = 0.01f;
    public float happinessThreshold = 0.5f; // Threshold to make her happy again


    public NPC myNPC;
    public TaskManager taskref;

    public AudioSource slapsound;
    void Start()
    {
        startPosition = transform.position;
        endPosition = targetTransform.position;
       
    }

    void Update()
    {
            switch (currentState)
        {
            case DuchessState.Approaching:
                LerpMovement();
                break;

            case DuchessState.Slapped:
                TemporaryFaceChange();
                break;

            case DuchessState.Happy:
                // Implement logic to make the duchess happy again
                break;

            case DuchessState.Angry:
                // Trigger game over or angry state
                break;
        }

        if (dignitySlider.value <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    void LerpMovement()
    {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        float perc = currentLerpTime / lerpTime;
        transform.position = Vector3.Lerp(isLerpingForward ? startPosition : endPosition,
                                          isLerpingForward ? endPosition : startPosition,
                                          perc);

        if (currentLerpTime >= lerpTime)
        {
            currentLerpTime = 0;
            isLerpingForward = !isLerpingForward;
        }
    }
    public void TemporaryFaceChange()
    {
        StartCoroutine(TemporaryFaceChangeCoroutine());
    }
    private IEnumerator TemporaryFaceChangeCoroutine()
    {
        myNPC.paused = true;
        myNPC.setState(2); 
        yield return new WaitForSeconds(3);
        myNPC.paused = false;
        currentState = DuchessState.Approaching;
    }

    public void GetSlapped()
    {
        currentState = DuchessState.Slapped;
        slapsound.Play();
        myNPC.changeMood(-1);
        taskref.CompleteSecretTask("Slap");

    }


}
