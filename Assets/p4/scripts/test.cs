using UnityEngine.UI;
using UnityEngine;

public class test : MonoBehaviour
{

    public float directionThreshold = 0.1f;
    public int requiredDirectionChanges = 3;

    private float lastMouseX = 0f;
    private int directionChanges = 0;
    private int lastDirection = 0;

    public Animator animator;

    void Update()
    {
        float mouseDeltaX = Input.GetAxis("Mouse X");
        DetectShake(mouseDeltaX);
    }

    void DetectShake(float deltaX)
    {
        if (Mathf.Abs(deltaX) < directionThreshold)
            return;

        int currentDirection = deltaX > 0 ? 1 : -1;

        if (lastDirection != 0 && currentDirection != lastDirection)
        {
            directionChanges++;

            if (directionChanges >= requiredDirectionChanges)
            {
                Debug.Log("shaken");
                animator.Play("shakeB");
                directionChanges = 0;
            }
        }

        lastDirection = currentDirection;
    }
}
