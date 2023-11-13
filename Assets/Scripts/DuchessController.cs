using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public float lerpTime = 3f;
    private float currentLerpTime = 0;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool isLerpingForward = true;

    public Slider dignitySlider;
    public float dignityDecreaseRate = 0.01f;
    public float happinessThreshold = 0.5f; // Threshold to make her happy again

    private bool isApproaching = true;

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
                DecreaseDignity();
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
            SceneManager.LoadScene("GameOverScene");
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

    public void GetSlapped()
    {
        currentState = DuchessState.Slapped;
    }

    void DecreaseDignity()
    {
        dignitySlider.value -= dignityDecreaseRate * Time.deltaTime;
        if (dignitySlider.value <= happinessThreshold)
        {
            currentState = DuchessState.Angry;
        }
    }

    public void MakeHappy()
    {
        // Logic to make the duchess happy
        currentState = DuchessState.Happy;
        dignitySlider.value = 1; // Reset dignity
    }
}
